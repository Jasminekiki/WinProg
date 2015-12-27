//1252992 吴逸菲 ClockDataContext.cs 业务层——闹钟
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
    public class ClockItem : INotifyPropertyChanged, INotifyPropertyChanging
    {

        //
        // TODO: Add columns and associations, as applicable, here.
        //



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

        private int _clockItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ClockItemId
        {
            get { return _clockItemId; }
            set
            {
                if (_clockItemId != value)
                {
                    NotifyPropertyChanging("ClockItemId");
                    _clockItemId = value;
                    NotifyPropertyChanged("ClockItemId");
                }
            }
        }


        // Define completion value: private field, public property, and database column.
        private bool _isScheduled;

        [Column]
        public bool IsScheduled
        {
            get { return _isScheduled; }
            set
            {
                if (_isScheduled != value)
                {
                    NotifyPropertyChanging("IsComplete");
                    _isScheduled = value;
                    NotifyPropertyChanged("IsComplete");
                }
            }
        }

        private string _clockName;

        [Column]
        public string ClockName
        {
            get { return _clockName; }
            set
            {
                if (_clockName != value)
                {
                    NotifyPropertyChanging("ClockName");
                    _clockName = value;
                    NotifyPropertyChanging("ClockName");
                }
            }
        }

        private DateTime _clockTime;

        [Column]
        public DateTime ClockTime
        {
            get { return _clockTime; }
            set
            {
                if (_clockTime != value)
                {
                    NotifyPropertyChanging("ClockTime");
                    _clockTime = value;
                    NotifyPropertyChanged("ClockTime");
                }
            }
        }

        private int _repeatTime;

        [Column]
        public int RepeatTime
        {
            get { return _repeatTime; }
            set
            {
                if(_repeatTime != value)
                {
                    NotifyPropertyChanging("RepeatTime");
                    _repeatTime = value;
                    NotifyPropertyChanged("RepeatTime");
                }
            }
        }

        private bool _isRepeat;

        [Column]
        public bool IsRepeat
        {
            get { return _isRepeat; }
            set
            {
                if (_isRepeat != value)
                {
                    NotifyPropertyChanging("IsRepeat");
                    _isRepeat = value;
                    NotifyPropertyChanged("IsRepeat");
                }
            }
        }

        private int _musicId;

        [Column]
        public int MusicId
        {
            get { return _musicId; }
            set
            {
                if (_musicId != value)
                {
                    NotifyPropertyChanging("MusicId");
                    _musicId = value;
                    NotifyPropertyChanged("MusicId");
                }
            }
        }

    }

    public class ClockDataContext : DataContext
    {
        public ClockDataContext(string connectionString)
            : base(connectionString)
        { }
        public Table<ClockItem> Items;
    }

}

