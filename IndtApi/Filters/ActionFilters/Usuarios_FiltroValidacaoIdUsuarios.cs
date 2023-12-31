﻿using IndtApi.Data;
using IndtApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IndtApi.Filters.ActionFilters
{
    public class Usuarios_FiltroValidacaoIdUsuarios : ActionFilterAttribute
    {
       

     
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var Id = context.ActionArguments["Id"] as int?;
            if (Id.HasValue)
            {
                if (Id.Value <= 0)
                {
                    context.ModelState.AddModelError("Id", "Id é invalido.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!UsuariosRepositorio.UsuariosExiste(Id.Value)) 
                {
                        context.ModelState.AddModelError("Id", "Id não existe.");
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
