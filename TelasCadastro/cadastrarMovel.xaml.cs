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
    /// Lógica interna para cadastrarMovel.xaml
    /// </summary>
    public partial class cadastrarMovel : Window
    {
        private int _id;

        private  Movel _movel;
        public cadastrarMovel()
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
                Movel movel = new Movel();
                movel.Nome = txtNomeMovel.Text;
                movel.Material = txtMaterial.Text;
                movel.Descricao = txtDescriMovel.Text;
                movel.Peso = txtPesoMovel.Text;
                movel.Comprimento = txtCompriMovel.Text;
                movel.Cor = txtCor.Text;
                movel.Altura = txtAltura.Text;
                movel.Largura = txtLargura.Text;
                movel.ValorCusto = txtCustoMovel.Text;
                movel.ValorTotal = txtValorMovel.Text;

                MovelDAO movelDAO = new MovelDAO();
                movelDAO.Insert(movel);
                MessageBox.Show("O movel foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    var newWindow = new MenuPrincipal();
                    newWindow.Show();
                    Close();
                }
                else
                {
                    txtNomeMovel.Text = "";
                    txtMaterial.Text = "";
                    txtDescriMovel.Text = "";
                    txtPesoMovel.Text = "";
                    txtCompriMovel.Text = "";
                    txtCor.Text = "";
                    txtAltura.Text = "";
                    txtLargura.Text = "";
                    txtCustoMovel.Text = "";
                    txtValorMovel.Text = "";

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
