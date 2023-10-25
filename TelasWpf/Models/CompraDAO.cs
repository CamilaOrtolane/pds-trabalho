using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TelasWpf.Database;
using TelasWpf.Helpers;
using TelasWpf.interfaces;
using TelasWpf.TelasCadastro;

namespace TelasWpf.Models
{
    internal class CompraDAO : IDAO<Compra>
    {
        private static Conexao conn;

        public CompraDAO()
        {
            conn = new Conexao();
        }

       public void Delete(TelasWpf.Models.Compra t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Compra WHERE id_com = @id ";
                query.Parameters.AddWithValue("@id", t.Id);

                var resultado = query.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("O registro não foi removido. Verifique e tente novamente");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        Compra IDAO<Compra>.GetById(int id)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Compra WHERE id_com = @id";
                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                var compra = new Compra();

                while (reader.Read())
                {

                    compra.Id = reader.GetInt32("id_com");
                    compra.Nome = DAOhelpers.GetString(reader, "nome_com");
                    compra.Data = reader.GetDateTime("data_com");
                    compra.Valor = DAOhelpers.GetDouble(reader, "valor_com");

                }
                return compra;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Insert(Compra t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Compra (nome_com, data_com, valor_com, id_fun_fk, id_for_fk) " +
                    "VALUES (@nome_com, @data_com, @valor_com, @id_funcionario)";
                query.Parameters.AddWithValue("@nome_com", t.Nome);
                query.Parameters.AddWithValue("@data_com", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valor_com", t.Valor);
                query.Parameters.AddWithValue("@id_funcionario", t.Funcionario.Id);
                query.Parameters.AddWithValue("@id_fornecedor", t.Fornecedor.Id);


                var resultado = query.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Compra> List()
        {

            try
            {
                List<Compra> list = new List<Compra>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM compra LEFT JOIN funcionario ON id_fun = id_fun_fk ";
               // query.CommandText = "SELECT * FROM compra LEFT JOIN fornecedor ON id_for = id_for_fk ";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario() {
                        Id = reader.GetInt32("id_fun_fk"),
                        Nome = DAOhelpers.GetString(reader, "nome_fun"),

                    };
                    //var fornecedor = new Fornecedor()
                    //{
                    //    Id = reader.GetInt32("id_for_fk"),
                    //    NomeFantasia = DAOhelpers.GetString(reader, "nome_fantasia_for")
                    //};

                    list.Add(new Compra()
                    {
                        Id = reader.GetInt32("id_com"),
                        Nome = DAOhelpers.GetString(reader, "nome_com"),
                        Data = reader.GetDateTime("data_com"),
                        Valor = DAOhelpers.GetDouble(reader, "valor_com"),
                        Funcionario = funcionario,
                        //Fornecedor = fornecedor
                        
                    });


                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
        void IDAO<Compra>.Update(TelasWpf.Models.Compra t)
        {
            //throw new NotImplementedException();
            try
            {
            //    var funcionarioId = t.Funcionario.Id;
            //    var funDAO = new FuncionarioDAO();

            //    if (funcionarioId > 0)
            //        funDAO.Update(t.Funcionario);
            //    else
            //        funcionarioId = funDAO.Insert(t.Funcionario);

                var query = conn.Query();
                query.CommandText = "UPDATE compra SET nome_com = @nome, data_com = @data, valor_com = @valor, id_fun_fk = @idFuncionario, " +
                    "id_for_fk = @idFornecedor";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valor", t.Valor);
                query.Parameters.AddWithValue("@idFuncionario", t.Funcionario.Id);
                query.Parameters.AddWithValue("@idFornecedor", t.Fornecedor.Id);
                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }

        }
        void IDAO<Compra>.Insert(Compra t)
        {
            throw new NotImplementedException();
        }
    }
}
