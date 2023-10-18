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
    /// Lógica interna para ListCompra.xaml
    /// </summary>
    public partial class ListCompra : Window
    {
        public ListCompra()
        {
            InitializeComponent();
            Loaded+= ListCompra_Loaded1;
        }

        private void ListCompra_Loaded1(object sender, RoutedEventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                var dao = new FuncionarioDAO();

                dataGridCompra.ItemsSource = dao.List();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CadastrarCompra();
            newWindow.Show();
            Close();
        }
    }
}
