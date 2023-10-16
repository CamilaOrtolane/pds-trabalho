using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasWpf.Models
{
    internal class Recebimento
    {

        public int Id { get; set; } 
        public string NomeVen { get; set; }
        public string Descrição { get; set; }
        public string Status { get; set; }
        public double Valor { get; set; }
        public DateTime Data {  get; set; }
        public DateTime DataVenc {  get; set; }

        public string Parcela {  get; set; }
        public string TipoPagamento { get; set; }
    }
}
