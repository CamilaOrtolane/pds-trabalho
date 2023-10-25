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
    /// Lógica interna para ListServico.xaml
    /// </summary>
    public partial class ListServico : Window
    {
        public ListServico()
        {
            InitializeComponent();
            Loaded+=ListServico_Loaded;
        }

        private void ListServico_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new ServicoDAO();

                dgServico.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = dgServico.SelectedItem as Servico;

            var result = MessageBox.Show($"Deseja realmente remover a compra?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ServicoDAO();
                    dao.Delete(servicoSelected);
                    LoadList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = dgServico.SelectedItem as Servico;

            var window = new cadastrarServico();
            window.ShowDialog();
            LoadList();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var window = new cadastrarServico();
            window.ShowDialog();
            Close();
        }
    }
}
