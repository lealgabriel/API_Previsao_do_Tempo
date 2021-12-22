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

        public async Task<ActionResult<double>> GetProdutos([FromQuery] string city)
        {
            if (city == null)
            {
                city = "sao paulo";
            }

            HttpClient client = new HttpClient();
            var response = await client.GetAsync($@"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=c12b08a118f8f5b6a8ed7804575926c0");
            var content = await response.Content.ReadAsStringAsync();

            var temp = Welcome.FromJson(content);

            resultado.Temp = temp.Main.Temp;

            Cidade cidade = new Cidade(4, city, resultado.Temp, resultado.TempMax, resultado.TempMin, DateTime.Now);





            _context.Produtos.Add(cidade);
            await _context.SaveChangesAsync();
            CreatedAtAction("GetCidade", new { id = cidade.Id }, cidade);


            return cidade.Temp;



        }







        // GET: api/Cidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(int id)
        {
            var cidade = await _context.Produtos.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // PUT: api/Cidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(int id, Cidade cidade)
        {
            /*if (id != cidade.Id)
            {
                return BadRequest();
            }

            _context.Entry(cidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/

            return NoContent();
        }

        // POST: api/Cidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cidade>> PostCidade(Cidade cidade)
        {
            _context.Produtos.Add(cidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = cidade.Id }, cidade);
        }

        // DELETE: api/Cidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
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

        /*private bool CidadeExists(int id)
        {
            //return _context.Produtos.Any(e => e.Id == id);
        }*/
    }
}
