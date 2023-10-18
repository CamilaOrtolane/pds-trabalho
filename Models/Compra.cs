using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasWpf.Models
{
    internal class Compra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string CodigoProduto { get; set; }
        public string Funcionario { get; set; }
        public string Fornecedor { get; set; }
        public double Valor { get; set; }

    }
}
