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
    class VendaDAO : IDAO<Venda>
    {

        private static Conexao conn;

        public VendaDAO()
        {
            conn = new Conexao();
        }

        void IDAO<Venda>.Delete(TelasWpf.Models.Venda t)
        {
            throw new NotImplementedException();
        }
        Venda IDAO<Venda>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Venda t)
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
        public List<Venda> List()
        {
            throw new NotImplementedException();

        }
        void IDAO<Venda>.Update(TelasWpf.Models.Venda t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Venda>.Insert(Venda t)
        {
            throw new NotImplementedException();
        }
    }
}
