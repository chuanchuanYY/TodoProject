﻿#pragma checksum "..\..\..\..\Views\TodoView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "693EC43912B5A905D2E5375809E2C223DD47408E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using MyTodo.Wpf.Common;
using MyTodo.Wpf.Extensions;
using MyTodo.Wpf.Views;
using Prism.DryIoc;
using Prism.Interactivity;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Prism.Services.Dialogs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using ValueConverters;


namespace MyTodo.Wpf.Views {
    
    
    /// <summary>
    /// TodoView
    /// </summary>
    public partial class TodoView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\Views\TodoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Views\TodoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilterCondition;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\TodoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl todoListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MyTodo.Wpf;component/views/todoview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\TodoView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 21 "..\..\..\..\Views\TodoView.xaml"
            ((System.Windows.Data.CollectionViewSource)(target)).Filter += new System.Windows.Data.FilterEventHandler(this.CollectionViewSource_Filter);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\Views\TodoView.xaml"
            this.SearchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilteText_Changed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FilterCondition = ((System.Windows.Controls.ComboBox)(target));
            
            #line 64 "..\..\..\..\Views\TodoView.xaml"
            this.FilterCondition.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterCondition_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.todoListView = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

