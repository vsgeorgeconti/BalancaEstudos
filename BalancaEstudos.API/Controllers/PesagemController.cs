using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure;
using BalancaEstudos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BalancaEstudos.API.Controllers
{
    [ApiController]
    public class PesagemController : ControllerBase
    {
        private readonly IPesagemService _pesagemService;
        private readonly IBalancaService _balancaService;
        public PesagemController(IPesagemService pesagemService, IBalancaService balancaService)
        {
            this._pesagemService = pesagemService;
            this._balancaService = balancaService;
        }

        [HttpGet]
        [Route("v1/pesagem")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var dados = await _pesagemService.GetAllAsync();
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("v1/pesagem/{id:int}")]
        public async Task<IActionResult> GetByIdAync([FromRoute] int id)
        {
            try
            {
                var dados = await _pesagemService.GetByIdAsync(id);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("v1/pesagem")]
        public async Task<IActionResult> AddAsync([FromBody] Pesagem pesagem)
        {
            try
            {
                var balanca = await _balancaService.GetByIdAsync(pesagem.BalancaId);
                if (balanca == null)
                    return NotFound("Balança não foi encontrada.");

                var entity = new Pesagem()
                {
                    PesoBruto = pesagem.PesoBruto,
                    PesoTara = pesagem.PesoTara,
                    PesoLiquido = pesagem.PesoLiquido,
                    BalancaId = balanca.Id,
                };

                var dados = await _pesagemService.AddAsync(entity);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("v1/pesagem/{id:int}")]
        public async Task<IActionResult> DeleteAync([FromRoute] int id)
        {
            try
            {
                var dados = await _pesagemService.DeleteAsync(id);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("v1/pesagem")]
        public async Task<IActionResult> UpdateAsync([FromBody] Pesagem pesagem)
        {
            try
            {
                var dados = await _pesagemService.UpdateAsync(pesagem);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        [Route("v1/pesagem/aprovacao/{id:int}")]
        public async Task<IActionResult> AprovacaoAsync([FromRoute] int id)
        {
            try
            {
                var pesagem = await _pesagemService.GetByIdAsync(id);
                if (pesagem == null || pesagem.DataAprovacao != null)
                    return NotFound("Balança não foi encontrada ou já foi aprovada.");

                var dados = await _pesagemService.AprovacaoAsync(pesagem);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }



    }
}