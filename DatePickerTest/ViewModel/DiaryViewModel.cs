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
    public class DiaryViewModel : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private DiaryDataContext dataDB;

        // Class constructor, create the data context object.
        public DiaryViewModel(string toDoDBConnectionString)
        {
            dataDB = new DiaryDataContext(toDoDBConnectionString);
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
        private List<DiaryItem> _allDataItems;
        public List<DiaryItem> AllDataItems
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
            var dataItemsInDB = from DiaryItem data in dataDB.Items
                                select data;

            // Query the database and load all to-do items.
            AllDataItems = new List<DiaryItem>(dataItemsInDB);
        }


        public void AddDataItem(DiaryItem newDataItem)
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
            DiaryItem rmItem = AllDataItems[Id];
            AllDataItems.Remove(rmItem);

            // Remove the to-do item from the data context.
            dataDB.Items.DeleteOnSubmit(rmItem);

            // Save changes to the database.
            dataDB.SubmitChanges();

        }

        public int SelectItemWithTag(int tag)
        {
            int tagCount = (from DiaryItem data in dataDB.Items
                            where data.MoodTag == tag
                            select data).Count();
            return tagCount;

                                                 
        }
        public void ModifyDataItem(int Id, DiaryItem dataForModify)
        {
            DiaryItem tmpItem = AllDataItems[Id];
            IQueryable<DiaryItem> tmpItemQuery = from DiaryItem data in dataDB.Items
                                                where data.DiaryItemId == tmpItem.DiaryItemId
                                                select data;
            DiaryItem tmpItem1 = tmpItemQuery.FirstOrDefault();
            tmpItem1.DiaryTitle = dataForModify.DiaryTitle;
            tmpItem1.DiaryContent = dataForModify.DiaryContent;
            tmpItem1.DiaryTime = dataForModify.DiaryTime;
            tmpItem1.MoodTag = dataForModify.MoodTag;
            dataDB.SubmitChanges();
        }
    }
}
