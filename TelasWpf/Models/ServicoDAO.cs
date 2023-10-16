﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelasWpf.Database;
using TelasWpf.interfaces;
using TelasWpf.Helpers;
using MySql.Data.MySqlClient;

namespace TelasWpf.Models
{
    internal class ServicoDAO : IDAO<Servico>
    {
        private static Conexao conn;

        public ServicoDAO()
        {
            conn = new Conexao();
        }

        void IDAO<Servico>.Delete(TelasWpf.Models.Servico t)
        {
            throw new NotImplementedException();
        }
        Servico IDAO<Servico>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Servico t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Servico (nome_ser, descricao_ser) " +
                    "VALUES (@nome_ser, @descricao_ser)";
                query.Parameters.AddWithValue("@nome_ser", t.Nome);
                query.Parameters.AddWithValue("@descricao_ser", t.Descricao);

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
        public List<Servico> List()
        {
            throw new NotImplementedException();
        }
        void IDAO<Servico>.Update(TelasWpf.Models.Servico t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Servico>.Insert(Servico t)
        {
            throw new NotImplementedException();
        }
    }
}
