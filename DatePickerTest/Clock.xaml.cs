//1252992 吴逸菲 Clock.xaml.cs 闹钟界面设计
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DatePickerTest.Model;
using Microsoft.Phone.Scheduler;

namespace DatePickerTest
{
    public partial class Clock : PhoneApplicationPage
    {
        // static readonly string[] Days = { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "每天" };

         public class DayList
         {
             public string name { get; set; } // 天名称
             
             public string color { get; set; }// 颜色值
         }

         public void InitListPicker()
         {
             string[] AccentColors = { "#FFBAE57D", "purple", "teal", "#FF98D0CA", "brown", "pink", "#FF15D1A2", "blue","#FF000000" };
             List<DayList> list = new List<DayList>();
             Random random = new Random();
             list.Add(new DayList() { name = "星期日", color = AccentColors[0] });
             list.Add(new DayList() { name = "星期一", color = AccentColors[1] });
             list.Add(new DayList() { name = "星期二", color = AccentColors[2] });
             list.Add(new DayList() { name = "星期三", color = AccentColors[3] });
             list.Add(new DayList() { name = "星期四", color = AccentColors[4] });
             list.Add(new DayList() { name = "星期五", color = AccentColors[5] });
             list.Add(new DayList() { name = "星期六", color = AccentColors[6] });
             list.Add(new DayList() { name = "每天", color = AccentColors[7] });
           
             DayPicker.ItemsSource = list;
         }
        public Clock()
        {
            InitializeComponent();
            this.DataContext = App.ClViewModel;
            InitListPicker();
            if (App.selectedIndex != -1)
            {
                ClockItem viewItem = App.ClViewModel.AllClockItems[App.selectedIndex];
                this.clockName.Text = viewItem.ClockName;
                this.clockTime.Value = viewItem.ClockTime;
                this.isRepeat.IsChecked = viewItem.IsRepeat;
                this.DayPicker.SelectedIndex = viewItem.RepeatTime;
                this.musicId.SelectedIndex = viewItem.MusicId;
                this.alarmSwitch.IsChecked = viewItem.IsScheduled;
                if (viewItem.IsScheduled)
                {
                    this.alarmSwitch.Content = "是";
                }
                else 
                {
                    this.alarmSwitch.Content = "否";
                }
            }
        }

        //实现日期多选选项
       

