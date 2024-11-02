using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Laboratorio.Data;
using Laboratorio.Entities;
using Laboratorio.DTOs;

public class RoleAuthorizationAttribute : ActionFilterAttribute
{
    private readonly string[] _allowedRoles;
    private readonly string _errorMessage;

    public RoleAuthorizationAttribute(string errorMessage, params string[] allowedRoles)
    {
        _allowedRoles = allowedRoles;
        _errorMessage = errorMessage;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var dbContext = context.HttpContext.RequestServices.GetService(typeof(RestauranteContext)) as RestauranteContext;

        var empleadoIdClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "EmpleadoId")?.Value;
        if (empleadoIdClaim == null || dbContext == null)
        {
            context.Result = new JsonResult(new { error = "No se pudo identificar al empleado autenticado o datos inválidos en la solicitud." })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            return;
        }

        int empleadoId = int.Parse(empleadoIdClaim);

        var empleado = dbContext.Empleados.FirstOrDefault(e => e.Id == empleadoId);
        if (empleado == null || !_allowedRoles.Contains(dbContext.Roles.FirstOrDefault(r => r.Id == empleado.RolId)?.Descripcion))
        {
            context.Result = new JsonResult(new { error = _errorMessage })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}
