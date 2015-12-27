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

namespace DatePickerTest.DiaryView
{
    public partial class EditDiary : PhoneApplicationPage
    {
        public class tagList
        {
            public string tagName { get; set; } 

            public string tagUri { get; set; }
        }
        public void InitListPicker()
        {
            string[] tagUris = { "/Images/c.png", "/Images/a.png", "/Images/b.png", "/Images/d.png", "/Images/e.png" };
            List<tagList> list = new List<tagList>();
            Random random = new Random();
            list.Add(new tagList() { tagName = "So So", tagUri = tagUris[0] });
            list.Add(new tagList() { tagName = "Extremely Happy", tagUri = tagUris[1] });
            list.Add(new tagList() { tagName = "Happy", tagUri = tagUris[2] });
            list.Add(new tagList() { tagName = "Sad", tagUri = tagUris[3] });
            list.Add(new tagList() { tagName = "Angry", tagUri = tagUris[4] });

            moodPicker.ItemsSource = list;
        }
        public EditDiary()
        {
            InitializeComponent();
            this.DataContext = App.DViewModel;
            InitListPicker();
            this.time.Text = DateTime.Now.ToString();
            if (App.selectedIndex != -1 )
            {
                DiaryItem ditem = App.DViewModel.AllDataItems[App.selectedIndex];
                this.TitleText.Text = ditem.DiaryTitle;
                this.Content.Text = ditem.DiaryContent;
                this.moodPicker.SelectedIndex = ditem.MoodTag;
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int size = 0;
            for (int i = 0; i < App.DViewModel.AllDataItems.Count; i++)
            {
                DiaryItem maxItem = App.DViewModel.AllDataItems[i];
                if (size < maxItem.DiaryItemId)
                {
                    size = maxItem.DiaryItemId;
                }
            }
            DiaryItem newItem = new DiaryItem
            {
                DiaryItemId = size + 1,
                DiaryTitle = this.TitleText.Text,
                DiaryContent = this.Content.Text,
                MoodTag = this.moodPicker.SelectedIndex,
                DiaryTime = DateTime.Now,
             };
            if(App.selectedIndex == -1)
            {
                App.DViewModel.AddDataItem(newItem);
            }
            else
            {
                App.DViewModel.ModifyDataItem(App.selectedIndex, newItem);
            }
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
            MessageBox.Show("Save diary successfully!\nSave time:"+newItem.DiaryTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/DiaryView/PieChart.xaml", UriKind.Relative));
        }
    }
}