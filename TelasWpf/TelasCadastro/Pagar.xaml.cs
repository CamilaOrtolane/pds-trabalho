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
    /// Lógica interna para Pagar.xaml
    /// </summary>
    public partial class Pagar : Window
    {
        public Pagar()
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
                Pagamento pag = new Pagamento();
                pag.NomeDes = txtDespesa.Text;
                pag.Data = Convert.ToDateTime(dpData.Text);
                if (dpData.SelectedDate != null)
                    pag.Data = (DateTime)dpData.SelectedDate; ;
                pag.Descricao = txtDescricao.Text;
                pag.Status = txtStatus.Text;
                pag.Parcela = txtParcela.Text;
                pag.Valor = Convert.ToDouble(txtValor.Text);
                pag.TipoPagamento = txttipoPag.Text;

                PagamentoDAO pagamentoDAO = new PagamentoDAO();
                pagamentoDAO.Insert(pag);

                MessageBox.Show("Pagamento adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    txttipoPag.Text = "";
                    txtStatus.Text = "";
                    txtParcela.Text = "";
                    txtDespesa.Text = "";
                    txtDescricao.Text = "";
                    dpData.Text = "";

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
