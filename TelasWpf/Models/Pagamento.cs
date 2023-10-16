using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasWpf.Models
{
    internal class Pagamento
    {
        public int Id { get; set; }
        public string NomeDes { get; set;}
        public DateTime Data { get; set;}
        public double Valor { get; set;}
        public string Descricao { get; set;}
        public string Status { get; set;}
        public string Parcela { get; set;}
        public string TipoPagamento { get; set;}

    }
}
