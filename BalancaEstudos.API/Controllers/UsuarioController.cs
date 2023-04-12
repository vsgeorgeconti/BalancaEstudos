using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Domain;
using BalancaEstudos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BalancaEstudos.API.Controllers
{
    [ApiController]
    [Route("")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("v1/Usuarios")]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Usuarios.GetAllAsync();
            return Ok(data);
        }
        [HttpPost]
        [Route("v1/Usuarios")]
        public async Task<IActionResult> Post(
            [FromBody] Usuario usuario)
        {

            var user = new Usuario
            {
                Login = usuario.Login,
                Password = usuario.Password,
                DataInclusao = usuario.DataInclusao
            };
            var data = await unitOfWork.Usuarios.AddAsync(user);
            return Ok(data);
        }

        [HttpDelete]
        [Route("v1/Usuarios/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var data = await unitOfWork.Usuarios.DeleteAsync(id);
            return Ok($"Usuario {id} deletado");
        }

    }
}