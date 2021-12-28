using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Climate;
using Microsoft.AspNetCore.Mvc;
using OpenWeather_Desafio.Data;


namespace OpenWeather_Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient client = new HttpClient();

        public CidadesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetCidade([FromQuery] string city)
        {
            if (city == null)
            {
                city = "sao paulo";

            }

            var search = from p in _context.Produtos
                         where p.Nome.Equals(city)
                         select p;

            if (search != null)
            {
                foreach (var p in search)
                {
                    if (DateTime.Now.AddMinutes(-20) < p.Id)
                    {
                        return $"Clima em {p.Nome}:\n" +
                            $"Temperatura atual: {p.Temp}\n" +
                            $"Temperatura Máxima: {p.TempMax}\n" +
                            $"Temperatura Mínima: {p.TempMin}";
                    }
                    else
                    {
                        _context.Produtos.Remove(p);
                    }
                }
            }


            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            var response = await client.GetAsync($@"weather?q={city}&units=metric&appid=c12b08a118f8f5b6a8ed7804575926c0");
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return StatusCode(404);
            }
            else
            {
                var temp = Welcome.FromJson(content);
                Cidade cidade = new Cidade(DateTime.Now, city, temp.Main.Temp, temp.Main.TempMax, temp.Main.TempMin);
                _context.Produtos.Add(cidade);
                await _context.SaveChangesAsync();

                return $"Clima em {city}:\n" +
                    $"Temperatura atual: {cidade.Temp}\n" +
                    $"Temperatura Máxima: {cidade.TempMax}\n" +
                    $"Temperatura Mínima: {cidade.TempMin}";
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(DateTime id)
        {
            var cidade = await _context.Produtos.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(cidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
