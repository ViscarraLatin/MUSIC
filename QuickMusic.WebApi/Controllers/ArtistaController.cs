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
    public class ArtistaController : ControllerBase
    {
        private ArtistaBL artistaBL = new ArtistaBL();
        [HttpGet]
        public async Task<IEnumerable<Artista>> Get()
        {
            return await artistaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Artista> Get(int id)
        {
            Artista artista = new Artista();
            artista.Id = id;
            return await artistaBL.ObtenerPorIdAsync(artista);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Artista artista)
        {
            try
            {
                await artistaBL.CrearAsync(artista);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Artista artista)
        {

            if (artista.Id == id)
            {
                await artistaBL.ModificarAsync(artista);
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
                Artista artista = new Artista();
                artista.Id = id;
                await artistaBL.EliminarAsync(artista);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Artista>> Buscar([FromBody] object pArtista)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strArtista = JsonSerializer.Serialize(pArtista);
            Artista artista = JsonSerializer.Deserialize<Artista>(strArtista, option);
            return await artistaBL.BuscarAsync(artista);

        }


    }
}
