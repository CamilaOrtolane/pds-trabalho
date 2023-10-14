using System;
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

namespace TelasWpf.TelasCadastro
{
    /// <summary>
    /// Lógica interna para cadastroCliente.xaml
    /// </summary>
    public partial class cadastroCliente : Window
    {
        public cadastroCliente()
        {
            InitializeComponent();
        }
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Cliente cli = new Cliente();
                cli.NomeCliente = txtNomCli.Text;
                cli.Cpf = txtCpf.Text;
                cli.Rg = txtRg.Text;
                cli.EstadoCivil = txtEstadoCivil.Text;
                cli.Estado = txtEstado.Text;
                cli.Cidade = txtCidade.Text;
                cli.Endereco = txtEndereco.Text;
                cli.DataNasc = txtData.Text;
                cli.Telefone = txtTelefone.Text;
                cli.Profissao = txtProfissao.Text;

                ClienteDAO clienteDAO = new ClienteDAO();
                clienteDAO.Insert(cli);

                MessageBox.Show("O Cliente foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    var newWindow = new MenuPrincipal();
                    newWindow.Show();
                    Close();
                }
                else
                {
                    txtTelefone.Text = "";
                    txtRg.Text = "";
                    txtProfissao.Text = "";
                    txtNomCli.Text = "";
                    txtEstadoCivil.Text = "";
                    txtEstado.Text = "";
                    txtEndereco.Text = "";
                    txtData.Text = "";
                    txtCpf.Text = "";
                    txtCidade.Text = "";
                   

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
