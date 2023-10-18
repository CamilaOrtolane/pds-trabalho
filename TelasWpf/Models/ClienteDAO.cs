using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelasWpf.interfaces;
using TelasWpf.Database;
using TelasWpf.Helpers;
using MySql.Data.MySqlClient;
using System.Windows.Input;

namespace TelasWpf.Models
{
    class ClienteDAO : IDAO<Cliente>
    {
        private static Conexao conn;

        public ClienteDAO()
        {
            conn = new Conexao();
        }

        void IDAO<Cliente>.Delete(TelasWpf.Models.Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Cliente WHERE id_cli = @id ";
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
        Cliente IDAO<Cliente>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Cliente (nome_cli, cpf_cli, rg_cli, estado_civil_cli, telefone_cli, profissao_cli, cidade_cli, estado_cli, rua_cli, data_nasc_cli) " +
                    "VALUES (@nome_cli, @cpf_cli, @rg_cli, @estado_civil_cli, @telefone_cli, @profissao_cli, @cidade_cli, @estado_cli, @rua_cli, @data_nasc_cli)";
                query.Parameters.AddWithValue("@nome_cli", t.NomeCliente);
                query.Parameters.AddWithValue("@cpf_cli", t.Cpf);
                query.Parameters.AddWithValue("@rg_cli", t.Rg);
                query.Parameters.AddWithValue("@estado_civil_cli", t.EstadoCivil);
                query.Parameters.AddWithValue("@telefone_cli", t.Telefone);
                query.Parameters.AddWithValue("@profissao_cli", t.Profissao);
                query.Parameters.AddWithValue("@cidade_cli", t.Cidade);
                query.Parameters.AddWithValue("@estado_cli", t.Estado);
                query.Parameters.AddWithValue("@data_nasc_cli", t.DataNasc);
                query.Parameters.AddWithValue("@rua_cli", t.Endereco);

                var resultado = query.ExecuteNonQuery();
                if(resultado == 0)
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
        public List<Cliente> List()
        {

            try
            {

                List<Cliente> list = new List<Cliente>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Cliente()
                    {
                        Id = reader.GetInt32("id_cli"),
                        NomeCliente = DAOhelpers.GetString(reader, "nome_cli"),
                        Cpf = DAOhelpers.GetString(reader, "cpf_cli"),
                        Rg = DAOhelpers.GetString(reader, "rg_cli"),
                        Cidade = DAOhelpers.GetString(reader, "cidade_cli"),
                        Estado = DAOhelpers.GetString(reader, "estado_cli"),
                        DataNasc = reader.GetDateTime("data_nasc_cli"),
                        Profissao = DAOhelpers.GetString(reader, "profissao_cli"),
                        EstadoCivil = DAOhelpers.GetString(reader, "estado_civil_cli"),
                        Telefone = DAOhelpers.GetString(reader, "telefone_cli"),
                        Endereco = DAOhelpers.GetString(reader, "rua_cli")
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
        void IDAO<Cliente>.Update(TelasWpf.Models.Cliente t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Cliente>.Insert(Cliente t) 
        {
            throw new NotImplementedException();
        }

    }
}
