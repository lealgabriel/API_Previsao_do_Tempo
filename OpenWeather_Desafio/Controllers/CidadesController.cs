using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Climate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenWeather_Desafio.Data;


namespace OpenWeather_Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CidadesController(AppDbContext context)
        {
            _context = context;
        }

        public Cidade resultado = new Cidade();

        // GET: api/Cidades
        [HttpGet]

        public async Task<ActionResult<string>> GetCidade([FromQuery] string city)
        {

            if (city == null)
            {
                city = "sao paulo";

            }


            var search = from p in _context.Produtos
                         where p.Nome == city
                         select p;

            if (search != null)
            {
                foreach (var p in search)
                {
                    if (DateTime.Now.AddMinutes(-20) < p.Id)
                    {
                        return $"Clima em {p.Nome}:\nTemperatura atual: {p.Temp}\nTemperatura Máxima: {p.TempMax}\nTemperatura Mínima: {p.TempMin}";
                    }
                    

                }

            }


            

            HttpClient client = new HttpClient();
            var response = await client.GetAsync($@"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=c12b08a118f8f5b6a8ed7804575926c0");
            var content = await response.Content.ReadAsStringAsync();

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return StatusCode(404);
            }

            

            var temp = Welcome.FromJson(content);

            Cidade cidade = new Cidade(DateTime.Now, city, temp.Main.Temp, temp.Main.TempMax, temp.Main.TempMin);
            
            _context.Produtos.Add(cidade);
            await _context.SaveChangesAsync();
            
            return $"Clima em {city}:\nTemperatura atual: {cidade.Temp}\nTemperatura Máxima: {cidade.TempMax}\nTemperatura Mínima: {cidade.TempMin}";

            

        }

        // DELETE: api/Cidades/5
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
