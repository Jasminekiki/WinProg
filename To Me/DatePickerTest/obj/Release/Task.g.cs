﻿#pragma checksum "C:\Users\Cao Qi\Documents\GitHub\WinProg\To Me\DatePickerTest\Task.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CDBEFAFCD7AD9C4EA27C87D291377D1A"
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


namespace DatePickerTest {
    
    
    public partial class Task : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox taskName;
        
        internal System.Windows.Controls.TextBox taskContent;
        
        internal Microsoft.Phone.Controls.DatePicker beginDate;
        
        internal Microsoft.Phone.Controls.TimePicker beginTime;
        
        internal Microsoft.Phone.Controls.DatePicker endDate;
        
        internal Microsoft.Phone.Controls.TimePicker endTime;
        
        internal Microsoft.Phone.Controls.DatePicker alarmDate;
        
        internal Microsoft.Phone.Controls.TimePicker alarmTime;
        
        internal Microsoft.Phone.Controls.ToggleSwitch alarmOn;
        
        internal System.Windows.Controls.Button CancelButton;
        
        internal System.Windows.Controls.Button SaveButton;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DatePickerTest;component/Task.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.taskName = ((System.Windows.Controls.TextBox)(this.FindName("taskName")));
            this.taskContent = ((System.Windows.Controls.TextBox)(this.FindName("taskContent")));
            this.beginDate = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("beginDate")));
            this.beginTime = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("beginTime")));
            this.endDate = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("endDate")));
            this.endTime = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("endTime")));
            this.alarmDate = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("alarmDate")));
            this.alarmTime = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("alarmTime")));
            this.alarmOn = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("alarmOn")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.SaveButton = ((System.Windows.Controls.Button)(this.FindName("SaveButton")));
        }
    }
}

