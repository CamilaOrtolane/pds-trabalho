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
using TelasWpf.Database;
using TelasWpf.Helpers;
using TelasWpf.interfaces;
using MySql.Data.MySqlClient;

namespace TelasWpf.TelasCadastro
{
    /// <summary>
    /// Lógica interna para cadastrarFuncionario.xaml
    /// </summary>
    public partial class cadastrarFuncionario : Window
    {
        public cadastrarFuncionario()
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
                Funcionario fun = new Funcionario();
                fun.Nome = txtNome.Text;
                fun.DataNasc = Convert.ToDateTime(dpData.Text);
                if (dpData.SelectedDate != null)
                    fun.DataNasc = (DateTime)dpData.SelectedDate;
                fun.Cpf = txtCpf.Text;
                fun.Rg = txtRg.Text;
                fun.Funcao = txtFuncao.Text;
                fun.CargaHoraria = txtCarga.Text;
                fun.Estado = txtEstado.Text;
                fun.EstadoCivil = txtEstCivi.Text;
                fun.Cidade = txtCidade.Text;
                fun.Setor = txtSetor.Text;
                fun.Telefone = txtTelefone.Text;
                fun.Salario = Convert.ToDouble(txtSalario.Text);


                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                funcionarioDAO.Insert(fun);

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
                    txtTelefone.Text = "";
                    txtSetor.Text = "";
                    txtSalario.Text = "";
                    txtRg.Text = "";
                    txtFuncao.Text = "";
                    txtEstCivi.Text = "";
                    txtEstado.Text = "";
                    txtCpf.Text = "";
                    txtCidade.Text = "";
                    txtCarga.Text = "";
                    dpData.Text = "";


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new ListFuncionario();
            newWindow.Show();
            Close();
        }
    }
}
