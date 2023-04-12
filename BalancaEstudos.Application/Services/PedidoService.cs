using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;

namespace BalancaEstudos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IUnitOfWork unitOfWork;
        public PedidoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(Pedido pedido)
        {
            return await unitOfWork.Pedidos.AddAsync(pedido);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await unitOfWork.Pedidos.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Pedido>> GetAsync()
        {
            return await unitOfWork.Pedidos.GetAllAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            return await unitOfWork.Pedidos.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Pedido pedido)
        {
            return await unitOfWork.Pedidos.UpdateAsync(pedido);
        }
    }
}