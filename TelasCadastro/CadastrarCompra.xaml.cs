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
    /// Lógica interna para CadastrarCompra.xaml
    /// </summary>
    public partial class CadastrarCompra : Window
    {
        
        private List<Funcionario> funcionarios;

        //private List<Fornecedor> fornecedores;

        public CadastrarCompra()
        {
           InitializeComponent();
            Loaded += CadastrarCompra_Loaded;

        }

        private void CadastrarCompra_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

                Compra com = new Compra();
                com.Nome = txtNome.Text;
                com.Data = Convert.ToDateTime(dpData.Text);
                if (dpData.SelectedDate != null)
                    com.Data = (DateTime)dpData.SelectedDate;
                com.Valor = Convert.ToDouble(txtValor.Text);
                com.Funcionario = txtFuncio.Text;
                com.Fornecedor = txtForne.Text;

                com.CodigoProduto = txtCodProd.Text;

                CompraDAO compraDAO = new CompraDAO();
                compraDAO.Insert(com);

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
                    txtNome.Text = "";
                    txtValor.Text = "";
                    txtCodProd.Text = "";
                    txtForne.Text = "";
                    txtFuncio.Text = "";
                    dpData.Text = "";


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void cbFuncionario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new ListCompra();
            newWindow.Show();
            Close();
        }
    }
}
