using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest("Error, Debe ingresar una moneda");
        }
        [HttpGet("{moneda}")]
        public async Task<IActionResult> Get(string moneda)
        {

            if(moneda.ToString() != "dolar" && moneda.ToString() != "euro" && moneda.ToString() != "real")
            {
                return BadRequest("Error, entrada invalida");
            }
            else
            {
                string desde;
                switch (moneda){
                    case "dolar":
                        desde = "USD";
                    break;
                    case "euro":
                        desde = "EUR";
                    break;
                    case "real":
                        desde = "BRL";
                    break;
                    default:
                        return BadRequest("Error, entrada invalida");
                        break;
                }
                string hasta = "ARS";
                string apikey = "4845|nOWsH7QH8Lx7R0Oz_sA_jARxSz45ke^u";
                cotiz salida = new cotiz();

                var json = await client.GetStringAsync("http://api.cambio.today/v1/quotes/" + desde + "/" + hasta + "/json?quantity=1&key=" + apikey);
                var rta_api = JsonSerializer.Deserialize<vuelta>(json);

                //return Ok("Valor " + moneda + " contemplado");
                return Ok(new cotiz
                {
                    moneda = moneda.ToUpper(),
                    precio = rta_api.result.value.ToString().Replace(",", ".")
                }); ;
            }
            
        }

        private readonly HttpClient client = new HttpClient();

    }
}
