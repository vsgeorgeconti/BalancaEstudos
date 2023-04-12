using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;

namespace BalancaEstudos.Application.Services
{
    public class PesagemService : IPesagemService
    {
        private readonly IUnitOfWork unitOfWork;
        public PesagemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(Pesagem pesagem)
        {
            return await unitOfWork.Pesagens.AddAsync(pesagem);
        }

        public async Task<int> AprovacaoAsync(Pesagem pesagem)
        {
            return await unitOfWork.Pesagens.AprovacaoAsync(pesagem);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await unitOfWork.Pesagens.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Pesagem>> GetAllAsync()
        {
            return await unitOfWork.Pesagens.GetAllAsync();
        }

        public async Task<Pesagem> GetByIdAsync(int id)
        {
            return await unitOfWork.Pesagens.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Pesagem pesagem)
        {
            return await unitOfWork.Pesagens.UpdateAsync(pesagem);
        }
    }
}