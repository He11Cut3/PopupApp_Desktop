﻿#pragma checksum "..\..\..\Treaty\Add_Contr.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "60F12AC68F090770B472731D8C95872FA8E6E498B995CD9E4EDFD0CF74132CF3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PopupApp.Treaty;
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


namespace PopupApp.Treaty {
    
    
    /// <summary>
    /// Add_Contr
    /// </summary>
    public partial class Add_Contr : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\Treaty\Add_Contr.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ComeBack;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Treaty\Add_Contr.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FIO;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Treaty\Add_Contr.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Service;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Treaty\Add_Contr.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Loc;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Treaty\Add_Contr.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button New_Traty;
        
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
            System.Uri resourceLocater = new System.Uri("/PopupApp;component/treaty/add_contr.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Treaty\Add_Contr.xaml"
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
            this.ComeBack = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\Treaty\Add_Contr.xaml"
            this.ComeBack.Click += new System.Windows.RoutedEventHandler(this.ComeBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FIO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Service = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Loc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.New_Traty = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\Treaty\Add_Contr.xaml"
            this.New_Traty.Click += new System.Windows.RoutedEventHandler(this.New_Traty_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

