using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;
namespace BalancaEstudos.Application.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IReadOnlyList<Usuario>> GetAll();
        public Task<int> Post(Usuario usuario);
        public Task<int> Delete(int id);

    }
}