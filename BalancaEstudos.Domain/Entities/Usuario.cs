using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancaEstudos.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}