//1252992 吴逸菲 DefaultPage.xaml.cs 主界面设计
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DatePickerTest.Model;
using Microsoft.Phone.Scheduler;
using System.Windows.Media.Imaging;

namespace DatePickerTest
{

    public partial class DefaultPage : PhoneApplicationPage
    {

        public DefaultPage()
        {
            InitializeComponent();          
            AddItems();
        }

       /*private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Tasks.SmsComposeTask sms = new Microsoft.Phone.Tasks.SmsComposeTask();
            sms.To = "13672265138";
            sms.Body = "你好啊，今天中午请我吃牛肉炒饭吗？";
            sms.Show();  
        }*/

        private void AddItems()//listbox里面加显示内容，根据ListPicker选中项修改,这里示范用50个数字
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    ListBoxItem item = new ListBoxItem();
            //    TextBlock textBlock = new TextBlock();
            //    textBlock.Text = i.ToString();
            //    item.Content = textBlock;
            //    ListBox1.Items.Add(item);
            //}
            App.selectedIndex = -1;
            //            if(this.ListPicker1.SelectedIndex == 0 && selectedPart !=0)
            //            {
            //                this.ListPicker1.SelectedIndex = selectedPart;
            //                
            //            }
            if (this.ListPicker1.SelectedIndex == 0)//选中任务事项，
            {

                while (ListBox1.Items.Count != 0)
                {
                    this.ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1);
                }
                this.DataContext = App.ViewModel;
                List<TaskItem> taskItems = App.ViewModel.AllDataItems;
                for (int i = 0; i < taskItems.Count; i++)
                {
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.White);

                    border.Margin = new Thickness(5);

