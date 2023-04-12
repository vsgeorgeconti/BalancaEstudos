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
    public class BalancaController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        public BalancaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("v1/balanca")]
        public async Task<IActionResult> GetAsync()
        {

            try
            {
                var balanca = await unitOfWork.Balancas.GetAllAsync();
                return Ok(balanca);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("v1/balanca/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var balanca = await unitOfWork.Balancas.GetByIdAsync(id);
                return Ok(balanca);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("v1/balanca")]
        public async Task<IActionResult> AddAsync([FromBody] Balanca balanca)
        {
            try
            {
                var bal = new Balanca()
                {
                    Nome = balanca.Nome,
                    Modelo = balanca.Modelo,
                };

                var data = await unitOfWork.Balancas.AddAsync(balanca);
                return Ok(data);

            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpDelete]
        [Route("v1/balanca/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var balanca = await unitOfWork.Balancas.DeleteAsync(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("v1/balanca}")]
        public async Task<IActionResult> UpdateAsync([FromBody] Balanca balanca)
        {
            try
            {
                var data = await unitOfWork.Balancas.UpdateAsync(balanca);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}