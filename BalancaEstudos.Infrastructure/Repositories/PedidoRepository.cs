using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BalancaEstudos.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DapperContext _context;
        public PedidoRepository(DapperContext context)
            => _context = context;
        public async Task<int> AddAsync(Pedido entity)
        {
            entity.DataInclusao = DateTime.Now;
            var sql = "Insert into Pedido (NumeroPedido,PlacaVeiculo,PesagemId,DataInclusao) VALUES (@NumeroPedido,@PlacaVeiculo,@PesagemId,@DataInclusao)";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            };
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Pedido WHERE ID = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Pedido>> GetAllAsync()
        {
            var sql = "SELECT * FROM Pedido";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QueryAsync<Pedido>(sql);
                return result.ToList();
            }
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Pedido WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Pedido>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Pedido entity)
        {
            entity.DataAlteracao = DateTime.Now;
            var sql = "UPDATE Pedido SET NumeroPedido = @NumeroPedido, PlacaVeiculo = @PlacaVeiculo, PesagemId = @PesagemId, DataAlteracao = @DataAlteracao WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}