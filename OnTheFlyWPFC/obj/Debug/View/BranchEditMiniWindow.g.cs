﻿#pragma checksum "..\..\..\View\BranchEditMiniWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6426217F93FCFE5B03907F7DE24523FBA86D5F0D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using OnTheFlyWPFC.View;
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


namespace OnTheFlyWPFC.View {
    
    
    /// <summary>
    /// BranchEditMiniWindow
    /// </summary>
    public partial class BranchEditMiniWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\View\BranchEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseForm;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\BranchEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StkEditBranch;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\BranchEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBranchName;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\View\BranchEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBranchCities;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\View\BranchEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBranchAddress;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\View\BranchEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBranchStatus;
        
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
            System.Uri resourceLocater = new System.Uri("/OnTheFlyWPFC;component/view/brancheditminiwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\BranchEditMiniWindow.xaml"
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
            this.btnCloseForm = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\View\BranchEditMiniWindow.xaml"
            this.btnCloseForm.Click += new System.Windows.RoutedEventHandler(this.btnCloseForm_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StkEditBranch = ((System.Windows.Controls.StackPanel)(target));
            
            #line 61 "..\..\..\View\BranchEditMiniWindow.xaml"
            this.StkEditBranch.Loaded += new System.Windows.RoutedEventHandler(this.StkEditBranch_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBranchName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbBranchCities = ((System.Windows.Controls.ComboBox)(target));
            
            #line 97 "..\..\..\View\BranchEditMiniWindow.xaml"
            this.cmbBranchCities.Loaded += new System.Windows.RoutedEventHandler(this.cmbBranchCities_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtBranchAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmbBranchStatus = ((System.Windows.Controls.ComboBox)(target));
            
            #line 134 "..\..\..\View\BranchEditMiniWindow.xaml"
            this.cmbBranchStatus.Loaded += new System.Windows.RoutedEventHandler(this.cmbBranchStatus_Loaded);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 150 "..\..\..\View\BranchEditMiniWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

