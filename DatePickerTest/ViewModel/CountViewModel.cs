//1252992 吴逸菲 CountViewModel.cs 视图——闹钟
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
    public class CountViewModel:INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private CountDataContext countDB;

        // Class constructor, create the data context object.
        public CountViewModel(string countDBConnectionString)
        {
            countDB = new CountDataContext(countDBConnectionString);
        }

        //
        // TODO: Add collections, list, and methods here.
        //

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            countDB.SubmitChanges();
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

        private List<CountItem> _allCountItems;
        public List<CountItem> AllCountItems
        {
            get { return _allCountItems; }
            set
            {
                _allCountItems = value;
                NotifyPropertyChanged("AllCountItems");
            }
        }

        public void LoadCollectionsFromDatabase()
        {
            var countItemsInDB = from CountItem count in countDB.Items
                                 select count;
            AllCountItems = new List<CountItem>(countItemsInDB);
 
        }

        public void AddCountItem(CountItem newCountItem)
        {
            countDB.Items.InsertOnSubmit(newCountItem);
            countDB.SubmitChanges();
            AllCountItems.Add(newCountItem);
        }

        public void DeleteCountItem(int Id)
        {
            CountItem countForDelete = AllCountItems[Id];
            AllCountItems.Remove(countForDelete);
            countDB.Items.DeleteOnSubmit(countForDelete);
            countDB.SubmitChanges();
        }

        public void ModifyCountItem(int Id, CountItem countForModify)
        {
            CountItem tmpItem = AllCountItems[Id];
            tmpItem.CountName = countForModify.CountName;
            tmpItem.CountContent = countForModify.CountContent;
            tmpItem.CurrentTimes = countForModify.CurrentTimes;
            tmpItem.AllTimes = countForModify.AllTimes;

            IQueryable<CountItem> tmpItemQuery = from CountItem count in countDB.Items where count.CountItemId == tmpItem.CountItemId
                                                 select count;
            CountItem tmpItem1 = tmpItemQuery.FirstOrDefault();
            tmpItem1.CountName = countForModify.CountName;
            tmpItem1.CountContent = countForModify.CountContent;
            tmpItem1.CurrentTimes = countForModify.CurrentTimes;
            tmpItem1.AllTimes = countForModify.AllTimes;
            countDB.SubmitChanges();
        }
    }
}
