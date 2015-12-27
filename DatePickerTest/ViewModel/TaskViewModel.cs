using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatePickerTest.Model;

namespace DatePickerTest.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private TaskDataContext dataDB;

        // Class constructor, create the data context object.
        public TaskViewModel(string toDoDBConnectionString)
        {
            dataDB = new TaskDataContext(toDoDBConnectionString);
        }

        //
        // TODO: Add collections, list, and methods here.
        //

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            dataDB.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        // All to-do items.
        private List<TaskItem> _allDataItems;
        public List<TaskItem> AllDataItems
        {
            get { return _allDataItems; }
            set
            {
                _allDataItems = value;
                NotifyPropertyChanged("AllDataItems");
            }
        }

        public void LoadCollectionsFromDatabase()
        {
            // Specify the query for all to-do items in the database.
            var dataItemsInDB = from TaskItem data in dataDB.Items
                                select data;

            // Query the database and load all to-do items.
            AllDataItems = new List<TaskItem>(dataItemsInDB);
        }


        public void AddDataItem(TaskItem newDataItem)
        {
            // Add a to-do item to the data context.
            dataDB.Items.InsertOnSubmit(newDataItem);

            // Save changes to the database.
            dataDB.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            AllDataItems.Add(newDataItem);
 
        }

        public void DeleteDataItem(int Id)
        {
            // Remove the to-do item from the "all" observable collection.
            TaskItem rmItem = AllDataItems[Id];
            AllDataItems.Remove(rmItem);

            // Remove the to-do item from the data context.
            dataDB.Items.DeleteOnSubmit(rmItem);

            // Save changes to the database.
            dataDB.SubmitChanges();   
 
        }

        public void ModifyDataItem(int Id, TaskItem dataForModify)
        {
            TaskItem tmpItem = AllDataItems[Id];
            tmpItem.TaskName = dataForModify.TaskName;
            tmpItem.TaskContent = dataForModify.TaskContent;
            tmpItem.TaskBegin = dataForModify.TaskBegin;
            tmpItem.TaskEnd = dataForModify.TaskEnd;
            tmpItem.TaskAlarm = dataForModify.TaskAlarm;
            tmpItem.IsScheduled = dataForModify.IsScheduled;
            IQueryable<TaskItem> tmpItemQuery = from TaskItem data in dataDB.Items
                                where data.TaskId == tmpItem.TaskId
                                select data;
            TaskItem tmpItem1 = tmpItemQuery.FirstOrDefault();
            tmpItem1.TaskName = dataForModify.TaskName;
            tmpItem1.TaskContent = dataForModify.TaskContent;
            tmpItem1.TaskBegin = dataForModify.TaskBegin;
            tmpItem1.TaskEnd = dataForModify.TaskEnd;
            tmpItem1.TaskAlarm = dataForModify.TaskAlarm;
            tmpItem1.IsScheduled = dataForModify.IsScheduled;
            dataDB.SubmitChanges();
        }

    }
}