        private void Button_Click(object sender, RoutedEventArgs e)// 取消闹铃创建
        {
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml",UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//确认闹铃创建，处理数据存储，并且更新defaultPage
        {
            string clockName = this.clockName.Text;
            DateTime clockTime = (DateTime)this.clockTime.Value;
            bool isRepeat =(bool)this.isRepeat.IsChecked;
            int repeatTime = this.DayPicker.SelectedIndex;
            int musicId = this.musicId.SelectedIndex;
            bool isScheduled = this.alarmSwitch.IsChecked.Value;

            int size = 0;
            for (int i = 0; i < App.ClViewModel.AllClockItems.Count; i++)
            {
                ClockItem maxItem = App.ClViewModel.AllClockItems[i];
                if (size < maxItem.ClockItemId)
                {
                    size = maxItem.ClockItemId;
                }
            }
            ClockItem newClockItem = new ClockItem
            {
                ClockItemId = size+1,
                ClockName = clockName,
                ClockTime = clockTime,
                IsRepeat = isRepeat,
                RepeatTime = repeatTime,
                MusicId = musicId,
                IsScheduled = isScheduled
            };

            if (App.selectedIndex == -1)
            {
                App.ClViewModel.AddClockItem(newClockItem);
                if (this.alarmSwitch.IsChecked.Value)
                {

                    string name = "clock" + newClockItem.ClockItemId.ToString();
                    Alarm alarm = new Alarm(name);
                    alarm.Content = newClockItem.ClockName;
                    string[] soundArray = { "/Ringtones/takeMe.mp3", "/Ringtones/littleApple.mp3", "/Ringtones/yiYongJun.mp3" };
                    alarm.Sound = new Uri(soundArray[newClockItem.MusicId], UriKind.Relative);
                    if (newClockItem.RepeatTime != 7)
                    {
                        DateTime tmpDate = newClockItem.ClockTime;
                        int dayWeek = (int)tmpDate.DayOfWeek;
                        int realDay = 0;
                        if (newClockItem.RepeatTime == 0)
                        {
                            realDay = 7;
                        }
                        else
                        {
                            realDay = newClockItem.RepeatTime;
                        }
                        int distance = realDay - dayWeek;
                        if (distance < 0)
                        {
                            distance = distance + 7;
                        }
                        DateTime tmpDate1 = tmpDate.AddDays(distance);
                        alarm.BeginTime = tmpDate1;
                        alarm.ExpirationTime = tmpDate1;
                        if (newClockItem.IsRepeat)
                        {
                            alarm.RecurrenceType = RecurrenceInterval.Weekly;
                        }
                        else
                        {
                            alarm.RecurrenceType = RecurrenceInterval.None;
                        }

                    }
                    else
                    {
                        alarm.BeginTime = newClockItem.ClockTime;
                        alarm.ExpirationTime = newClockItem.ClockTime;
                        alarm.RecurrenceType = RecurrenceInterval.Daily;
                    }
                    if (alarm.ExpirationTime < DateTime.Now)
                    {
                        MessageBox.Show("闹钟时间不能小于当前时间！");
                        return;
                    }
                    ScheduledActionService.Add(alarm);
                }

                this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
                MessageBox.Show("闹铃创建成功！");
            }
            else 
            {

                string name1 = "clock" + App.ClViewModel.AllClockItems[App.selectedIndex].ClockItemId.ToString();
                ScheduledAction tmpAction = ScheduledActionService.Find(name1);
                if (tmpAction != null)
                {

                    ScheduledActionService.Remove(name1);
                }
                if (newClockItem.IsScheduled)
                {

                    Alarm alarm = new Alarm(name1);
                    alarm.Content = newClockItem.ClockName;
                    string[] soundArray = { "/Ringtones/TakeMe.mp3", "/Ringtones/PianAi.mp3", "/Ringtones/SweetThanFiction.mp3" };
                    alarm.Sound = new Uri(soundArray[newClockItem.MusicId], UriKind.Relative);
                    if (newClockItem.RepeatTime != 7)
                    {
                        DateTime tmpDate = newClockItem.ClockTime;
                        int dayWeek = (int)tmpDate.DayOfWeek;
                        int realDay = 0;
                        if (newClockItem.RepeatTime == 0)
                        {
                            realDay = 7;
                        }
                        else
                        {
                            realDay = newClockItem.RepeatTime;
                        }
                        int distance = realDay - dayWeek;
                        if (distance < 0)
                        {
                            distance = distance + 7;
                        }
                        DateTime tmpDate1 = tmpDate.AddDays(distance);
                        alarm.BeginTime = tmpDate1;
                        alarm.ExpirationTime = tmpDate1;
                        if (newClockItem.IsRepeat)
                        {
                            alarm.RecurrenceType = RecurrenceInterval.Weekly;
                        }
                        else
                        {
                            alarm.RecurrenceType = RecurrenceInterval.None;
                        }

                    }
                    else
                    {
                        alarm.ExpirationTime = newClockItem.ClockTime;
                        alarm.BeginTime = newClockItem.ClockTime;
                        alarm.RecurrenceType = RecurrenceInterval.Daily;
                    }
                    if (alarm.ExpirationTime < DateTime.Now)
                    {
                        MessageBox.Show("闹钟时间不能小于当前时间！");
                        return;
                    }
                    ScheduledActionService.Add(alarm);
                }


                App.ClViewModel.ModifyClockItem(App.selectedIndex, newClockItem);
                this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
                MessageBox.Show("闹铃修改成功！");
            }
        }

        private void alarmSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.alarmSwitch.IsChecked.Value)
            {
                this.alarmSwitch.Content = "是";
            }
            else 
            {
                this.alarmSwitch.Content = "否";
            }
        }

        
  
       
    }
}