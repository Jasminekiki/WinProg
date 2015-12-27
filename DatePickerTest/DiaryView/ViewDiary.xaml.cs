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
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace DatePickerTest.DiaryView
{
    public partial class ViewDiary : PhoneApplicationPage
    {
        string[] tagUris = { "/Images/c.png", "/Images/a.png", "/Images/b.png", "/Images/d.png", "/Images/e.png" };
 //       string[] returnColor = { "#FF797A70", "#FFE24848","#FFDBEE23", "#FF4459A0","#FF3B3E49" };
 //       string[] deleteColor = { "#FF2E2E2E", "#FF910808", "#FF817600", "#FF081B59", "#FF000000" };
        public ViewDiary()
        {
            InitializeComponent();
            this.DataContext = App.DViewModel;
            DiaryItem ditem = App.DViewModel.AllDataItems[App.selectedIndex];
            this.time.Text = ditem.DiaryTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.title.Text = ditem.DiaryTitle;
            this.content.Text = ditem.DiaryContent;
            Uri tagImage = new Uri(tagUris[ditem.MoodTag], UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = tagImage;
            this.moodTag.Source = bitmapImage;

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            App.DViewModel.DeleteDataItem(App.selectedIndex);
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/DiaryView/PieChart.xaml", UriKind.Relative));
        }
    }
}