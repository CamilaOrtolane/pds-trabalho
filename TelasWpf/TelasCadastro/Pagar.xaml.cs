﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TelasWpf.TelasCadastro
{
    /// <summary>
    /// Lógica interna para Pagar.xaml
    /// </summary>
    public partial class Pagar : Window
    {
        public Pagar()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }
    }
}