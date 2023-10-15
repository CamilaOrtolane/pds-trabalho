using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasWpf.Models
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Cpf { get; set; }
        public string Funcao { get; set; }
        public string CargaHoraria { get; set; }
        public string Setor { get; set; }
        public double Salario { get; set;}
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string EstadoCivil { get; set; }
        public string Rg { get; set; }
    }
}
