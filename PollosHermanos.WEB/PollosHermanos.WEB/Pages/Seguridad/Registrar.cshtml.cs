using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reglas;
using System.Text.Json;

namespace PollosHermanos.WEB.Pages.Seguridad
{
    public class RegistrarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public RegistrarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public UsuarioRequest usuario { get; set; }
        [BindProperty]
        public ClienteRequest cliente { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            usuario.idRol = await ObtenerRolCliente("Cliente");
            var hash = Autenticacion.GenerarHash(usuario.Password);
            usuario.Password = Autenticacion.ObtenerHash(hash);
            var ClienteCompleto = new
            {
                Usuario = new
                {
                    usuario.Correo,
                    usuario.Password,
                    usuario.idRol
                },
                Cliente = new
                {
                    cliente.Nombre,
                    cliente.Direccion,
                    cliente.MetodoPago,
                }
            };

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPointsSeguridad", "Registro");
            var httpClient = new HttpClient();
            var respuesta = await httpClient.PostAsJsonAsync(endpoint, ClienteCompleto);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("../Index");
        }

        private async Task<Guid> ObtenerRolCliente(string rol)
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerRol");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, rol));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadFromJsonAsync<RolResponse>(new JsonSerializerOptions
                 { PropertyNameCaseInsensitive = true });

            return resultado.Id;
        }
    }
}

