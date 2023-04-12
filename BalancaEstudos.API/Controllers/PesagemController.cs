using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure;
using BalancaEstudos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BalancaEstudos.API.Controllers
{
    [ApiController]
    public class PesagemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public PesagemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("v1/pesagem")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var dados = await unitOfWork.Pesagens.GetAllAsync();
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
                var dados = await unitOfWork.Pesagens.GetByIdAsync(id);
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
                var balanca = await unitOfWork.Balancas.GetByIdAsync(pesagem.BalancaId);
                if (balanca == null)
                    return NotFound("Balança não foi encontrada.");

                var entity = new Pesagem()
                {
                    PesoBruto = pesagem.PesoBruto,
                    PesoTara = pesagem.PesoTara,
                    PesoLiquido = pesagem.PesoLiquido,
                    BalancaId = balanca.Id,
                };

                var dados = await unitOfWork.Pesagens.AddAsync(entity);
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
                var dados = await unitOfWork.Pesagens.DeleteAsync(id);
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
                var dados = await unitOfWork.Pesagens.UpdateAsync(pesagem);
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
                var pesagem = await unitOfWork.Pesagens.GetByIdAsync(id);
                if (pesagem == null || pesagem.DataAprovacao != null)
                    return NotFound("Balança não foi encontrada ou já foi aprovada.");

                var dados = await unitOfWork.Pesagens.AprovacaoAsync(pesagem);
                return Ok(dados);
            }
            catch
            {
                return StatusCode(500);
            }
        }



    }
}