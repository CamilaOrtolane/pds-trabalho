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
using TelasWpf.Models;
using TelasWpf.Helpers;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TelasWpf.TelasCadastro
{
    /// <summary>
    /// Lógica interna para cadastrarServico.xaml
    /// </summary>
    public partial class cadastrarServico : Window
    {
        private int _id;

        private Servico _servico;
        public cadastrarServico()
        {
            InitializeComponent();
        }
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }

        private void btnSalvar_CLick(object sender, RoutedEventArgs e)
        {
            try
            {
                Servico servico = new Servico();
                txtTipo.Text = servico.Tipo;
                txtDescricao.Text = servico.Descricao;

                ServicoDAO servicoDAO = new ServicoDAO();
                servicoDAO.Insert(servico);
                MessageBox.Show("O Servico foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {
                    txtTipo.Text = "";
                    txtDescricao.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
