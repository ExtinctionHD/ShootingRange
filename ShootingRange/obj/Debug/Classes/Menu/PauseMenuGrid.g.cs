﻿#pragma checksum "..\..\..\..\classes\Menu\PauseMenuGrid.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D5FE283B4D404AA634B9C899AEEB4687C99DA283"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ShootingRange.classes.Menu;
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


namespace ShootingRange.classes.Menu {
    
    
    /// <summary>
    /// PauseMenuGrid
    /// </summary>
    public partial class PauseMenuGrid : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grPauseMenu;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPauseResume;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPauseRestart;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPauseMainMenu;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPauseExit;
        
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
            System.Uri resourceLocater = new System.Uri("/ShootingRange;component/classes/menu/pausemenugrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
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
            this.grPauseMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btnPauseResume = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
            this.btnPauseResume.Click += new System.Windows.RoutedEventHandler(this.btnResume_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPauseRestart = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
            this.btnPauseRestart.Click += new System.Windows.RoutedEventHandler(this.btnRestart_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnPauseMainMenu = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
            this.btnPauseMainMenu.Click += new System.Windows.RoutedEventHandler(this.btnMainMenu_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnPauseExit = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\classes\Menu\PauseMenuGrid.xaml"
            this.btnPauseExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

