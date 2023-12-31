using IndtApi.Data;
using IndtApi.Filters;
using IndtApi.Filters.ActionFilters;
using IndtApi.Filters.ExceptionsFilters;
using IndtApi.Models;
using IndtApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IndtApi.Controllers
{
    [ApiController]
   

    public class UsuariosControllers: ControllerBase
    {
        
 
        [HttpGet]
        [Route("/usuarios")]
        public IActionResult GetUsuarios()
        {
            return Ok(UsuariosRepositorio.GetUsuarios());
        }

        [HttpGet]
        [Route("/usuarios/{id}")]
        [Usuarios_FiltroValidacaoIdUsuarios]
        public IActionResult GetUsuariosById(int id)
        {
            return Ok(UsuariosRepositorio.GetUsuariosById(id)) ;
        }

        [HttpPost]
        [Route("/usuarios")]
        [Usuarios_FiltroValidacaoCriacaoUsuarios]
        public IActionResult CreateUsuario([FromBody] Usuarios usuario)
        {

            UsuariosRepositorio.AddUsuarios(usuario);

            return CreatedAtAction(nameof(GetUsuariosById),
                new { id = usuario.Id },
                usuario);

        }

        [HttpPut]
        [Route("/usuarios/{id}")]
        [Usuarios_FiltroValidacaoIdUsuarios]
        [Usuarios_FiltroValidacaoAtualizacaoUsuarios]


        public IActionResult UpdateUsuario(int id, Usuarios usuario)
        {
          

            try
            {
                UsuariosRepositorio.UpdateUsuario(usuario);
            }
            catch
            {
                if (!UsuariosRepositorio.UsuariosExiste(id))
                    return NotFound();

                throw;
            }
           

            return NoContent();
        }

        [HttpDelete]
        [Route("/usuarios/{id}")]
        [Usuarios_FiltroValidacaoIdUsuarios]


        public IActionResult DeleteUsuario(int id)
        {
            var usuario = UsuariosRepositorio.GetUsuariosById(id);
            UsuariosRepositorio.DeleteUsuario(id);
            
            return Ok(usuario);
        }
    }
}

