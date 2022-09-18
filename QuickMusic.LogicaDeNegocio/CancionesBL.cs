using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMusic.EntidadesDeNegocio;
using QuickMusic.AccesoADatos;

namespace QuickMusic.LogicaDeNegocio
{
    public class CancionesBL
    {
        public async Task<int> CrearAsync(Canciones pCanciones)
        {
            return await CancionesDAL.CrearAsync(pCanciones);
        }
        public async Task<int> ModificarAsync(Canciones pCanciones)
        {
            return await CancionesDAL.ModificarAsync(pCanciones);
        }

        public async Task<int> EliminarAsync(Canciones pCanciones)
        {
            return await CancionesDAL.EliminarAsync(pCanciones);
        }
        public async Task<Canciones> ObtenerPorIdAsync(Canciones pCanciones)
        {
            return await CancionesDAL.ObtenerPorIdAsync(pCanciones);
        }

        public async Task<List<Canciones>> ObtenerTodosAsync()
        {
            return await CancionesDAL.ObtenerTodosAsync();
        }
        public async Task<List<Canciones>> BuscarIncluirArtistasAsync(Canciones pCanciones)
        {
            return await CancionesDAL.BuscarIncluirArtistasAsync(pCanciones);
        }
        public async Task<List<Canciones>> BuscarIncluirGenerosAsync(Canciones pCanciones)
        {
            return await CancionesDAL.BuscarIncluirGenerosAsync(pCanciones);
        }
    }
}
