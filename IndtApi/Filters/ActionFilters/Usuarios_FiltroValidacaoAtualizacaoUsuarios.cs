using IndtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IndtApi.Filters.ActionFilters
{
    public class Usuarios_FiltroValidacaoAtualizacaoUsuarios : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["Id"] as int?;
            var usuario = context.ActionArguments["usuario"] as Usuarios;

            if (id.HasValue && usuario != null && id != usuario.Id)
            {
                context.ModelState.AddModelError("Id", "Ids com valores direntes.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
