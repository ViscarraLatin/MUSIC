using QuickMusic.EntidadesDeNegocio;
using QuickMusic.LogicaDeNegocio;
using QuickMusic.WebApi.Auth;
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
    public class CancionesController : ControllerBase
    {
        private CancionesBL cancionesBL = new CancionesBL();

        private readonly IJwtAuthenticationService authService;
        public CancionesController(IJwtAuthenticationService pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Canciones>> Get()
        {
            return await cancionesBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Canciones> Get(int id)
        {
            Canciones canciones = new Canciones();
            canciones.Id = id;
            return await cancionesBL.ObtenerPorIdAsync(canciones);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Canciones canciones)
        {
            try
            {
                await cancionesBL.CrearAsync(canciones);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pCanciones)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCanciones= JsonSerializer.Serialize(pCanciones);
            Canciones canciones = JsonSerializer.Deserialize<Canciones>(strCanciones, option);
            if (canciones.Id == id)
            {
                await cancionesBL.ModificarAsync(canciones);
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
                Canciones canciones = new Canciones();
                canciones.Id = id;
                await cancionesBL.EliminarAsync(canciones);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //MUY MALO XD
        [HttpPost("Buscar")]
        public async Task<List<Canciones>> Buscar([FromBody] object pCanciones)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCanciones = JsonSerializer.Serialize(pCanciones);
           Canciones canciones = JsonSerializer.Deserialize<Canciones>(strCanciones, option);
            var cancioness = await cancionesBL.BuscarIncluirGenerosAsync(canciones);
           cancioness.ForEach(s => s.Genero.Nombre = null); // Evitar la redundacia de datos
            var cancionesss = await cancionesBL.BuscarIncluirArtistasAsync(canciones);
            cancioness.ForEach(s => s.Artista.Nombre = null); // Evitar la redundacia de datos
            return cancioness;
        }

       

       
        
    }
}