﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelasWpf.Database;
using TelasWpf.interfaces;
using TelasWpf.Helpers;
using TelasWpf.TelasCadastro;
using MySql.Data.MySqlClient;

namespace TelasWpf.Models
{
    internal class FuncionarioDAO : IDAO<Funcionario>
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        void IDAO<Funcionario>.Delete(TelasWpf.Models.Funcionario t)
        {
            throw new NotImplementedException();
        }
        Funcionario IDAO<Funcionario>.GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Funcionario (nome_fun, data_nasc_fun, salario_fun, cpf_fun, rg_fun, estado_civil_fun, telefone_fun, setor_fun, carga_horaria_fun, funcao_fun, cidade_fun, estado_fun) " +
                    "VALUES (@nome_fun, @data_nasc_fun, @salario_fun, @cpf_fun, @rg_fun, @estado_civil_fun, @telefone_fun, @setor_fun, @carga_horaria_fun, @funcao_fun, @cidade_fun, @estado_fun)";
                query.Parameters.AddWithValue("@nome_fun", t.Nome);
                query.Parameters.AddWithValue("@data_fun", t.DataNasc.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@salario_fun", t.Salario);
                query.Parameters.AddWithValue("@cpf_fun", t.Cpf);
                query.Parameters.AddWithValue("@rg_fun", t.Rg);
                query.Parameters.AddWithValue("@estado_civil_fun", t.EstadoCivil);
                query.Parameters.AddWithValue("@telefone_fun", t.Telefone);
                query.Parameters.AddWithValue("@setor_fun", t.Setor);
                query.Parameters.AddWithValue("@carga_horaria_fun", t.CargaHoraria);
                query.Parameters.AddWithValue("@funcao_fun", t.Funcao);
                query.Parameters.AddWithValue("@cidade_fun", t.Cidade);
                query.Parameters.AddWithValue("@estado_fun", t.Estado);


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
        public List<Funcionario> List()
        {
            throw new NotImplementedException();

           
        }
        void IDAO<Funcionario>.Update(TelasWpf.Models.Funcionario t)
        {
            throw new NotImplementedException();
        }
        void IDAO<Funcionario>.Insert(Funcionario t)
        {
            throw new NotImplementedException();
        }
    }
}