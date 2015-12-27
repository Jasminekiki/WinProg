//1252992 吴逸菲 CountDown.xaml.cs 倒计时界面设计
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

namespace DatePickerTest
{
    public partial class CountDown : PhoneApplicationPage
    {
        public CountDown()
        {
            InitializeComponent();
            this.DataContext = App.CViewModel;
            if (App.selectedIndex != -1)
            {
                CountItem viewItem = App.CViewModel.AllCountItems[App.selectedIndex];
                this.countName.Text = viewItem.CountName;
                this.countContent.Text = viewItem.CountContent;
                this.allTime.Text = viewItem.AllTimes.ToString();
                this.curTime.Text = viewItem.CurrentTimes.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)// 取消倒计时创建
        {
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//倒计时创建，数据库录入，更新DefaultPage
        {
            string countName = this.countName.Text;
            string countContent = this.countContent.Text;
            try
            {
                int allTime = int.Parse(this.allTime.Text);
                int curTime = int.Parse(this.curTime.Text);

                CountItem newCountItem = new CountItem
                {
                    CountName = countName,
                    CountContent = countContent,
                    AllTimes = allTime,
                    CurrentTimes = curTime
                };
                if (curTime > allTime || curTime < 0 || allTime < 0)
                {
                    MessageBox.Show("次数输入不符合规范，请重新输入！");
                    return;
                }
                if (App.selectedIndex == -1)
                {
                    App.CViewModel.AddCountItem(newCountItem);

                    this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
                    MessageBox.Show("倒计时创建成功！");
                    if (allTime == curTime)
                    {
                        MessageBox.Show("注意：您的任务倒计时次数已经用完！");
                    }
                }
                else
                {
                    App.CViewModel.ModifyCountItem(App.selectedIndex, newCountItem);
                    this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
                    MessageBox.Show("倒计时修改成功！");
                    if (allTime == curTime)
                    {
                        MessageBox.Show("注意：您的任务倒计时次数已经用完！");
                    }
                }
            }
            catch (FormatException excption)
            {
                MessageBox.Show("次数输入不符合规范，请重新输入！");
                return;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string allTime = this.allTime.Text;
            int num = int.Parse(allTime);
            num = num + 1;
            this.allTime.Text = num.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string allTime = this.allTime.Text;
            int num = int.Parse(allTime);
            num = num - 1;
            this.allTime.Text = num.ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string curTime = this.curTime.Text;
            int num = int.Parse(curTime);
            num = num + 1;
            this.curTime.Text = num.ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string curTime = this.curTime.Text;
            int num = int.Parse(curTime);
            num = num - 1;
            this.curTime.Text = num.ToString();
        }
    }
}