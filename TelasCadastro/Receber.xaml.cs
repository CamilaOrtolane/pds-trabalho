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
    /// Lógica interna para Receber.xaml
    /// </summary>
    public partial class Receber : Window
    {
        public Receber()
        {
            InitializeComponent();
        }
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MenuPrincipal();
            newWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Recebimento rec = new Recebimento();
                rec.NomeVen = txtNome.Text;
                rec.DataVenc = Convert.ToDateTime(dpDataVen.Text);
                if (dpDataVen.SelectedDate != null)
                    rec.DataVenc = (DateTime)dpDataVen.SelectedDate;

                rec.Data = Convert.ToDateTime(dpData.Text);
                if (dpData.SelectedDate != null)
                    rec.Data = (DateTime)dpData.SelectedDate; ;
                rec.Parcela = txtParcela.Text;
                rec.Valor = Convert.ToDouble(txtValor.Text);
                rec.Status = txtStatus.Text;
                rec.Descrição = txtDescricao.Text;
                rec.TipoPagamento = txtTipoPaga.Text;
                

                RecebimentoDAO recebimentoDAO = new RecebimentoDAO();
                recebimentoDAO.Insert(rec);

                MessageBox.Show("Recebimento registrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja continuar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    var newWindow = new MenuPrincipal();
                    newWindow.Show();
                    Close();
                }
                else
                {
                    txtTipoPaga.Text = "";
                    txtStatus.Text = "";
                    txtParcela.Text = "";
                    txtNome.Text = "";
                    txtDescricao.Text = "";
                    txtValor.Text = "";
                    dpData.Text = "";
                    dpDataVen.Text = "";


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
    }
}
