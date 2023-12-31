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
        private readonly ApplicationDbContext db;

        public UsuariosControllers(ApplicationDbContext db) 
        {
            this.db = db;
        }
 
        [HttpGet]
        [Route("/usuarios")]
        public IActionResult GetUsuarios()
        {
            return Ok(db.Usuarios.ToList());
        }

        [HttpGet]
        [Route("/usuarios/{id}")]
        [TypeFilter(typeof(Usuarios_FiltroValidacaoIdUsuarios))]
        public IActionResult GetUsuariosById(int id)
        {
            
            return Ok(HttpContext.Items["usuario"]) ;
        }

        [HttpPost]
        [Route("/usuarios")]
        [TypeFilter(typeof(Usuarios_FiltroValidacaoCriacaoUsuarios))]
        public IActionResult CreateUsuario([FromBody] Usuarios usuario)
        {
            this.db.Usuarios.Add(usuario);
            this.db.SaveChanges();
            
            return CreatedAtAction(nameof(GetUsuariosById),
                new { id = usuario.Id },
                usuario);

        }

        [HttpPut]
        [Route("/usuarios/{id}")]
        [TypeFilter(typeof(Usuarios_FiltroValidacaoIdUsuarios))]
        [Usuarios_FiltroValidacaoAtualizacaoUsuarios]
        [TypeFilter(typeof(Usuarios_FiltroExcecoesAtualizacao))]


        public IActionResult UpdateUsuario(int id, Usuarios usuario)
        {

            var usuarioToUpdate = HttpContext.Items["usuario"] as Usuarios;
            usuarioToUpdate.Nome = usuario.Nome;
            usuarioToUpdate.Sobrenome = usuario.Sobrenome;
            usuarioToUpdate.Email = usuario.Email;
            usuarioToUpdate.Senha = usuario.Senha;
            usuarioToUpdate.NivelDeAcesso = usuario.NivelDeAcesso;

            db.SaveChanges();


            return NoContent();
        }

        [HttpDelete]
        [Route("/usuarios/{id}")]
        [TypeFilter(typeof(Usuarios_FiltroValidacaoIdUsuarios))]

        public IActionResult DeleteUsuario(int id)
        {
            var usuarioToDelete = HttpContext.Items["usuario"] as Usuarios;

            db.Usuarios.Remove(usuarioToDelete);
            db.SaveChanges();

            return Ok(usuarioToDelete);
        }
    }
}

