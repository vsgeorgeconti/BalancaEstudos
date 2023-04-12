using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BalancaEstudos.Domain
{
    public class Pesagem
    {
        public int Id { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoTara { get; set; }
        public decimal PesoLiquido { get; set; }
        [Write(false)]
        public Balanca Balanca { get; set; }
        public int BalancaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataAprovacao { get; set; }
        [Write(false)]
        public Usuario? UsuarioAprovacao { get; set; }
        public int UsuarioId { get; set; }

    }
}