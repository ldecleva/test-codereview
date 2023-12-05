using Dapper;
using Microsoft.AspNetCore.Mvc;
using test_codereview.Dto;
using test_codereview.Infrastructure;

namespace test_codereview.Controllers
{
    public class CotizacionController : Controller
    {

        [HttpGet("getcotizacion/{moneda}")]
        public IActionResult GetCotizacion([FromRoute] string moneda)
        {
            if (moneda == "usd")
            {
                using var httpClient = new HttpClient();

                var cotizacionApiClient = new BancoProvinciaClient(httpClient);

                try
                {
                    var a = cotizacionApiClient.GetCotizacion();

                    return Ok(new CotizacionResponse(a[0], a[1]));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else if (moneda == "real")
            {
                var dbContext = new DatabaseContext();

                var cotizacion = dbContext.GetConnection().Query<CotizacionResponse>("SELECT * FROM Cotizaciones");

                var real = cotizacion.Where(x => x.Moneda == "real").First();

                return Ok(real);

            }

            return BadRequest("Moneda invalida");
        }
    }
}
