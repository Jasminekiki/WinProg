//1252992 吴逸菲 ClockViewContext.cs 视图——闹钟
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
    public class ClockViewModel:INotifyPropertyChanged
    {
              // LINQ to SQL data context for the local database.
        private ClockDataContext clockDB;

        // Class constructor, create the data context object.
        public ClockViewModel(string clockDBConnectionString)
        {
            clockDB = new ClockDataContext(clockDBConnectionString);
        }

        //
        // TODO: Add collections, list, and methods here.
        //

        // Write changes in the data context to the database.
        public void SaveChangesToDB()
        {
            clockDB.SubmitChanges();
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

        private List<ClockItem> _allClockItems;
        public List<ClockItem> AllClockItems
        {
            get { return _allClockItems; }
            set
            {
                _allClockItems = value;
                NotifyPropertyChanged("AllClockItems");
            }
        }

        public void LoadCollectionFromDatabase()
        {
            var clockItemsInDB = from ClockItem clk in clockDB.Items
                                 select clk;
            AllClockItems = new List<ClockItem>(clockItemsInDB);
        }

        public void AddClockItem(ClockItem newClockItem)
        {
            clockDB.Items.InsertOnSubmit(newClockItem);
            clockDB.SubmitChanges();
            AllClockItems.Add(newClockItem);
        }

        public void DeleteClockItem(int Id)
        {
            ClockItem clockForDelete = AllClockItems[Id];
            AllClockItems.Remove(clockForDelete);
            clockDB.Items.DeleteOnSubmit(clockForDelete);
            clockDB.SubmitChanges();
        }

        public void ModifyClockItem(int Id, ClockItem clockForModify)
        {
            ClockItem tmpItem = AllClockItems[Id];
            tmpItem.ClockName = clockForModify.ClockName;
            tmpItem.ClockTime = clockForModify.ClockTime;
            tmpItem.IsRepeat = clockForModify.IsRepeat;
            tmpItem.RepeatTime = clockForModify.RepeatTime;
            tmpItem.MusicId = clockForModify.MusicId;
            tmpItem.IsScheduled = clockForModify.IsScheduled;
            IQueryable<ClockItem> clockQuery = from ClockItem clk in clockDB.Items where clk.ClockItemId == tmpItem.ClockItemId
                                               select clk;
            ClockItem tmpItem1 = clockQuery.FirstOrDefault();
            tmpItem1.ClockName = clockForModify.ClockName;
            tmpItem1.ClockTime = clockForModify.ClockTime;
            tmpItem1.IsRepeat = clockForModify.IsRepeat;
            tmpItem1.RepeatTime = clockForModify.RepeatTime;
            tmpItem1.MusicId = clockForModify.MusicId;
            tmpItem1.IsScheduled = clockForModify.IsScheduled;
            clockDB.SubmitChanges();

        }
    }
}
