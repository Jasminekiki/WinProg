using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatePickerTest.Model
{
   [Table]
   public class DiaryItem: INotifyPropertyChanging,INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion

        private int _diaryItemId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType ="INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int DiaryItemId
        {
            get { return _diaryItemId; }
            set
            {
                if (_diaryItemId != value)
                {
                    NotifyPropertyChanging("DiaryItemId");
                    _diaryItemId = value;
                    NotifyPropertyChanged("DiaryItemId");
                }
            }
        }

        private string _diaryTitle;
        [Column]
        public string DiaryTitle
        {
            get { return _diaryTitle; }
            set
            {
                if (_diaryTitle != value)
                {
                    NotifyPropertyChanging("DiaryTitle");
                    _diaryTitle = value;
                    NotifyPropertyChanged("DiaryTitle");
                }
            }
        }

        private int _moodTag;

        [Column]
        public int MoodTag
        {
            get { return _moodTag; }
            set
            {
                if (_moodTag !=value)
                {
                    NotifyPropertyChanging("MoodTag");
                    _moodTag = value;
                    NotifyPropertyChanged("MoodTag");
                }
            }
        }

        private string _diaryContent;

        [Column]
        public string DiaryContent
        {
            get { return _diaryContent; }
            set
            {
                if (_diaryContent != value)
                {
                    NotifyPropertyChanging("DiaryContent");
                    _diaryContent = value;
                    NotifyPropertyChanged("DiaryContent");
                }
            }
        }


        private DateTime _diaryTime;

        [Column]
        public DateTime DiaryTime
        {
            get { return _diaryTime; }
            set
            {
                if (_diaryTime != value)
                {
                    NotifyPropertyChanging("DiaryTime");
                    _diaryTime = value;
                    NotifyPropertyChanged("DiaryTime");
                }
            }
        }
    }

    public class DiaryDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public DiaryDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<DiaryItem> Items;

    }
}
