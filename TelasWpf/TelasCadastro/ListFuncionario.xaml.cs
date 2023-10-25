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
    /// Lógica interna para ListFuncionario.xaml
    /// </summary>
    public partial class ListFuncionario : Window
    {
        public ListFuncionario()
        {
            InitializeComponent();
            Loaded+=ListFuncionario_Loaded;
        }

        private void ListFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new FuncionarioDAO();

                dgFuncionario.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelected = dgFuncionario.SelectedItem as Funcionario;

            var result = MessageBox.Show($"Deseja realmente remover a compra?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FuncionarioDAO();
                    dao.Delete(funcionarioSelected);
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
            var compraSelected = dgFuncionario.SelectedItem as Funcionario;

            var window = new cadastrarFuncionario();
            window.ShowDialog();
            LoadList();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new cadastrarFuncionario();
            newwindow.ShowDialog(); 
            Close();
        }
    }
}
