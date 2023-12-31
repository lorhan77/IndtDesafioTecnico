using IndtApi.Models.Repositories;
using IndtApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using IndtApi.Data;

namespace IndtApi.Filters.ActionFilters
{
    public class Usuarios_FiltroValidacaoCriacaoUsuarios : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Usuarios_FiltroValidacaoCriacaoUsuarios(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            base.OnActionExecuting(context);

            var usuario = context.ActionArguments["usuario"] as Usuarios;

            if (usuario == null)
            {
                context.ModelState.AddModelError("Usuario", "objeto de Usuario é nulo");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var usuarioExiste = db.Usuarios.FirstOrDefault(x =>
                    !string.IsNullOrWhiteSpace(usuario.Email) &&
                    !string.IsNullOrWhiteSpace(x.Email) &&
                    x.Email.ToLower() == usuario.Email.ToLower() &&
                    !string.IsNullOrWhiteSpace(usuario.Senha) &&
                    !string.IsNullOrWhiteSpace(x.Senha) &&
                    x.Senha.ToLower() == usuario.Senha.ToLower());

                //UsuariosRepositorio.GetUsuariosByProperties(usuario.Email, usuario.Senha);
                if (usuarioExiste != null)
                {
                    context.ModelState.AddModelError("Usuario", "Usuario já existe");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }

                
            }


        }
    }

}
