//1252992 吴逸菲 CountDataContext.cs 业务层——倒计时
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DatePickerTest.Model
{
    [Table]
    public class CountItem : INotifyPropertyChanged, INotifyPropertyChanging
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

        // Define ID: private field, public property, and database column.
        private int _countItemId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int CountItemId
        {
            get { return _countItemId; }
            set
            {
                if (_countItemId != value)
                {
                    NotifyPropertyChanging("CountItemId");
                    _countItemId = value;
                    NotifyPropertyChanged("CountItemId");
                }
            }
        }

        private string _countName;

        [Column]
        public string CountName
        {
            get { return _countName; }
            set
            {
                if (_countName != value)
                {
                    NotifyPropertyChanging("CountName");
                    _countName = value;
                    NotifyPropertyChanged("CountName");

                }
            }
        }

        // Define completion value: private field, public property, and database column.
        private bool _isComplete;

        [Column]
        public bool IsComplete
        {
            get { return _isComplete; }
            set
            {
                if (_isComplete != value)
                {
                    NotifyPropertyChanging("IsComplete");
                    _isComplete = value;
                    NotifyPropertyChanged("IsComplete");
                }
            }
        }

        private string _countContent;

        [Column]
        public string CountContent
        {
            get { return _countContent; }
            set
            {
                if (_countContent != value)
                {
                    NotifyPropertyChanging("CountContent");
                    _countContent = value;
                    NotifyPropertyChanged("CountContent");
                }
            }
        }

        private int _allTimes;

        [Column]
        public int AllTimes
        {
            get { return _allTimes; }
            set
            {
                if(_allTimes != value)
                {
                    NotifyPropertyChanging("AllTimes");
                    _allTimes = value;
                    NotifyPropertyChanged("AllTimes");
                }
            }
        }

        private int _curTimes;

        [Column]
        public int CurrentTimes
        {
            get { return _curTimes; }
            set
            {
                if (_curTimes != value)
                {
                    NotifyPropertyChanging("CurrentTimes");
                    _curTimes = value;
                    NotifyPropertyChanged("CurrentTimes");
                }
            }
        }
    }

    public class CountDataContext : DataContext
    {
        public CountDataContext(string connectionString)
            : base(connectionString)
        { }
        public Table<CountItem> Items;
    }
}
