using CadastroUsuario.Core.Base.Controller;
using CadastroUsuario.Model;
using CadastroUsuario.Service;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _usuarioService.Get();
            return Ok(res);
        }

        [HttpGet("GetEscolaridade")]
        public async Task<IActionResult> GetEscolaridade()
        {
            var res = await _usuarioService.GetEscolaridade();
            return Ok(res);
        }

        [HttpGet("UsuarioById/{id}")]
        public async Task<IActionResult> GetUsuarioById([FromRoute] Guid id)
        {
            var res = await _usuarioService.GetUsuarioById(id);
            return Ok(res);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateModel usuario)
        {
            var res = await _usuarioService.Create(usuario);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UsuarioModel usuario)
        {
            var res = await _usuarioService.Update(usuario);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var res = await _usuarioService.Delete(id);
            return Ok(res);
        }  
    }
}
