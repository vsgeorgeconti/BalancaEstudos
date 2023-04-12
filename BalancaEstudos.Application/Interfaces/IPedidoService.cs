using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;

namespace BalancaEstudos.Application.Interfaces
{
    public interface IPedidoService
    {
        public Task<IReadOnlyList<Pedido>> GetAsync();
        public Task<Pedido> GetByIdAsync(int id);
        public Task<int> AddAsync(Pedido pedido);
        public Task<int> DeleteAsync(int id);
        public Task<int> UpdateAsync(Pedido pedido);

    }
}