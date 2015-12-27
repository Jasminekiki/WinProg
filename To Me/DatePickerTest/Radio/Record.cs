using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace DatePickerTest
{
    public class Record
    {
        public String FileName { get; set; }

        public DateTime SaveTime { get; set; }

        public String FilePath { get; set; }
    }



    public class DateTimeConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            return dt.ToString("yyyy-MM-dd HH:mm:ss");

        }


        //日期格式转换
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}