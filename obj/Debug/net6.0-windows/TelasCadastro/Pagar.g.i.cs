﻿#pragma checksum "..\..\..\..\TelasCadastro\Pagar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "954BB5F1F76F714CE2675323023600688CBB965E"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TelasWpf.TelasCadastro;


namespace TelasWpf.TelasCadastro {
    
    
    /// <summary>
    /// Pagar
    /// </summary>
    public partial class Pagar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDespesa;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtValor;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpData;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStatus;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescricao;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtParcela;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\TelasCadastro\Pagar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttipoPag;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TelasWpf;component/telascadastro/pagar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\TelasCadastro\Pagar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtDespesa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtValor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dpData = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.txtStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtDescricao = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtParcela = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txttipoPag = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 115 "..\..\..\..\TelasCadastro\Pagar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnVoltar_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 119 "..\..\..\..\TelasCadastro\Pagar.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSalvar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
