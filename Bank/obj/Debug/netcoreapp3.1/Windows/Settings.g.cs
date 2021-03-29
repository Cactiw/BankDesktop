﻿#pragma checksum "..\..\..\..\Windows\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88B53164A80F32DD937C5152C44BC641130B6369"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Bank;
using Bank.Commands;
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


namespace Bank {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    public partial class SettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding OkButtonCommand;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WorkersBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WorkersSalaryBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerFlowBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QueueLimitBox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeToProcessBeginBox;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeToProcessEndBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProfitStartBox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProfitEndBox;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StepMinutesBox;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\Windows\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Bank;component/windows/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.OkButtonCommand = ((System.Windows.Input.CommandBinding)(target));
            
            #line 12 "..\..\..\..\Windows\Settings.xaml"
            this.OkButtonCommand.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OkClick);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\Windows\Settings.xaml"
            this.OkButtonCommand.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanExecute);
            
            #line default
            #line hidden
            return;
            case 2:
            this.WorkersBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.WorkersSalaryBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CustomerFlowBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.QueueLimitBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TimeToProcessBeginBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TimeToProcessEndBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ProfitStartBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.ProfitEndBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.StepMinutesBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.OkButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

