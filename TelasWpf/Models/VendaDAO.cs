using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TelasWpf.Database;
using TelasWpf.Helpers;
using TelasWpf.interfaces;

namespace TelasWpf.Models
{
    class VendaDAO : IDAO<VendaAtri>
    {

        private static Conexao conn;

        public VendaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(TelasWpf.Models.VendaAtri t)
        {

            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM VendaAtri WHERE id_ven = @id ";
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
        VendaAtri IDAO<VendaAtri>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(VendaAtri t)
        {
            throw new NotImplementedException();

            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Venda (data_ven, valor_ven, descricao_ven, ) " +
                    "VALUES (@data_ven, @valor_ven, @descricao_ven)";
                query.Parameters.AddWithValue("@data_ven", t.Data);
                query.Parameters.AddWithValue("@descricao_ven", t.Descricao);
                query.Parameters.AddWithValue("@valor_ven", t.Valor);
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
        public List<VendaAtri> List()
        {
            try
            {
                List<VendaAtri> list = new List<VendaAtri>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM VendaAtri";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new VendaAtri()
                    {
                        Id = reader.GetInt32("id_ven"),
                        Data = reader.GetDateTime("data_ven"),
                        Descricao = DAOhelpers.GetString(reader, "descricao_ven"),
                        Valor = DAOhelpers.GetDouble(reader, "valor_ven")


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
        void IDAO<VendaAtri>.Update(TelasWpf.Models.VendaAtri t)
        {
            throw new NotImplementedException();
        }
        void IDAO<VendaAtri>.Insert(VendaAtri t)
        {
            throw new NotImplementedException();
        }
    }
}
