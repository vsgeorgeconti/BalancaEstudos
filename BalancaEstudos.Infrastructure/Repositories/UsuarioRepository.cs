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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DapperContext _context;
        public UsuarioRepository(DapperContext context)
            => _context = context;
        public async Task<int> AddAsync(Usuario entity)
        {
            entity.DataInclusao = DateTime.Now;
            var sql = "Insert into Usuario (Login,Password, DataInclusao) VALUES (@Login,@Password,@DataInclusao)";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            };
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Usuario WHERE ID=@Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Usuario>> GetAllAsync()
        {
            var sql = "SELECT * FROM Usuario";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Usuario>(sql);
                return result.ToList();
            }
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Usuario WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Usuario>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Usuario entity)
        {
            entity.DataAlteracao = DateTime.Now;
            var sql = "UPDATE Usuario SET Login = @Login, Password = @Password, DataAlteracao = @DataAlteracao WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}