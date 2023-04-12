using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
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
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("v1/Usuarios")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll();
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
            var data = await _service.Post(usuario);
            return Ok(data);
        }

        [HttpDelete]
        [Route("v1/Usuarios/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var data =  await _service.Delete(id);
            return Ok($"Usuario {id} deletado");
        }

    }
}