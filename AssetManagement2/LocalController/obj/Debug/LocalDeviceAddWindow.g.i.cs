﻿#pragma checksum "..\..\LocalDeviceAddWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2AFE294C52CE676C87B64340E31C1D45A8894E98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LocalController;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LocalController {
    
    
    /// <summary>
    /// LocalDeviceAddWindow
    /// </summary>
    public partial class LocalDeviceAddWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPeriod;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCode;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLimit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxType;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxDestination;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxController;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelPeriodGreska;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelLimitGreska;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTypeGreska;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\LocalDeviceAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelDestGreska;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LocalController;component/localdeviceaddwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LocalDeviceAddWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\LocalDeviceAddWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxPeriod = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxLimit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.comboBoxType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.comboBoxDestination = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 22 "..\..\LocalDeviceAddWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.comboBoxController = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.LabelPeriodGreska = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.LabelLimitGreska = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.LabelTypeGreska = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.LabelDestGreska = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

