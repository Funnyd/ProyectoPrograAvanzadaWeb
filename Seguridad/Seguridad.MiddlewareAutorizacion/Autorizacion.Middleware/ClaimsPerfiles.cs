using Abstracciones.Modelos;
using Autorizacion.Abstracciones.Flujo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Autorizacion.Middleware
{
    public class ClaimsPerfiles
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private IAutorizacionFlujo _autorizacionFlujo;

        public ClaimsPerfiles(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAutorizacionFlujo autorizacionFlujo)
        { 
            _autorizacionFlujo = autorizacionFlujo;
            ClaimsIdentity appIdentity = await verificarAutorizacion(httpContext);
            httpContext.User.AddIdentity(appIdentity);
            await _next(httpContext);
        }

        private async Task<ClaimsIdentity> verificarAutorizacion(HttpContext httpContext)
        {
           var claims=new List<Claim>();
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {                
                await ObtenerRol(httpContext, claims);
            }
            var appIdentity=new ClaimsIdentity(claims);
            return appIdentity;
        }

        private async Task ObtenerRol (HttpContext httpContext, List<Claim> claims)
        {
            var roles = await obtenerInformacionRoles(httpContext);
            if (roles != null && roles.Any()) { 
            foreach (var rol in roles) {
                claims.Add(new Claim(ClaimTypes.Role, rol.Rol));
                }
            }
        }

        private async Task<IEnumerable<RolBase>> obtenerInformacionRoles(HttpContext httpContext)
        {
            var nombre = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var correo = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return await _autorizacionFlujo.ObtenerRolxUsuario(
                new Usuario {
                    Nombre = nombre,
                    Correo = correo
                });
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
