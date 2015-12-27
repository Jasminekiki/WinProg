using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace DatePickerTest.DiaryView
{
    public partial class PieChart : PhoneApplicationPage
    {
        public PieChart()
        {
            InitializeComponent();
        }

        public ObservableCollection<PData> Data = new ObservableCollection<PData>()
        {
            new PData() { title = "Extremely Happy", value = App.DViewModel.SelectItemWithTag(2) },
            new PData() { title = "Happy", value = App.DViewModel.SelectItemWithTag(3) },
            new PData() { title = "So So", value = App.DViewModel.SelectItemWithTag(1) },
            new PData() { title = "Sad", value = App.DViewModel.SelectItemWithTag(4) },
            new PData() { title = "Angry", value = App.DViewModel.SelectItemWithTag(5) },
        };

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.pieChart.DataSource = Data;
        }
    }

    public class PData
    {
        public string title { get; set; }
        public double value { get; set; }
    }
}
