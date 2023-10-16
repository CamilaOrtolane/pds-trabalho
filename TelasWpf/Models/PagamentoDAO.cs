using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelasWpf.Database;
using TelasWpf.interfaces;

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
            throw new NotImplementedException();
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
                query.Parameters.AddWithValue("@nome_pag", t.NomeDes);
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
            throw new NotImplementedException();

            
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
