﻿using System;
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

        void IDAO<VendaAtri>.Delete(TelasWpf.Models.VendaAtri t)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();

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
