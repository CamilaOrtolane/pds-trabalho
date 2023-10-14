using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using TelasWpf.Helpers;
using TelasWpf.Models;

namespace TelasWpf.TelasCadastro
{
    /// <summary>
    /// Lógica interna para cadastrarFornecedor.xaml
    /// </summary>
    public partial class cadastrarFornecedor : Window
    {
        private int _id;

        private Fornecedor _fornecedor;
        public cadastrarFornecedor()
        {
            InitializeComponent();
        }
        private void btnVoltar_Click (object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Fornecedor forn = new Fornecedor();
                forn.NomeFantasia = txtNomForn.Text;
                forn.Cnpj = txtCnpjForn.Text;
                forn.RazaoSocial = txtRazaoSocial.Text;
                forn.Estado = txtEstadoForn.Text;
                forn.Cidade = txtCidadeForn.Text;
                forn.Endereco = txtEnd.Text;

                FornecedorDAO fornecedorDAO = new FornecedorDAO();
                fornecedorDAO.Insert(forn);

                MessageBox.Show("O fornecedor foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    var newWindow = new MenuPrincipal();
                    newWindow.Show();
                    Close();
                }
                else
                {
                    txtNomForn.Text = "";
                    txtCnpjForn.Text = "";
                    txtRazaoSocial.Text = "";
                    txtEstadoForn.Text = "";
                    txtCidadeForn.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
            
        

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new ListFornecedor();
            newWindow.Show();
            Close();
        }

    }
}
