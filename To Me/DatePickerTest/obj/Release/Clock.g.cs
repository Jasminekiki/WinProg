﻿#pragma checksum "C:\Users\Cao Qi\Documents\GitHub\WinProg\To Me\DatePickerTest\Clock.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D55ADDC8E7B82DFD804F1210DE2B4EEE"
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
    
    
    public partial class Clock : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.TimePicker clockTime;
        
        internal System.Windows.Controls.TextBox clockName;
        
        internal Microsoft.Phone.Controls.ListPicker DayPicker;
        
        internal System.Windows.Controls.CheckBox isRepeat;
        
        internal Microsoft.Phone.Controls.ListPicker musicId;
        
        internal Microsoft.Phone.Controls.ToggleSwitch alarmSwitch;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DatePickerTest;component/Clock.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.clockTime = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("clockTime")));
            this.clockName = ((System.Windows.Controls.TextBox)(this.FindName("clockName")));
            this.DayPicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("DayPicker")));
            this.isRepeat = ((System.Windows.Controls.CheckBox)(this.FindName("isRepeat")));
            this.musicId = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("musicId")));
            this.alarmSwitch = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("alarmSwitch")));
            this.CancelButton = ((System.Windows.Controls.Button)(this.FindName("CancelButton")));
            this.SaveButton = ((System.Windows.Controls.Button)(this.FindName("SaveButton")));
        }
    }
}

