using QuickMusic.EntidadesDeNegocio;
using QuickMusic.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuickMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeneroController : ControllerBase
    {
        private GeneroBL generoBL = new GeneroBL();

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await generoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Genero> Get(int id)
        {
            Genero genero = new Genero();
            genero.Id = id;
            return await generoBL.ObtenerPorIdAsync(genero);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            try
            {
                await generoBL.CrearAsync(genero);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Genero genero)
        {

            if (genero.Id == id)
            {
                await generoBL.ModificarAsync(genero);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Genero genero = new Genero();
                genero.Id = id;
                await generoBL.EliminarAsync(genero);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Genero>> Buscar([FromBody] object pGenero)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strGenero = JsonSerializer.Serialize(pGenero);
           Genero genero = JsonSerializer.Deserialize<Genero>(strGenero, option);
            return await generoBL.BuscarAsync(genero);

        }
    }
}