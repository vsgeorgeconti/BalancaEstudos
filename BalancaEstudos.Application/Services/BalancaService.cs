using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;

namespace BalancaEstudos.Application.Services
{
    public class BalancaService : IBalancaService
    {
        private readonly IUnitOfWork unitOfWork;
        public BalancaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(Balanca balanca)
        {
            return await unitOfWork.Balancas.AddAsync(balanca);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await unitOfWork.Balancas.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Balanca>> GetAsync()
        {
            return await unitOfWork.Balancas.GetAllAsync();
        }

        public async Task<Balanca> GetByIdAsync(int id)
        {
            return await unitOfWork.Balancas.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Balanca balanca)
        {
            return await unitOfWork.Balancas.UpdateAsync(balanca);
        }
    }
}