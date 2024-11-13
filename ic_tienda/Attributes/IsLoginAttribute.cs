using ic_tienda_bussines.Auth.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ic_tienda_presentacion.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IsLoginAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            UserAppProfile? profile = (UserAppProfile?)context.HttpContext.Items["profile"];
            if (profile == null)
            {
                context.Result = new JsonResult(new { code = "401", message = "No estas logeado" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
