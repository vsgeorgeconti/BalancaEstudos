using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Extensions;
using BalancaEstudos.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BalancaEstudos.Infrastructure.Repositories
{
    public class BalancaRepository : IBalancaRepository
    {
        private readonly DapperContext _context;
        public BalancaRepository(DapperContext context)
            => _context = context;
        public async Task<int> AddAsync(Balanca entity)
        {
            entity.DataInclusao = DateTime.Now;
            var sql = "Insert into Balanca (Nome,Modelo,DataInclusao) VALUES (@Nome,@Modelo,@DataInclusao)";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            };
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Balanca WHERE ID = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Balanca>> GetAllAsync()
        {
            var sql = "SELECT * FROM Balanca";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Balanca>(sql);
                return result.ToList();
            }
        }

        public async Task<Balanca> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Balanca WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Balanca>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Balanca entity)
        {
            entity.DataAlteracao = DateTime.Now;
            var sql = "UPDATE Balanca SET Nome = @Nome, Modelo = @Modelo, DataAtualizacao = @DataAtualizacao WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}