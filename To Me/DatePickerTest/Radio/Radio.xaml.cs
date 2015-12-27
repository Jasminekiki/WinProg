using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Threading;
using Microsoft.Xna.Framework;


namespace DatePickerTest.Radio
{
    public partial class Radio : PhoneApplicationPage
    {
        // 构造函数
        public Radio()
        {
            InitializeComponent();
        }

        private void onPlay(object sender, RoutedEventArgs e)
        {
            Button playButton = e.OriginalSource as Button;
            if (playButton != null)
            {
                MemoryStream ms = new MemoryStream();
                string fileName = playButton.Tag.ToString();
                // 从独立存储区中读取文件
                try
                {
                    using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        // 如果文件不存在，跳出
                        if (!iso.FileExists("Radio\\"+fileName)) 
                        {
                            return;
                        }
                        // 打开文件流
                        using (IsolatedStorageFileStream stream = iso.OpenFile("Radio\\" +fileName, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[2048];
                            int n = 0;
                            // 读入到内存流
                            while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ms.Write(buffer, 0, n);
                            }
                        }
                    }
                }
                catch
                {
                    // 如果未能正确读取文件，就不往下执行
                    return;
                }
                // 如果文件长度为0，就不用播放了
                if (ms.Length == 0L)
                {
                    ms.Dispose();
                    return;
                }
                // 播放声音
                SoundEffect mySound = new SoundEffect(ms.ToArray(), Microphone.Default.SampleRate, AudioChannels.Mono);
                mySound.Play();
                ms.Dispose();
            }
        }

        private void onDelete(object sender, RoutedEventArgs e)
        {
            HyperlinkButton delLink = e.OriginalSource as HyperlinkButton;
            if (delLink != null)
            {
                string fileName = delLink.Tag.ToString();
                if (MessageBox.Show("确实要删除文件 " + fileName + " 吗？","提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (iso.FileExists("Radio\\" + fileName))
                        {
                            try
                            {
                                iso.DeleteFile("Radio\\" + fileName);
                            }
                            catch { return; }
                            // 重新获取文件列表
                            GetFileList();
                        }
                    }
                }
            }
        }

        private void onNew(object sender, EventArgs e)
        {
            Uri uri = new Uri("/Radio/RecPage.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        private void GetFileList()
        {
            try
            {
                using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    string[] files = iso.GetFileNames(System.IO.Path.Combine("Radio", "*"));
                    List<Record> rcList = new List<Record>();
                    foreach (string f in files)
                    {
                        Record rec = new Record()
                        {
                            FileName = f,
                            SaveTime = iso.GetCreationTime(f).DateTime
                        };
                        rcList.Add(rec);
                    }

                    this.fileList.ItemsSource = rcList;
                }
            }
            catch { }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GetFileList();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        private void Return(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/DefaultPage.xaml", UriKind.Relative));
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
}