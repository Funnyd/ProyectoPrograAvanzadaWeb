using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace PollosHermanos.WEB.Pages.Empleado
{
    public class EliminarEmpleadoModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EliminarEmpleadoModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            return await OnPost(id);
        }

        public async Task<ActionResult> OnPost(Guid? id)
        {
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return Page();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarEmpleado");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            return await OnPostEmpleado(id);
        }

        public async Task<ActionResult> OnPostEmpleado(Guid? id)
        {
            if (id == null)
                return NotFound();
            if (!ModelState.IsValid)
                return Page();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarUsuario");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("MenuEmpleado");
        }
    }
}
