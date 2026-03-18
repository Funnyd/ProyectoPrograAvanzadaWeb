using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reglas;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PollosHermanos.WEB.Pages.Empleado
{
    public class AgregarEmpleadoModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public AgregarEmpleadoModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public UsuarioRequest usuario { get; set; }
        [BindProperty]
        public EmpleadoRequest empleado { get; set; }
        [BindProperty]
        public List<SelectListItem> restaurantes { get; set; }
        [BindProperty]
        public Guid idRestaurante { get; set; }
        [BindProperty]
        public Guid idRol { get; set; }

        public async Task<ActionResult> OnGet()
        {
            await ObtenerRestaurantes();
            return Page();
        }

        // Metodo de agregar usuario
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            Guid idRolEncontrado = await ObtenerIdRol("Empleado");
            usuario.idRol = idRolEncontrado;
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "CrearUsuario");
            var cliente = ObtenerClienteConToken();
            var solicitud = new HttpRequestMessage(HttpMethod.Post, endpoint);
            var hash = Autenticacion.GenerarHash(usuario.Password);
            usuario.Password = Autenticacion.ObtenerHash(hash);
            var respuesta = await cliente.PostAsJsonAsync(endpoint, usuario);
            respuesta.EnsureSuccessStatusCode();
            var contenido = respuesta.Headers.Location.Segments.Last();
            return await OnPostEmpleado(Guid.Parse(contenido));
        }

        public async Task<ActionResult> OnPostEmpleado(Guid IdUsuario)
        {
            if (!ModelState.IsValid)
                return Page();
            empleado.idUsuario = IdUsuario;
            empleado.idRestaurante = idRestaurante;
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "CrearEmpleado");
            var cliente = ObtenerClienteConToken();
            var solicitud = new HttpRequestMessage(HttpMethod.Post, endpoint);
            var respuesta = await cliente.PostAsJsonAsync(endpoint, empleado);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }


        public async Task ObtenerRestaurantes()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerRestaurantes");
            var cliente = ObtenerClienteConToken();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint));
            var respuesta = await cliente.SendAsync(solicitud);
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };
            var resultadodeserializado = JsonSerializer.Deserialize<List<RestauranteResponse>>
                (resultado, opciones);
            restaurantes = resultadodeserializado.Select(m =>
            new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Ubicacion,
            }
            ).ToList();
        }

        private async Task<Guid> ObtenerIdRol(string rol)
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerRol");
            var cliente = ObtenerClienteConToken();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, rol));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadFromJsonAsync<RolResponse>(
                 new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });
            return resultado.Id;
        }


        private HttpClient ObtenerClienteConToken()
        {
            var tokenClaim = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "Token");
            var cliente = new HttpClient();
            if (tokenClaim != null)
                cliente.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer", tokenClaim.Value);
            return cliente;
        }
    }

    
}


