﻿#pragma checksum "..\..\..\..\classes\Menu\LvlPreview.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC4E0D736BF6987633EF9931C46B38CDA3CB398F"
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
    /// LvlPreview
    /// </summary>
    public partial class LvlPreview : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\classes\Menu\LvlPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ShootingRange.classes.Menu.LvlPreview controlLvlPreview;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\classes\Menu\LvlPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLvl;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\classes\Menu\LvlPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rctDark;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\classes\Menu\LvlPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\classes\Menu\LvlPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblRecord;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\classes\Menu\LvlPreview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStart;
        
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
            System.Uri resourceLocater = new System.Uri("/ShootingRange;component/classes/menu/lvlpreview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\classes\Menu\LvlPreview.xaml"
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
            this.controlLvlPreview = ((ShootingRange.classes.Menu.LvlPreview)(target));
            
            #line 10 "..\..\..\..\classes\Menu\LvlPreview.xaml"
            this.controlLvlPreview.MouseEnter += new System.Windows.Input.MouseEventHandler(this.UserControl_MouseEnter);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\..\classes\Menu\LvlPreview.xaml"
            this.controlLvlPreview.MouseLeave += new System.Windows.Input.MouseEventHandler(this.controlLvlPreview_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.imgLvl = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.rctDark = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblRecord = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnStart = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\classes\Menu\LvlPreview.xaml"
            this.btnStart.Click += new System.Windows.RoutedEventHandler(this.lvlPreview_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

