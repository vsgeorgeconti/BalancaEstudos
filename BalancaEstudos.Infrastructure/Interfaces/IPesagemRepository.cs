using BalancaEstudos.Domain;

namespace BalancaEstudos.Infrastructure.Interfaces
{
    public interface IPesagemRepository : IRepository<Pesagem>
    {
        Task<int> AprovacaoAsync(Pesagem pesagem);
    }
}