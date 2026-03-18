using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace PollosHermanos.WEB.Pages.Empleado
{
    [Authorize(Roles = "Administrador")]
    public class EditarEmpleadoModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EditarEmpleadoModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public EmpleadoResponse empleado { get; set; }
        [BindProperty]
        public UsuarioResponse usuario { get; set; }
        public List<SelectListItem> restaurantes { get; set; }
        [BindProperty]
        public Guid idDelRestaurante { get; set; }
        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == Guid.Empty)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerEmpleadoPorId");
            var cliente = ObtenerClienteConToken();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                await ObtenerRestaurantes();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true };
                empleado = JsonSerializer.Deserialize<EmpleadoResponse>
                    (resultado, opciones);
                if (empleado != null)
                {
                    var restaurante = restaurantes.FirstOrDefault(m => m.Text == empleado.Ubicacion);
                    idDelRestaurante = Guid.Parse(restaurante.Value);
                }
                
            }
            return await OnGetUsuario(empleado.idUsuario);
        }

        public async Task<ActionResult> OnGetUsuario(Guid? id)
        {
            if (id == Guid.Empty)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerUsuarioPorId");
            var cliente = ObtenerClienteConToken();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                await ObtenerRestaurantes();
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true };
                usuario = JsonSerializer.Deserialize<UsuarioResponse>
                    (resultado, opciones);
            }
            return Page();

        }

        public async Task<ActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
                return Page();
            string endpoint = _configuracion.ObtenerMetodo("APIEndPoints", "EditarEmpleado");
            var cliente = ObtenerClienteConToken();
            var respuesta = await cliente.PutAsJsonAsync<EmpleadoRequest>(string.Format(endpoint, empleado.idUsuario), new EmpleadoRequest
            {
                Nombre = empleado.Nombre,
                idRestaurante = idDelRestaurante
            });
            respuesta.EnsureSuccessStatusCode();
            return await OnPostUsuario(usuario.Id);
        }

        public async Task<ActionResult> OnPostUsuario(Guid idUsuario)
        {
            if (!ModelState.IsValid)
                return Page();
            string endpoint = _configuracion.ObtenerMetodo("APIEndPoints", "EditarUsuario");
            var cliente = ObtenerClienteConToken();
            var respuesta = await cliente.PutAsJsonAsync<UsuarioRequest>(string.Format(endpoint, idUsuario), new UsuarioRequest
            {
                Correo = usuario.Correo,
                Password = usuario.Password,
                idRol = usuario.idRol
            });
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./");
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
