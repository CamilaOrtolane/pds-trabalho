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
    /// Lógica interna para Venda.xaml
    /// </summary>
    public partial class Venda : Window
    {
        public Venda()
        {
            InitializeComponent();
        }
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }

        private void txtSalvar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                VendaAtri ven = new VendaAtri();
                ven.Cliente = txtCliente.Text;
                ven.Data = Convert.ToDateTime(txtData.Text);
                if (txtData.SelectedDate != null)
                    ven.Data = (DateTime)txtData.SelectedDate;

                ven.Valor = Convert.ToDouble(txtValor.Text);
                ven.Descricao = txtDescricao.Text;
                ven.Funcionário = txtFuncionario.Text;
                ven.Numero = Convert.ToInt32(txtNumero.Text);
                ven.Servico = txtServico.Text;
                ven.Produto = txtProduto.Text;

                VendaDAO vendaDAO = new VendaDAO();
                vendaDAO.Insert(ven);

                MessageBox.Show("A compra foi adicionada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    var newWindow = new MenuPrincipal();
                    newWindow.Show();
                    Close();
                }
                else
                {
                    txtValor.Text = "";
                    txtProduto.Text = "";
                    txtNumero.Text = "";
                    txtFuncionario.Text = "";
                    txtDescricao.Text = "";
                    txtData.Text = "";
                    txtCliente.Text = "";
                    txtProduto.Text = "";


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void txtCliente_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
