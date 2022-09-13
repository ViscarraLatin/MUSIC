using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickMusic.EntidadesDeNegocio;

namespace QuickMusic.AccesoADatos
{
    public class CancionesDAL
    {
        public static async Task<int> CrearAsync(Canciones pCanciones)
        {
            int result = 0;
            using (var bdContexto = new DBContexto())
            {
                bdContexto.Add(pCanciones);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Canciones pCanciones)
        {
            int result = 0;
            using (var bdContexto = new DBContexto())
            {
                var canciones = await bdContexto.Canciones.FirstOrDefaultAsync(s => s.Id == pCanciones.Id);
                canciones.Id_Artista = pCanciones.Id_Artista;
                canciones.Id_Genero = pCanciones.Id_Genero;
                canciones.Titulo = pCanciones.Titulo;
                bdContexto.Update(canciones);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Canciones pCanciones)
        {
            int result = 0;
            using (var bdContexto = new DBContexto())
            {
                var canciones = await bdContexto.Canciones.FirstOrDefaultAsync(s => s.Id == pCanciones.Id);

                bdContexto.Remove(canciones);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ObtenerPorIdAsync(Canciones pCanciones)
        {
            int result = 0;
            using (var bdContexto = new DBContexto())
            {
                var canciones = await bdContexto.Canciones.FirstOrDefaultAsync(s => s.Id == pCanciones.Id);
            }
            return result;
        }
        public static async Task<List<Canciones>> ObtenerTodosAsync()
        {
            var canciones = new List<Canciones>();
            using (var bdContexto = new DBContexto())
            {
                canciones = await bdContexto.Canciones.ToListAsync();
            }
            return canciones;

        }
        internal static IQueryable<Canciones> QuerySelect(IQueryable<Canciones> pQuery, Canciones pCanciones)
        {
            if (pCanciones.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCanciones.Id);
            if (pCanciones.Id_Artista > 0)
                pQuery = pQuery.Where(s => s.Id_Artista == pCanciones.Id_Artista);
            if (pCanciones.Id_Genero > 0)
                pQuery = pQuery.Where(s => s.Id == pCanciones.Id_Genero);
            //if (pCanciones.Titulo > 0)
            //pQuery = pQuery.Where(s => s.Titulo == pCanciones.Titulo);
            return pQuery;
        }
    }
}