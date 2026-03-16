using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace PollosHermanos.WEB.Pages.Empleado
{
    public class MenuEmpleadoModel : PageModel
    {
        private readonly IConfiguracion _configuracion;
        public MenuEmpleadoModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public IList<EmpleadoResponse> Empleados { get; set; }
        [BindProperty]
        public IList<UsuarioResponse> Usuarios { get; set; }
        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerEmpleados");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };
            Empleados = JsonSerializer.Deserialize<List<EmpleadoResponse>>
                (resultado, opciones);
        }


        

    }
}
