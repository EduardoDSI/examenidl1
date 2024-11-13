using ic_tienda_bussines.Auth.models;
using ic_tienda_data.Utils;
using System;

namespace ic_tienda.Middlewares {

    public class JwtMiddleware {
        private readonly RequestDelegate _next;
        //private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next) //, IConfiguration configuration
        {
            _next = next;
            //_configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? jwt = context.Request.Headers["Authorization"]
              .FirstOrDefault();
            if (jwt != null)
            {
                jwt = jwt.Trim().Replace("bearer ", "");
                try
                {
                    UserAppProfile user = JwtUtils.Decode(jwt);
                    context.Items["profile"] = user;

                } catch (Exception _)
                {

                }
            }


            //string? palabraMagica = context.Request.Headers["PalabraMagica"]
            //    .FirstOrDefault();

            //if (palabraMagica != null )
            //{
            //    context.Items["PalabraMagica"] = palabraMagica;
            //}
            await _next(context);
        }

    }
}