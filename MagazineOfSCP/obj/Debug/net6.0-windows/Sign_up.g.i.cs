﻿#pragma checksum "..\..\..\Sign_up.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C6AE3CD6895129501C53415074D93F1C3D0B76E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MagazineOfSCP;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace MagazineOfSCP {
    
    
    /// <summary>
    /// Sign_up
    /// </summary>
    public partial class Sign_up : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Sign_up.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Sign_up.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox P1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Sign_up.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox P2;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Sign_up.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reg_btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Sign_up.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button winLog_btn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Sign_up.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button user_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MagazineOfSCP;component/sign_up.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Sign_up.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.P1 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.P2 = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.reg_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Sign_up.xaml"
            this.reg_btn.Click += new System.Windows.RoutedEventHandler(this.reg_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.winLog_btn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Sign_up.xaml"
            this.winLog_btn.Click += new System.Windows.RoutedEventHandler(this.winLog_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.user_btn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Sign_up.xaml"
            this.user_btn.Click += new System.Windows.RoutedEventHandler(this.user_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

