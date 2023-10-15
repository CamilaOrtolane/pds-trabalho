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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
                fun.Salario = Convert.ToDouble(txtSalario.Text);
                fun.Funcao = txtFuncao.Text;
                fun.CargaHoraria  = txtCarga.Text;
                fun.EstadoCivil = txtEstCivi.Text;
                fun.Estado = txtEstado.Text;
                fun.Cidade = txtCidade.Text;
                fun.Setor = txtSetor.Text;
                fun.Telefone = txtTelefone.Text;
                fun.Cpf = txtCpf.Text;
                fun.Rg = txtRg.Text;

                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                funcionarioDAO.Insert(fun);

                MessageBox.Show("O Funcionario foi adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    txtSalario.Text = "";
                    txtSetor.Text = "";
                    txtTelefone.Text = "";
                    txtRg.Text = "";
                    txtFuncao.Text = "";
                    txtEstCivi.Text = "";
                    txtEstado.Text = "";
                    txtCpf.Text = "";
                    txtCarga.Text = "";
                    txtCidade.Text = "";
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
