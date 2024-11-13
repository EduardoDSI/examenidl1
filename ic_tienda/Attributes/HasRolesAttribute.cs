using ic_tienda_bussines.Auth.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ic_tienda_presentacion.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HasRolesAttribute : Attribute, IAuthorizationFilter
    {   
        List<string> roles;
        public HasRolesAttribute(params String[] strings)
        {
            this.roles = strings.ToList();


        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            UserAppProfile? profile = (UserAppProfile?)context.HttpContext.Items["profile"];
            if (profile == null)
            {
                context.Result = new JsonResult(new { code = "401", message = "No estas logeado" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            } else
            {
                string rolStr = profile.Rol.id.ToString();
                bool exist = this.roles.Exists(roles => roles.Contains(rolStr));
                if (!exist)
                {
                    context.Result = new JsonResult(new { code = "403", message = "No tienes permisos" })
                    {
                        StatusCode = StatusCodes.Status403Forbidden
                    };
                }
            }
        }
    }
}
