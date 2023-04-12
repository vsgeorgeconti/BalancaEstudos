using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;

namespace BalancaEstudos.Application.Interfaces
{
    public interface IBalancaService
    {
        public Task<IReadOnlyList<Balanca>> GetAsync();
        public Task<Balanca> GetByIdAsync(int id);
        public Task<int> AddAsync(Balanca balanca);
        public Task<int> DeleteAsync(int id);
        public Task<int> UpdateAsync(Balanca balanca);

    }
}