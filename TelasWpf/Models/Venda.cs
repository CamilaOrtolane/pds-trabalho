using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasWpf.Models
{
    class Venda
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Funcionário { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Produto { get; set; }
        public string Servico { get; set; }
        public int Numero { get; set; }

    }
}
