using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancaEstudos.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IPesagemRepository Pesagens { get; }
        IUsuarioRepository Usuarios { get; }
        IBalancaRepository Balancas { get; }
        IPedidoRepository Pedidos { get; }
    }
}