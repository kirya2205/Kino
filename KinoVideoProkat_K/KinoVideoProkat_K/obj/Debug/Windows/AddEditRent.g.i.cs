﻿#pragma checksum "..\..\..\Windows\AddEditRent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "877A73E4F9280EC21DE2622201D9AEBC6D22DFB668140D0F2B3FAF5610EC3AA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KinoVideoProkat_K.Windows;
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


namespace KinoVideoProkat_K.Windows {
    
    
    /// <summary>
    /// AddEditRent
    /// </summary>
    public partial class AddEditRent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbCinema;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbFilm;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbDateStart;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbDateStop;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbWorker;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbPhoneWorker;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSumm;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\AddEditRent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/KinoVideoProkat_K;component/windows/addeditrent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddEditRent.xaml"
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
            this.CbCinema = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.CbFilm = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TbDateStart = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TbDateStop = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TbWorker = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TbPhoneWorker = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnSumm = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Windows\AddEditRent.xaml"
            this.BtnSumm.Click += new System.Windows.RoutedEventHandler(this.BtnSumm_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Windows\AddEditRent.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

