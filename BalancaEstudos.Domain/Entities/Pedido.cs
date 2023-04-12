using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BalancaEstudos.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; }
        public string PlacaVeiculo { get; set; }
        [Write(false) ]
        public Pesagem Pesagem { get; set; }
        public int PesagemId { get; set; } 
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}