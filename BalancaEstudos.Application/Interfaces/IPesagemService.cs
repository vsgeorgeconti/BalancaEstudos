using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;

namespace BalancaEstudos.Application.Interfaces
{
    public interface IPesagemService
    {
        public Task<IReadOnlyList<Pesagem>> GetAllAsync();
        public Task<Pesagem> GetByIdAsync(int id);
        public Task<int> AddAsync(Pesagem pesagem);
        public Task<int> DeleteAsync(int id);
        public Task<int> UpdateAsync(Pesagem pesagem);
        public Task<int> AprovacaoAsync(Pesagem id);
    }
}