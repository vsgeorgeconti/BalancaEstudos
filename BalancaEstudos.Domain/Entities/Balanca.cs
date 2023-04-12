using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancaEstudos.Domain
{
    public class Balanca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo  { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}