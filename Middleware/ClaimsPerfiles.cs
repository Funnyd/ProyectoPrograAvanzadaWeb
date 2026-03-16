using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    public class ClaimsPerfiles
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguracion _configuracion;
        private IAutenticacionFlujo _autenticacionFlujo;

        public ClaimsPerfiles(RequestDelegate next, IConfiguracion configuracion)
        {
            _next = next;
            _configuracion = configuracion;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAutenticacionFlujo autenticacionFlujo)
        {
            _autenticacionFlujo = autenticacionFlujo;
            ClaimsIdentity appIdentity = await verificarAutorizacion(httpContext);
            httpContext.User.AddIdentity(appIdentity);
            await _next(httpContext);
        }

        private async Task<ClaimsIdentity> verificarAutorizacion(HttpContext httpContext)
        {
            var claims = new List<Claim>();
            if(httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                await ObtenerPerfiles(httpContext, claims);
            }
            var appIdentity = new ClaimsIdentity(claims);
            return appIdentity;
        }

        private async Task ObtenerPerfiles(HttpContext httpContext, List<Claim> claims)
        {
            var perfiles = await obtenerInformacionPerfiles(httpContext);
            if (perfiles != null && perfiles.Any())
            {
                foreach (var perfil in perfiles) 
                {
                    claims.Add(new Claim(ClaimTypes.Role, perfil.Id.ToString()));
                }
            }
        }

        private async Task <IEnumerable<Perfil>> obtenerInformacionPerfiles(HttpContext httpContext)
        {
            return await _autenticacionFlujo.ObtenerPerfilesxUsuario(new Abstracciones.Modelos.Usuario {Correo = httpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value });
        }


    }
    public static class ClaimsUsuarioMiddlewareExtensions
    {
        public static IApplicationBuilder AutorizacionClaims(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClaimsPerfiles>();
        }

    }
}
