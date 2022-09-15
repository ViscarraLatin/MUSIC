using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMusic.AccesoADatos;
using QuickMusic.EntidadesDeNegocio;

namespace QuickMusic.LogicaDeNegocio
{
   public class ArtistaBL
    {
        public async Task<int> CrearAsync(Artista pArtista)
        {
            return await ArtistaDAL.CrearAsync(pArtista);

        }
        public async Task<int> ModificararAsync(Artista pArtista)
        {
            return await ArtistaDAL.ModificarAsync(pArtista);

        }
        public async Task<int> EliminarAsync(Artista pArtista)
        {
            return await ArtistaDAL.EliminarAsync(pArtista);

        }

        public async Task<Artista> ObtenerPorIdAsync(Artista pArtista)
        {
            return await ArtistaDAL.ObtnerPorIdAsync(pArtista);
        }
        public async Task<List<Artista>> ObtenerTodosAsync()
        {
            return await ArtistaDAL.ObtenerTodosAsync();
        }
        public async Task<List<Artista>> BuscarAsync(Artista pArtista)
        {
            return await ArtistaDAL.BuscarAsync(pArtista);
        }
    }
}
