﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D13C7014C35913BE668ED798926B0E15092F98B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Service;
using Service.ViewModels;
using Service.Views;
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


namespace Service {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NadlezniButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KorisniciButton;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KvaroviButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StanjeButton;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeoOpremeButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MagacinButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RadniNalogButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EkipeButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MrezeButton;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RacuniButton;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RadniciButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Service;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 71 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NadlezniButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\MainWindow.xaml"
            this.NadlezniButton.Click += new System.Windows.RoutedEventHandler(this.NadlezniButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.KorisniciButton = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\MainWindow.xaml"
            this.KorisniciButton.Click += new System.Windows.RoutedEventHandler(this.KorisniciButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.KvaroviButton = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\MainWindow.xaml"
            this.KvaroviButton.Click += new System.Windows.RoutedEventHandler(this.KvaroviButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StanjeButton = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\MainWindow.xaml"
            this.StanjeButton.Click += new System.Windows.RoutedEventHandler(this.StanjeButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeoOpremeButton = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\MainWindow.xaml"
            this.DeoOpremeButton.Click += new System.Windows.RoutedEventHandler(this.DeoOpremeButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MagacinButton = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\MainWindow.xaml"
            this.MagacinButton.Click += new System.Windows.RoutedEventHandler(this.MagacinButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RadniNalogButton = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\MainWindow.xaml"
            this.RadniNalogButton.Click += new System.Windows.RoutedEventHandler(this.RadniNalogButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.EkipeButton = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\MainWindow.xaml"
            this.EkipeButton.Click += new System.Windows.RoutedEventHandler(this.EkipeButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.MrezeButton = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\MainWindow.xaml"
            this.MrezeButton.Click += new System.Windows.RoutedEventHandler(this.MrezeButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.RacuniButton = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\MainWindow.xaml"
            this.RacuniButton.Click += new System.Windows.RoutedEventHandler(this.RacuniButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.RadniciButton = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\MainWindow.xaml"
            this.RadniciButton.Click += new System.Windows.RoutedEventHandler(this.RadniciButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

