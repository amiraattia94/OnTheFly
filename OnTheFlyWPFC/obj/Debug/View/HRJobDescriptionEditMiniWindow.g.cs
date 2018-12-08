﻿#pragma checksum "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F572DC28D31CC9CE49360071E4CD2636E3DEA4C6"
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
using OnTheFlyWPFC.Behaviors;
using OnTheFlyWPFC.View;
using RootLibrary.WPF.Localization;
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
    /// HRJobDescriptionEditMiniWindow
    /// </summary>
    public partial class HRJobDescriptionEditMiniWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseForm;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StkEditJob;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJobName;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBasicSalary;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWorkingHoursPerMonth;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditJob;
        
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
            System.Uri resourceLocater = new System.Uri("/OnTheFlyWPFC;component/view/hrjobdescriptioneditminiwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 33 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
            this.btnCloseForm.Click += new System.Windows.RoutedEventHandler(this.btnCloseForm_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StkEditJob = ((System.Windows.Controls.StackPanel)(target));
            
            #line 63 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
            this.StkEditJob.Loaded += new System.Windows.RoutedEventHandler(this.StkEditJob_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtJobName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtBasicSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtWorkingHoursPerMonth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnEditJob = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\View\HRJobDescriptionEditMiniWindow.xaml"
            this.btnEditJob.Click += new System.Windows.RoutedEventHandler(this.btnEditJob_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

