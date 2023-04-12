using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Infrastructure.Interfaces;

namespace BalancaEstudos.Infrastructure.Extensions
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IPesagemRepository pesagemRepository, IUsuarioRepository usuarioRepository, IBalancaRepository balancaRepository, IPedidoRepository pedidoRepository)
        {
            Usuarios = usuarioRepository;
            Balancas = balancaRepository;
            Pesagens = pesagemRepository;
            Pedidos = pedidoRepository;
        }
        public IPesagemRepository Pesagens { get; }

        public IUsuarioRepository Usuarios { get; }

        public IBalancaRepository Balancas { get; }

        public IPedidoRepository Pedidos { get; }
    }
}