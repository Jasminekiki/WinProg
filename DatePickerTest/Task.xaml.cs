//1252992 吴逸菲 Task.xaml.cs 任务界面设计
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using DatePickerTest.Model;
using Microsoft.Phone.Scheduler;

namespace DatePickerTest
{
    public partial class Task : PhoneApplicationPage
    {
        public Task()
        {
            InitializeComponent();
            this.DataContext = App.ViewModel;
            if (App.selectedIndex != -1)
            {
                TaskItem viewItem = App.ViewModel.AllDataItems[App.selectedIndex];
                this.taskName.Text = viewItem.TaskName;
                this.taskContent.Text = viewItem.TaskContent;
                this.beginDate.Value = viewItem.TaskBegin.Date;
                this.beginTime.Value = viewItem.TaskBegin;
                this.endDate.Value = viewItem.TaskEnd.Date;
                this.endTime.Value = viewItem.TaskEnd;
                this.alarmDate.Value = viewItem.TaskAlarm.Date;
                this.alarmTime.Value = viewItem.TaskAlarm;
                if(viewItem.IsScheduled)
                {
                    this.alarmOn.IsChecked = true;
                    this.alarmDate.IsEnabled = true;
                    this.alarmTime.IsEnabled = true;
                    this.alarmOn.Content = "是";
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)//取消创建任务，回到DefaultPage
        {
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//确认创建任务，将数据存到数据结构中，并更新DefaultPage内容
        {
            DateTime beginDate = (DateTime)this.beginDate.Value;
            DateTime beginTime = (DateTime)this.beginTime.Value;
            DateTime dtBegin = beginDate + beginTime.TimeOfDay;

            DateTime endDate = (DateTime)this.endDate.Value;
            DateTime endTime = (DateTime)this.endTime.Value;
            DateTime dtEnd = endDate + endTime.TimeOfDay;

            DateTime alarmDate = (DateTime)this.alarmDate.Value;
            DateTime alarmTime = (DateTime)this.alarmTime.Value;
            DateTime dtAlarm = alarmDate + alarmTime.TimeOfDay;

            bool isScheduled;
            if (this.alarmOn.IsChecked.Value)
            {
                isScheduled = true;
            }
            else
            {
                isScheduled = false;
            }

            int size = 0;
            for (int i = 0; i < App.ViewModel.AllDataItems.Count; i++)
            {
                TaskItem maxItem = App.ViewModel.AllDataItems[i];
                if (size < maxItem.TaskId)
                {
                    size = maxItem.TaskId;
                }
            }

            TaskItem newTaskItem = new TaskItem
            {
                TaskId = size+1,
                TaskName = this.taskName.Text,
                TaskContent = this.taskContent.Text,
                TaskBegin = dtBegin,
                TaskEnd = dtEnd,
                TaskAlarm = dtAlarm,
                IsScheduled = isScheduled

            };
            if (App.selectedIndex == -1)
            {
                Reminder reminder = new Reminder("task" + newTaskItem.TaskId.ToString());
                
                if (newTaskItem.IsScheduled)
                {
                    if (dtBegin < DateTime.Now)
                    {
                        MessageBox.Show("开始时间不能小于当前时间！");
                        return;
                    }
                    if (dtAlarm < dtBegin)
                    {
                        MessageBox.Show("提醒时间不能小于开始时间！");
                        return;
                    }
                    
                    reminder.Title = newTaskItem.TaskName;
                    reminder.Content = newTaskItem.TaskContent;
                    reminder.BeginTime = newTaskItem.TaskBegin;
                    reminder.ExpirationTime = newTaskItem.TaskAlarm;
                    reminder.RecurrenceType = RecurrenceInterval.None;
                    

                }
                if (dtEnd < dtBegin)
                {
                    MessageBox.Show("结束时间不能小于开始时间！");
                    return;
                }

                App.ViewModel.AddDataItem(newTaskItem);
                if (newTaskItem.IsScheduled)
                {
                    ScheduledActionService.Add(reminder);
                }
                this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));

                MessageBox.Show("任务创建成功！");
            }
            else
            {

                TaskItem formerItem = App.ViewModel.AllDataItems[App.selectedIndex];
                string name = "task" + formerItem.TaskId.ToString();
                ScheduledAction tmpAction = ScheduledActionService.Find(name);
                if (tmpAction != null)
                {
                    ScheduledActionService.Remove(name);
 
                }             
                Reminder reminder = new Reminder(name);
                if (newTaskItem.IsScheduled)
                {
                    if (dtBegin < DateTime.Now)
                    {
                        MessageBox.Show("开始时间不能小于当前时间！");
                        return;
                    }
                    if (dtAlarm < dtBegin)
                    {
                        MessageBox.Show("提醒时间不能小于开始时间！");
                        return;
                    }
                    
                    reminder.Title = newTaskItem.TaskName;
                    reminder.Content = newTaskItem.TaskContent;
                    reminder.BeginTime = newTaskItem.TaskBegin;
                    reminder.ExpirationTime = newTaskItem.TaskAlarm;
                    reminder.RecurrenceType = RecurrenceInterval.None;
                    
                   

                }
                if (dtEnd < dtBegin)
                {
                    MessageBox.Show("结束时间不能小于开始时间！");
                    return;
                }

                App.ViewModel.ModifyDataItem(App.selectedIndex, newTaskItem);
                if (newTaskItem.IsScheduled)
                {
                    ScheduledActionService.Add(reminder);
                }
                this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
                MessageBox.Show("任务修改成功！");


            }

        }

        private void alarmOn_Click(object sender, RoutedEventArgs e)
        {
            if (this.alarmOn.IsChecked.Value)
            {
                this.alarmDate.IsEnabled = true;
                this.alarmTime.IsEnabled = true;
                this.alarmOn.Content = "是";
            }
            else
            {
                this.alarmDate.IsEnabled = false;
                this.alarmTime.IsEnabled = false;
                this.alarmOn.Content = "否";
            }

        }




    }

}