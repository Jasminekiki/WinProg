﻿#pragma checksum "C:\Users\Cao Qi\Documents\GitHub\WinProg\To Me\DatePickerTest\DiaryView\EditDiary.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0BD14335A3074E3432528B1EEF2EB377"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DatePickerTest.DiaryView {
    
    
    public partial class EditDiary : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.ListPicker moodPicker;
        
        internal System.Windows.Controls.TextBlock textBlock;
        
        internal System.Windows.Controls.TextBox TitleText;
        
        internal System.Windows.Controls.TextBox Content;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button SaveButton;
        
        internal System.Windows.Controls.TextBlock time;
        
        internal System.Windows.Controls.Button button;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DatePickerTest;component/DiaryView/EditDiary.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.moodPicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("moodPicker")));
            this.textBlock = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock")));
            this.TitleText = ((System.Windows.Controls.TextBox)(this.FindName("TitleText")));
            this.Content = ((System.Windows.Controls.TextBox)(this.FindName("Content")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.SaveButton = ((System.Windows.Controls.Button)(this.FindName("SaveButton")));
            this.time = ((System.Windows.Controls.TextBlock)(this.FindName("time")));
            this.button = ((System.Windows.Controls.Button)(this.FindName("button")));
        }
    }
}

