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
    /// Lógica interna para ListFornecedor.xaml
    /// </summary>
    public partial class ListFornecedor : Window
    {
        public ListFornecedor()
        {
            InitializeComponent();
            CarregarDados();


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CarregarDados()
        {
            try
            {
                var dao = new FornecedorDAO();

                dgFornecedor.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelected = dgFornecedor.SelectedItem as Fornecedor;

            var result = MessageBox.Show($"Deseja realmente remover a compra?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(fornecedorSelected);
                    CarregarDados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelected = dgFornecedor.SelectedItem as Fornecedor;

            var window = new CadastrarCompra();
            window.ShowDialog();
            CarregarDados();
        }
    }
}
