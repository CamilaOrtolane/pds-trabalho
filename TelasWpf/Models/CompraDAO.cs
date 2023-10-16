using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        void IDAO<Compra>.Delete(TelasWpf.Models.Compra t)
        {
            throw new NotImplementedException();
        }
        Compra IDAO<Compra>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Compra t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Compra (nome_com, data_com, valor_com) " +
                    "VALUES (@nome_com, @data_com, @valor_com)";
                query.Parameters.AddWithValue("@nome_com", t.Nome);
                query.Parameters.AddWithValue("@data_com", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@valor_com", t.Valor);


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
             throw new NotImplementedException();


        }
        void IDAO<Compra>.Update(TelasWpf.Models.Compra t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Compra>.Insert(Compra t)
        {
            throw new NotImplementedException();
        }
    }
}
