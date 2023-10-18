using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelasWpf.Database;
using TelasWpf.interfaces;
using MySql.Data.MySqlClient;
using TelasWpf.Helpers;

namespace TelasWpf.Models
{
    internal class PagamentoDAO : IDAO<Pagamento>
    {

        private static Conexao conn;

        public PagamentoDAO()
        {
            conn = new Conexao();
        }

        void IDAO<Pagamento>.Delete(TelasWpf.Models.Pagamento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Pagamento WHERE id_pag = @id ";
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
        Pagamento IDAO<Pagamento>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Pagamento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Pagamento (nome_pag, data_pag, valor_pag) " +
                    "VALUES (@nome_pag, @data_pag, @valor_pag)";
                query.Parameters.AddWithValue("@nome_pag", t.NomePag);
                query.Parameters.AddWithValue("@data_pag", t.Data);
                query.Parameters.AddWithValue("@valor_pag", t.Valor);

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
        public List<Pagamento> List()
        {
            try
            {
                List<Pagamento> list = new List<Pagamento>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Pagamento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Pagamento()
                    {
                        Id = reader.GetInt32("id_pag"),
                        NomePag = DAOhelpers.GetString(reader, "nome_pag"),
                        Data = reader.GetDateTime("data_pag"),
                        Valor = DAOhelpers.GetDouble(reader, "valor_pag"),
                        

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


    
        void IDAO<Pagamento>.Update(TelasWpf.Models.Pagamento t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Pagamento>.Insert(Pagamento t)
        {
            throw new NotImplementedException();
        }
    }
}
