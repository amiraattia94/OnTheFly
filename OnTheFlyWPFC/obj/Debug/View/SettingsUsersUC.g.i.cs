﻿#pragma checksum "..\..\..\View\SettingsUsersUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2932DE3D2890C7C240F7399FC9EA8270CE62C658"
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
using OnTheFlyWPFC.ViewModel;
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
    /// SettingsUsersUC
    /// </summary>
    public partial class SettingsUsersUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 315 "..\..\..\View\SettingsUsersUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid ViewBranchForm;
        
        #line default
        #line hidden
        
        
        #line 343 "..\..\..\View\SettingsUsersUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchUserName;
        
        #line default
        #line hidden
        
        
        #line 344 "..\..\..\View\SettingsUsersUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearchUser;
        
        #line default
        #line hidden
        
        
        #line 352 "..\..\..\View\SettingsUsersUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstViewUsers;
        
        #line default
        #line hidden
        
        
        #line 393 "..\..\..\View\SettingsUsersUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddUser;
        
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
            System.Uri resourceLocater = new System.Uri("/OnTheFlyWPFC;component/view/settingsusersuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SettingsUsersUC.xaml"
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
            this.ViewBranchForm = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 2:
            this.txtSearchUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 343 "..\..\..\View\SettingsUsersUC.xaml"
            this.txtSearchUserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtSearchUserName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSearchUser = ((System.Windows.Controls.Button)(target));
            
            #line 344 "..\..\..\View\SettingsUsersUC.xaml"
            this.btnSearchUser.Click += new System.Windows.RoutedEventHandler(this.BtnSearchUser_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lstViewUsers = ((System.Windows.Controls.ListView)(target));
            
            #line 352 "..\..\..\View\SettingsUsersUC.xaml"
            this.lstViewUsers.Loaded += new System.Windows.RoutedEventHandler(this.lstViewUsers_Loaded);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 393 "..\..\..\View\SettingsUsersUC.xaml"
            this.btnAddUser.Click += new System.Windows.RoutedEventHandler(this.btnAddUser_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 362 "..\..\..\View\SettingsUsersUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.viewGroups);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 372 "..\..\..\View\SettingsUsersUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditUser);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 381 "..\..\..\View\SettingsUsersUC.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteUser);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

