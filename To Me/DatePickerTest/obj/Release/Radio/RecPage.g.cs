﻿#pragma checksum "C:\Users\Cao Qi\Desktop\To Me\DatePickerTest\Radio\RecPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F8797F19D1D1AFE04C3D23D6CA8598C6"
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


namespace DatePickerTest.Radio {
    
    
    public partial class RecPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard stdRec;
        
        internal System.Windows.Controls.TextBlock txbRecording;
        
        internal System.Windows.Media.LinearGradientBrush lbr;
        
        internal System.Windows.Controls.Grid svPan;
        
        internal System.Windows.Controls.TextBox txtFileName;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DatePickerTest;component/Radio/RecPage.xaml", System.UriKind.Relative));
            this.stdRec = ((System.Windows.Media.Animation.Storyboard)(this.FindName("stdRec")));
            this.txbRecording = ((System.Windows.Controls.TextBlock)(this.FindName("txbRecording")));
            this.lbr = ((System.Windows.Media.LinearGradientBrush)(this.FindName("lbr")));
            this.svPan = ((System.Windows.Controls.Grid)(this.FindName("svPan")));
            this.txtFileName = ((System.Windows.Controls.TextBox)(this.FindName("txtFileName")));
        }
    }
}

