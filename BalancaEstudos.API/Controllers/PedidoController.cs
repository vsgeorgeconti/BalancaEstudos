using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BalancaEstudos.API.Controllers
{
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IPesagemService _pesagemService;
        public PedidoController(IPedidoService pedidoService, IPesagemService pesagemService)
        {
            this._pedidoService = pedidoService;
            this._pesagemService = pesagemService;
        }

        [HttpGet]
        [Route("v1/pedido")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var dados = await _pedidoService.GetAsync();
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("v1/pedido/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var dados = await _pedidoService.GetByIdAsync(id);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        [Route("v1/pedido")]
        public async Task<IActionResult> AddAsync([FromBody] Pedido pedido)
        {
            try
            {
                var pesagem = await _pesagemService.GetByIdAsync(pedido.PesagemId);
                if (pesagem == null)
                    return BadRequest("Pesagem não foi encontrada.");

                var entity = new Pedido()
                {
                    NumeroPedido = pedido.NumeroPedido,
                    PlacaVeiculo = pedido.PlacaVeiculo,
                    PesagemId = pesagem.Id
                };

                var dados = await _pedidoService.AddAsync(pedido);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        [Route("v1/pedido/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var dados = await _pedidoService.DeleteAsync(id);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut]
        [Route("v1/pedido")]
        public async Task<IActionResult> UpdateAsync([FromBody] Pedido pedido)
        {
            try
            {
                var dados = await _pedidoService.UpdateAsync(pedido);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}