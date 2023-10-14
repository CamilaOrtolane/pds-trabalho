using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TelasWpf.interfaces;
using TelasWpf.Helpers;
using TelasWpf.Database;

namespace TelasWpf.Models
{
    internal class FornecedorDAO : IDAO<Fornecedor>
    {
        private static Conexao conn;
        
        public FornecedorDAO() 
        {
            conn = new Conexao();
        }  
        void IDAO<Fornecedor>.Delete(Fornecedor t)
        {
            throw new NotImplementedException();
        }

        Fornecedor IDAO<Fornecedor>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Fornecedor (nome_fantasia_for, razao_social_for, cnpj_for, cidade_for, estado_for) VALUES (@nome_fantasia_for, @razao_social_for, @cnpj_for, @cidade_for, @estado_for)";
                query.Parameters.AddWithValue("@nome_fantasia_for", t.NomeFantasia);
                query.Parameters.AddWithValue("@razao_social_for", t.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj_for", t.Cnpj);
                query.Parameters.AddWithValue("@cidade_for", t.Cidade);
                query.Parameters.AddWithValue("@estado_for", t.Estado);
                

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registo não foi inserido. Verifique e tente novamente");


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

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_for"),
                        RazaoSocial = DAOhelpers.GetString(reader, "nome_fantasia_for"),
                        NomeFantasia = DAOhelpers.GetString(reader, "razao_social_for"),
                        Cnpj = DAOhelpers.GetString(reader, "cnpj_for"),
                        Cidade = DAOhelpers.GetString(reader, "cidade_for"),
                        Estado = DAOhelpers.GetString(reader, "estado_for")
                    });
                }

                return list;
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


        void IDAO<Fornecedor>.Update(Fornecedor t)
        {
            throw new NotImplementedException();
        }

        void IDAO<Fornecedor>.Insert(Fornecedor t)
        {
            throw new NotImplementedException();
        }
    }
}
