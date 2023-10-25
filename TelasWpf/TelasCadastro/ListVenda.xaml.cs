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
    /// Lógica interna para ListVenda.xaml
    /// </summary>
    public partial class ListVenda : Window
    {
        public ListVenda()
        {
            InitializeComponent();
            Loaded+=ListVenda_Loaded;
        }

        private void ListVenda_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new CompraDAO();

                dataGridVenda.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelected = dataGridVenda.SelectedItem as VendaAtri;

            var result = MessageBox.Show($"Deseja realmente remover a compra?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new VendaDAO();
                    dao.Delete(vendaSelected);
                    LoadList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
