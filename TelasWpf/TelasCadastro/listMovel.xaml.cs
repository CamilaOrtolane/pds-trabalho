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
    /// Lógica interna para listMovel.xaml
    /// </summary>
    public partial class listMovel : Window
    {
        public listMovel()
        {
            InitializeComponent();
            Loaded+=ListMovel_Loaded;
        }

        private void ListMovel_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                var dao = new MovelDAO();

                dgMovel.ItemsSource = dao.List();
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
            var movelSelected = dgMovel.SelectedItem as Movel;

            var result = MessageBox.Show($"Deseja realmente remover a compra?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new MovelDAO();
                    dao.Delete(movelSelected);
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

            var movelSelected = dgMovel.SelectedItem as Movel;

            var window = new cadastrarMovel();
            window.ShowDialog();
            CarregarDados();
        }
    }
}
