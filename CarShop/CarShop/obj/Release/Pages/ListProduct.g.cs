﻿#pragma checksum "..\..\..\Pages\ListProduct.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "073360DCDB72ACF3F27507556EE2096776DC90A0E54BA3D2774BF3E17DCB6A30"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarShop;
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


namespace CarShop {
    
    
    /// <summary>
    /// ListProduct
    /// </summary>
    public partial class ListProduct : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 32 "..\..\..\Pages\ListProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoryList;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\ListProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox subCategoryList;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\ListProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox startPrice;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\ListProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox endPrice;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\ListProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView recommendProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/CarShop;component/pages/listproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ListProduct.xaml"
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
            this.categoryList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Pages\ListProduct.xaml"
            this.categoryList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.categoryList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.subCategoryList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.startPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\..\Pages\ListProduct.xaml"
            this.startPrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.startPrice_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.endPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\Pages\ListProduct.xaml"
            this.endPrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.endPrice_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 85 "..\..\..\Pages\ListProduct.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Sort_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.recommendProduct = ((System.Windows.Controls.ListView)(target));
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
            case 7:
            
            #line 118 "..\..\..\Pages\ListProduct.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GoProduct_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
