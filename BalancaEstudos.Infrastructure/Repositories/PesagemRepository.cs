using System.Data;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Extensions;
using BalancaEstudos.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BalancaEstudos.Infrastructure.Repositories
{
    public class PesagemRepository : IPesagemRepository
    {
        private readonly DapperContext _context;
        public PesagemRepository(DapperContext context)
            => _context = context;

        public async Task<int> AddAsync(Pesagem entity)
        {
            entity.DataInclusao = DateTime.Now;
            var sql = "Insert into Pesagem (PesoBruto,PesoTara,PesoLiquido,BalancaId,UsuarioId,DataInclusao) VALUES (@PesoBruto,@PesoTara,@BalancaId,@UsuarioId,@DataInclusao)";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            };
        }
 
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Pesagem WHERE ID = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Pesagem>> GetAllAsync()
        {
            var sql = "SELECT * FROM Pesagem";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Pesagem>(sql);
                return result.ToList();
            }
        }

        public async Task<Pesagem> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Pesagem WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Pesagem>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Pesagem entity)
        {
            entity.DataAlteracao = DateTime.Now;
            var sql = "UPDATE Pesagem SET PesoBruto = @PesoBruto, PesoTara = @PesoTara, PesoLiquido = @PesoLiquido, BalancaId = @BalancaId, UsuarioId = @UsuarioId, DataAlteracao = @DataAlteracao WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> AprovacaoAsync(Pesagem entity)
        {
            entity.DataAlteracao = DateTime.Now;
            var sql = "UPDATE Pesagem SET DataAprovacao = @DataAprovacao WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}