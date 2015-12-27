//1252992 吴逸菲 TaskDataContext.cs 业务层——任务
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
    public class TaskItem : INotifyPropertyChanged, INotifyPropertyChanging
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
        private int _taskId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int TaskId
        {
            get { return _taskId; }
            set
            {
                if (_taskId != value)
                {
                    NotifyPropertyChanging("ItemId");
                    _taskId = value;
                    NotifyPropertyChanged("ItemId");
                }
            }
        }

        // Define item name: private field, public property, and database column.
        private string _taskName;

        [Column]
        public string TaskName
        {
            get { return _taskName; }
            set
            {
                if (_taskName != value)
                {
                    NotifyPropertyChanging("ItemName");
                    _taskName = value;
                    NotifyPropertyChanged("ItemName");
                }
            }
        }

        private string _taskContent;

        [Column]
        public string TaskContent
        {
            get { return _taskContent; }
            set 
            {
                if (_taskContent != value)
                {
                    NotifyPropertyChanging("ItemContent");
                    _taskContent = value;
                    NotifyPropertyChanged("ItemContent");
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

        private DateTime _taskBegin;

        [Column]
        public DateTime TaskBegin
        {
            get { return _taskBegin; }
            set 
            {
                if (_taskBegin != value)
                {
                    NotifyPropertyChanging("TaskBegin");
                    _taskBegin = value;
                    NotifyPropertyChanged("TaskBegin");
                }
            }
        }

        private DateTime _taskAlarm;

        [Column]
        public DateTime TaskAlarm
        {
            get { return _taskAlarm; }
            set 
            {
                if (_taskAlarm != value)
                {
                    NotifyPropertyChanging("TaskAlarm");
                    _taskAlarm = value;
                    NotifyPropertyChanged("TaskAlarm");
                }
            }
        }

        private DateTime _taskEnd;

        [Column]
        public DateTime TaskEnd
        {
            get { return _taskEnd; }
            set
            {
                if(_taskEnd != value)
                {
                    NotifyPropertyChanging("TaskEnd");
                    _taskEnd = value;
                    NotifyPropertyChanged("TaskEnd");
                }
            }
        }

    }

    public class TaskDataContext : DataContext
    {
        // Pass the connection string to the base class.
        public TaskDataContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a table for the to-do items.
        public Table<TaskItem> Items;

    }
}


