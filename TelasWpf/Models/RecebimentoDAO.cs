using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TelasWpf.Database;
using TelasWpf.interfaces;

namespace TelasWpf.Models
{
    internal class RecebimentoDAO : IDAO<Recebimento>
    {
        private static Conexao conn;

        public RecebimentoDAO()
        {
            conn = new Conexao();
        }

        void IDAO<Recebimento>.Delete(TelasWpf.Models.Recebimento t)
        {
            throw new NotImplementedException();
        }
        Recebimento IDAO<Recebimento>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Recebimento t)
        {
            try
            {
                        // id_rec int primary key auto_increment,
                        //data_rec date,
                        //parcela_rec varchar(50),
                        //valor_rec double not null,
                        //vencimento_rec date,


                var query = conn.Query();
                query.CommandText = "INSERT INTO Recebimento (data_rec, parcela_rec, valor_rec, vencimento_rec) " +
                    "VALUES (@data_rec, @parcela_rec, @valor_rec, @vencimento_rec)";
                query.Parameters.AddWithValue("@data_rec", t.Data);
                query.Parameters.AddWithValue("@parcela_rec", t.Parcela);
                query.Parameters.AddWithValue("@valor_rec", t.Valor);
                query.Parameters.AddWithValue("@vencimento_rec", t.DataVenc);

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
        public List<Recebimento> List()
        {
            throw new NotImplementedException();
        }
        void IDAO<Recebimento>.Update(TelasWpf.Models.Recebimento t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Recebimento>.Insert(Recebimento t)
        {
            throw new NotImplementedException();
        }
    }
}
