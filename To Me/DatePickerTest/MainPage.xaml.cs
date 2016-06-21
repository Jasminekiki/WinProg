using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DatePickerTest.Resources;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using Newtonsoft.Json;
using DatePickerTest.Model;

namespace DatePickerTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            this.listpicker.SelectedIndex = 0;
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private int loadType = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml?str=haha",UriKind.Relative));
            //this.NavigationService.Navigate(new Uri("/DiaryView/PieChart.xaml", UriKind.Relative));
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            this.UploadPan.Visibility = System.Windows.Visibility.Visible;
            this.loadType = 1;
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            this.DownloadPan.Visibility = System.Windows.Visibility.Visible;
            this.loadType = 2;
        }
        private void btnOk(object sender, RoutedEventArgs e)
        {

            if (loadType == 1)//Upload
            {
                if (string.IsNullOrWhiteSpace(this.up_password.Text))
                {
                    MessageBox.Show("please input password");
                    return;
                }
              
                Main_Uploaded(sender, e);

            }
            if (loadType == 2)//Download
            {
                if (string.IsNullOrWhiteSpace(this.down_password.Text) || string.IsNullOrWhiteSpace(this.down_password.Text))
                {
                    MessageBox.Show("please input password and id");
                    return;
                }

                Main_Downloaded(sender, e);
            }
            this.NavigationService.Navigate(new Uri("/MainPage.xaml?str=haha", UriKind.Relative));

        }
        private void onCancel(object sender, RoutedEventArgs e)
        {
            
                this.NavigationService.Navigate(new Uri("/MainPage.xaml?str=haha", UriKind.Relative));
        }

      

        WebClient client;

        private void Main_Uploaded(object sender, System.Windows.RoutedEventArgs e)

        {
            this.UploadPan.Visibility = System.Windows.Visibility.Collapsed;
            string url = "http://95.85.15.223/dotnet/save.php";

            Uri uri = new Uri(url);
            string alldata = null;
            if (this.listpicker.SelectedIndex == 0)
                alldata = JsonConvert.SerializeObject(App.ViewModel.AllDataItems);
            else if (this.listpicker.SelectedIndex == 1)
                alldata = JsonConvert.SerializeObject(App.ClViewModel.AllClockItems);
            else if (this.listpicker.SelectedIndex == 2)
                alldata = JsonConvert.SerializeObject(App.CViewModel.AllCountItems);
            else
                alldata = JsonConvert.SerializeObject(App.DViewModel.AllDataItems);
          
            
            // string alldata = "{\"password\":\""+ up_password.Text+"\",\"json\":\"ok\",\"status\":\"1\",\"link\":\"http://kuaidi100.com/chaxun?com=yuantong&nu=1780371398\",\"state\":\"3\",\"data\":[{\"time\":\"2012-03-19 15:02:42\",\"context\":\"河南省南阳市白河南/PDA正常签收扫描/签收人:孟星星 \"}]}";
            client = new WebClient();
            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.AllowReadStreamBuffering = true;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
            Parameters prms = new Parameters();
            prms.AddPair("password", up_password.Text);
            prms.AddPair("json", alldata);

            client.UploadStringAsync(uri,"POST", prms.FormPostData(), null);


        }
        public static Dictionary<string, int> dictionary = new Dictionary<string, int>();

        private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            string return_value = e.Result;
            JObject job = JObject.Parse(return_value);
            Console.Write("status" + job["status"]);
           
            if(loadType == 1)
            {
                MessageBox.Show("please remember id " + job["id"], "status" + job["status"], MessageBoxButton.OKCancel);
                dictionary.Add(job["id"].ToString(), this.listpicker.SelectedIndex);
                
            }
            else
            {
                if (job["status"].ToString() == "found")
                {
                    int exist = 0;
                    if (dictionary[down_id.Text] == 0)
                    {
                       
                        List<TaskItem> resultOfTask = JsonConvert.DeserializeObject<List<TaskItem>>(job["data"].ToString());
                        for (int i = 0; i < resultOfTask.Count; i++)
                        {
                            exist = 0;
                            for (int j = 0; j<App.ViewModel.AllDataItems.Count; j++)
                            {
                                if (App.ViewModel.AllDataItems[j].TaskId == resultOfTask[i].TaskId)
                                {
                                    exist = 1;
                                    break;
                                }

                            }
                            if (exist==1)
                                continue;
                            else
                                App.ViewModel.AddDataItem(resultOfTask[i]);
                            
                        }
                    }
                    if (dictionary[down_id.Text] == 1)
                    {
                        List<ClockItem> resultOfClock = JsonConvert.DeserializeObject<List<ClockItem>>(job["data"].ToString());
                        for (int i = 0; i < resultOfClock.Count; i++)
                        {
                            exist = 0;
                            for (int j = 0; j < App.ClViewModel.AllClockItems.Count; j++)
                            {
                                if (App.ClViewModel.AllClockItems[j].ClockItemId == resultOfClock[i].ClockItemId)
                                {
                                    exist = 1;
                                    break;
                                }

                            }
                            if (exist == 1)
                                continue;
                            else
                                App.ClViewModel.AddClockItem(resultOfClock[i]);
                          
                        }
                    }
                    if (dictionary[down_id.Text] == 2)
                    {
                        List<CountItem> resultOfCount = JsonConvert.DeserializeObject<List<CountItem>>(job["data"].ToString());
                        for (int i = 0; i < resultOfCount.Count; i++)
                        {
                            exist = 0;
                            for (int j = 0; j < App.CViewModel.AllCountItems.Count; j++)
                            {
                                if (App.CViewModel.AllCountItems[j].CountItemId == resultOfCount[i].CountItemId)
                                {
                                    exist = 1;
                                    break;
                                }

                            }
                            if (exist == 1)
                                continue;
                            else
                                App.CViewModel.AddCountItem(resultOfCount[i]);
                           
                        }
                    }
                    if (dictionary[down_id.Text] == 3)
                    {
                        
                        List<DiaryItem> resultOfDiary = JsonConvert.DeserializeObject<List<DiaryItem>>(job["data"].ToString());
                        for (int i = 0; i < resultOfDiary.Count; i++)
                        {
                            exist = 0;
                            for (int j = 0; j < App.DViewModel.AllDataItems.Count; j++)
                            {
                                if (App.DViewModel.AllDataItems[j].DiaryItemId == resultOfDiary[i].DiaryItemId)
                                {
                                    exist = 1;
                                    break;
                                }

                            }
                            if (exist == 1)
                                continue;
                            else
                                App.DViewModel.AddDataItem(resultOfDiary[i]);
                           
                        
                        }
                    }

                    MessageBox.Show("result" + job["data"], "result", MessageBoxButton.OKCancel);
                }  
               if(job["status"].ToString()== "not found (bad id or password)")
                    MessageBox.Show("Error id or password", "result", MessageBoxButton.OKCancel);

            }

        }

        private void Main_Downloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DownloadPan.Visibility = System.Windows.Visibility.Collapsed;
            string url = "http://95.85.15.223/dotnet/load.php";
            Uri uri = new Uri(url);

            client = new WebClient();
            client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.AllowReadStreamBuffering = true;
            
            Parameters prms = new Parameters();
            prms.AddPair("password",down_password.Text);
            prms.AddPair("id",down_id.Text);
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
            client.UploadStringAsync(uri,"POST",prms.FormPostData(),null);

      
        }

      

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }

    public class Parameters
    {
        public List<ParameterObject> prms;

        public Parameters()
        {
            prms = new List<ParameterObject>();
        }

        public void AddPair(string id, string val)
        {
            prms.Add(new ParameterObject(id, val));
        }

        public String FormPostData()
        {
            StringBuilder buffer = new StringBuilder();

            for (int i = 0; i < prms.Count; i++)
            {
                if (i == 0)
                {
                    buffer.Append(System.Net.HttpUtility.UrlEncode(prms[i].id) + "=" + System.Net.HttpUtility.UrlEncode(prms[i].value));
                }
                else
                {
                    buffer.Append("&" + System.Net.HttpUtility.UrlEncode(prms[i].id) + "=" + System.Net.HttpUtility.UrlEncode(prms[i].value));
                }
            }

            return buffer.ToString();
        }
    }
    public class ParameterObject
    {
        public string id;
        public string value;

        public ParameterObject(string id, string val)
        {
            this.id = id;
            this.value = val;
        }
    }
    }