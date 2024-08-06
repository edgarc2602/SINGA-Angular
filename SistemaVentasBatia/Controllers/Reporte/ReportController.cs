using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SINGA.Controllers.Reporte
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("[action]/{idOrden}")]
        public async Task<IActionResult> DescargarReporteOrdenCompra(int idOrden = 0)
        {
            try
            {
                var url = "http://192.168.2.4/Reporte?%2freporteordencompra&rs:Format=PDF&idOrden=" + idOrden.ToString();
                var credentials = new NetworkCredential("Administrador", "GrupoBatia@");
                var handler = new HttpClientHandler { Credentials = credentials };
                using var client = new HttpClient(handler);
                var response = await client.GetAsync(url);
                // Asegúrate de que la solicitud sea exitosa
                response.EnsureSuccessStatusCode();
                // Lee el contenido de la respuesta
                var myDataBuffer = await response.Content.ReadAsByteArrayAsync();

                return new FileContentResult(myDataBuffer, "application/pdf")
                {
                    FileDownloadName = "ReporteOrdenMaterial" + idOrden.ToString() + ".pdf"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el archivo PDF: {ex.Message}");
                return StatusCode(500, "Error al obtener el archivo PDF");
            }
        }
    }
}