                    border.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                    TaskItem item = taskItems[i];
                    int id = item.TaskId;
                    string name = item.TaskName;
                    string alarmTime = item.TaskAlarm.ToString();
                    string schedule;
                    if (item.IsScheduled)
                    {
                        schedule = "是";
                    }
                    else
                    {
                        schedule = "否";
                    }
                    string text = name + "\n是否启用提醒功能：" + schedule + "\n提醒时间：" + alarmTime;
                    ListBoxItem listItem = new ListBoxItem();
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = text;
                    textBlock.FontSize = 25;
                    textBlock.Foreground = new SolidColorBrush(Colors.Black);
                    border.Child = textBlock;
                    listItem.Content = border;
                    ListBox1.Items.Add(listItem);
                }

            }
            else if (this.ListPicker1.SelectedIndex == 1)
            {
                while (ListBox1.Items.Count != 0)
                {
                    this.ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1);
                }

                this.DataContext = App.ClViewModel;
                List<ClockItem> clockItems = App.ClViewModel.AllClockItems;
                for (int i = 0; i < clockItems.Count; i++)
                {
                    ClockItem clitem = clockItems[i];
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.White);

                    border.Margin = new Thickness(5);

                    border.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                    int clid = clitem.ClockItemId;
                    ScheduledAction a = ScheduledActionService.Find("clock" + clid.ToString());
                    string clname = clitem.ClockName;

                    string cltime;
                    if (a != null)
                    {
                        cltime = a.ExpirationTime.ToString();
                    }
                    else
                    {
                        cltime = clitem.ClockTime.ToString();
                    }

                    string isScheduled;
                    if (clitem.IsScheduled)
                    {
                        isScheduled = "是";
                    }
                    else
                    {
                        isScheduled = "否";
                    }
                    string cltext = clname + "\n闹铃时间：" + cltime + "\n是否启用：" + isScheduled;

                    ListBoxItem cllistItem = new ListBoxItem();
                    TextBlock cltextBlock = new TextBlock();
                    cltextBlock.Foreground = new SolidColorBrush(Colors.Black);

                    cltextBlock.FontSize = 25;
                    cltextBlock.Text = cltext;
                    border.Child = cltextBlock;
                    cllistItem.Content = border;

                    ListBox1.Items.Add(cllistItem);
                }

            }
            else if (this.ListPicker1.SelectedIndex == 2)
            {
                while (ListBox1.Items.Count != 0)
                {
                    this.ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1);
                }
                this.DataContext = App.CViewModel;
                List<CountItem> countItems = App.CViewModel.AllCountItems;
                for (int i = 0; i < countItems.Count; i++)
                {
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.White);
                    border.Margin = new Thickness(5);
                    border.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                    CountItem citem = countItems[i];
                    int cid = citem.CountItemId;
                    string cname = citem.CountName;
                    string allTime = citem.AllTimes.ToString();
                    string curTime = citem.CurrentTimes.ToString();
                    string ctext = cname + "\n总次数： " + allTime + "  当前次数： " + curTime;
                    ListBoxItem clistItem = new ListBoxItem();
                    TextBlock ctextBlock = new TextBlock();
                    ctextBlock.FontSize = 30;
                    ctextBlock.Foreground = new SolidColorBrush(Colors.Black);
                    ctextBlock.Text = ctext;

                    border.Child = ctextBlock;

                    clistItem.Content = border;
                    ListBox1.Items.Add(clistItem);
                }

            }
            else if (this.ListPicker1.SelectedIndex ==3)
            {
                while (ListBox1.Items.Count != 0)
                {
                   this.ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1);
                }
                this.DataContext = App.DViewModel;
                List<DiaryItem> diaryItems = App.DViewModel.AllDataItems;
                int k = diaryItems.Count;
                for (int i = 0; i < diaryItems.Count; i++)
                {
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.White);
                    border.Margin = new Thickness(5);

                    border.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                    DiaryItem ditem = diaryItems[i];
                    string dname = ditem.DiaryTitle;
                    DateTime dtime = ditem.DiaryTime;
                    string dtext = " " + dname + "\n " + dtime.ToString("yyyy-MM-dd HH:mm:ss");
                    ListBoxItem dlistItem = new ListBoxItem();
                    TextBlock dtextBlock = new TextBlock();
                    dtextBlock.FontSize = 30;
                    dtextBlock.Foreground = new SolidColorBrush(Colors.Black);
                    dtextBlock.Text = dtext;
                    Grid grid = new Grid();
                    grid.HorizontalAlignment = HorizontalAlignment.Left;
                    //grid.Height = 90;
                    //First Column -- Diary Tag
                    ColumnDefinition firstColumn = new ColumnDefinition();
                    firstColumn.Width = new GridLength(90, GridUnitType.Pixel);
                    grid.ColumnDefinitions.Add(firstColumn);

                    //Second Column -- Text
                    ColumnDefinition secondColumn = new ColumnDefinition();
                    secondColumn.Width = new GridLength(550, GridUnitType.Pixel);
                    grid.ColumnDefinitions.Add(secondColumn);

                    //Add UI elements to Grid
                    Grid.SetColumn(dtextBlock, 1);
                    string[] tagArray = { "/Images/c.png", "/Images/a.png", "/Images/b.png", "/Images/d.png", "/Images/e.png" };
                    Uri tagImage = new Uri(tagArray[ditem.MoodTag], UriKind.Relative);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.UriSource = tagImage;
                    Image image = new Image();
                    image.Source = bitmapImage;
                    Grid.SetColumn(image, 0);
                    grid.Children.Add(dtextBlock);
                    grid.Children.Add(image);
                    border.Child = grid;

                    dlistItem.Content = border;
                    ListBox1.Items.Add(dlistItem);
                }

            }

        }
        private void listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddItems();
            if (this.ListPicker1.SelectedIndex == 4)
            {
                //               this.edit.IsEnabled = false;
                //               this.delete.IsEnabled = false;
                //               this.ListBox1.Items.Clear();
                this.NavigationService.Navigate(new Uri("/Radio/Radio.xaml", UriKind.Relative));
            }              
            this.ListPicker1.SelectionChanged += new SelectionChangedEventHandler(listPicker_SelectionChanged);
            
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // 传递的参数叫什么名字，这里就按什么名字来取。  
           // string pv = this.NavigationContext.QueryString["str"];
            
        }



        private void Button_Click(object sender, EventArgs e)
        {
            App.selectedIndex = -1;
            if (this.ListPicker1.SelectedIndex == 0)//选中任务事项，跳转到任务界面
            {
                this.NavigationService.Navigate(new Uri("/Task.xaml",UriKind.Relative));
            }
            if (this.ListPicker1.SelectedIndex == 1)//选中闹铃事项，跳转到闹铃界面
            {
                this.NavigationService.Navigate(new Uri("/Clock.xaml", UriKind.Relative));
            }
            if (this.ListPicker1.SelectedIndex == 2)//选中倒计时事项，跳转到倒计时界面
            {
                this.NavigationService.Navigate(new Uri("/CountDown.xaml", UriKind.Relative));
            }
            if (this.ListPicker1.SelectedIndex == 3)//选中日记事项，跳转到日记界面
            {
                this.NavigationService.Navigate(new Uri("/DiaryView/EditDiary.xaml", UriKind.Relative));
            }
            if (this.ListPicker1.SelectedIndex == 4)//选中录音事项，跳转到录音界面
            {
                this.NavigationService.Navigate(new Uri("/Radio/Radio.xaml", UriKind.Relative));
            }
            

        }
        /*       private void ListItem_Hold(object sender, GestureEventArgs e)
               {
                   App.selectedIndex = this.ListBox1.SelectedIndex;
               }
       */

        private void ModifyItem_Click(object sender, EventArgs e)
        {
            if (this.ListPicker1.SelectedIndex == 0)
            {
                this.NavigationService.Navigate(new Uri("/Task.xaml", UriKind.Relative));
            }
            else if (this.ListPicker1.SelectedIndex == 1)
            {
                this.NavigationService.Navigate(new Uri("/Clock.xaml", UriKind.Relative));
            }
            else if (this.ListPicker1.SelectedIndex == 2)
            {
                this.NavigationService.Navigate(new Uri("/CountDown.xaml", UriKind.Relative));
            }
            else if (this.ListPicker1.SelectedIndex == 3)
            {
                if (App.selectedIndex != -1)
                {
                    DiaryItem ditem = App.DViewModel.AllDataItems[App.selectedIndex];
                    if (ditem.DiaryTime.Date != DateTime.Today.Date)
                    {
                        MessageBox.Show("This Diary is the memory of past life~Please don't change it~ ");
                        this.NavigationService.Navigate(new Uri("/DiaryView/ViewDiary.xaml", UriKind.Relative));
                    }
                    else
                        this.NavigationService.Navigate(new Uri("/DiaryView/EditDiary.xaml", UriKind.Relative));
                }
                else
                {
                    this.NavigationService.Navigate(new Uri("/DiaryView/EditDiary.xaml", UriKind.Relative));
                }

            }
            else if (this.ListPicker1.SelectedIndex == 4)
            {
                this.NavigationService.Navigate(new Uri("/Radio/Radio.xaml", UriKind.Relative));
            }
           

        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if(App.selectedIndex == -1)
            {
                MessageBox.Show("请选择一个条目！");
                return;
            }
            if (this.ListPicker1.SelectedIndex == 0)
            {
               // this.ListBox1.Items.RemoveAt(App.selectedIndex);
                TaskItem deleteTask = App.ViewModel.AllDataItems[App.selectedIndex];
                if (deleteTask.IsScheduled)
                {
                    string name = "task" + App.ViewModel.AllDataItems[App.selectedIndex].TaskId.ToString();
                    ScheduledActionService.Remove(name);
                }        
                App.ViewModel.DeleteDataItem(App.selectedIndex);
 
            }
            else if (this.ListPicker1.SelectedIndex == 1)
            {
              //  this.ListBox1.Items.RemoveAt(App.selectedIndex);
                ClockItem clockItem = App.ClViewModel.AllClockItems[App.selectedIndex];
                if (clockItem.IsScheduled)
                {
                    string clname = "clock" + App.ClViewModel.AllClockItems[App.selectedIndex].ClockItemId.ToString();
                    ScheduledActionService.Remove(clname);
                }

                App.ClViewModel.DeleteClockItem(App.selectedIndex);
            }
            else if (this.ListPicker1.SelectedIndex == 2)
            {
               // this.ListBox1.Items.RemoveAt(App.selectedIndex);
                App.CViewModel.DeleteCountItem(App.selectedIndex);
            }
            else if (this.ListPicker1.SelectedIndex == 4)
            {
              //  this.ListBox1.Items.RemoveAt(App.selectedIndex);
                App.DViewModel.DeleteDataItem(App.selectedIndex);

            }
            this.ListBox1.Items.RemoveAt(App.selectedIndex);
            App.selectedIndex = -1;
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedIndex = this.ListBox1.SelectedIndex;         
        }


    }
}