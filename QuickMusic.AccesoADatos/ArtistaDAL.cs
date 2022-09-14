using Microsoft.EntityFrameworkCore;
using QuickMusic.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMusic.AccesoADatos
{
    public class ArtistaDAL
    {
        public static async Task<int> CrearAsync(Artista pArtista)
        {
            int result = 0;
            using (var bdContexto = new DBContexto())
            {
                bdContexto.Add(pArtista);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Artista pArtista)
        {
            int result = 0;
            using (var DBContexto = new DBContexto())
            {
                var artista = await DBContexto.Artista.FirstOrDefaultAsync(s => s.Id == pArtista.Id);
                artista.Nombre = pArtista.Nombre;
                DBContexto.Update(artista);
                result = await DBContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Artista pArtista)
        {
            int result = 0;
            using (var DBContexto = new DBContexto())
            {
                var artista = await DBContexto.Artista.FirstOrDefaultAsync(s => s.Id == pArtista.Id);
                DBContexto.Artista.Remove(artista);
                result = await DBContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Artista> ObtnerPorIdAsync(Artista pArtista) 
        {
            var artista = new Artista();
            using (var DBContexto = new DBContexto())
            {
                artista = await DBContexto.Artista.FirstOrDefaultAsync(s => s.Id == pArtista.Id);
            }
            return artista;
        }

        public static async Task<List<Artista>> ObtenerTodosAsync()
        {
            var artistas = new List<Artista>();
            using (var DBContexto = new DBContexto())
            {
               artistas = await DBContexto.Artista.ToListAsync();
            }
            return artistas;
        }

        internal static IQueryable<Artista> QuerySelect(IQueryable<Artista> pQuery, Artista pArtista)
        {
            if (pArtista.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pArtista.Id);
            if (!string.IsNullOrWhiteSpace(pArtista.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pArtista.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pArtista.Top_Aux > 0)
                pQuery = pQuery.Take(pArtista.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Artista>>  BuscarAsync(Artista pArtista)
        {
            var artistas = new List<Artista>();
            using (var DBContexto = new DBContexto())
            {
                var select = DBContexto.Artista.AsQueryable();
                select = QuerySelect(select, pArtista);
                artistas = await select.ToListAsync();
            }
            return artistas;
        }
    }
}
