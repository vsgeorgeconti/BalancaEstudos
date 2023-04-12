using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;

namespace BalancaEstudos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Delete(int id)
        {
            return await unitOfWork.Usuarios.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<Usuario>> GetAll()
        {
            return await unitOfWork.Usuarios.GetAllAsync();
        }

        public async Task<int> Post(Usuario usuario)
        {
            return await unitOfWork.Usuarios.AddAsync(usuario);
        }
    }
}