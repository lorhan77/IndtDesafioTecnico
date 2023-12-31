﻿using IndtApi.Data;
using IndtApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IndtApi.Filters.ExceptionsFilters
{
    public class Usuarios_FiltroExcecoesAtualizacao : ExceptionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Usuarios_FiltroExcecoesAtualizacao(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strId, out int Id))
            {
                if (db.Usuarios.FirstOrDefault(x => x.Id == Id) == null)
                {
                    context.ModelState.AddModelError("Id", "Id não existe mais.");
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
