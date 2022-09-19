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
            using (var dbContexto = new DBContexto())
            {
                var canciones = await dbContexto.Canciones.FirstOrDefaultAsync(s => s.Id == pCanciones.Id);
                canciones.Id_Artista = pCanciones.Id_Artista;
                canciones.Id_Genero = pCanciones.Id_Genero;
                canciones.Titulo = pCanciones.Titulo;
                dbContexto.Update(canciones);
                result = await dbContexto.SaveChangesAsync();
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
        public static async Task<Canciones> ObtenerPorIdAsync(Canciones pCanciones)
        {
            var canciones = new Canciones();
            using (var bdContexto = new DBContexto())
            {
                canciones = await bdContexto.Canciones.FirstOrDefaultAsync(s => s.Id == pCanciones.Id);
            }
            return canciones;
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
           if (!String.IsNullOrWhiteSpace(pCanciones.Titulo))
            pQuery = pQuery.Where(s => s.Titulo == pCanciones.Titulo);
            return pQuery;
        }
        public static async Task<List<Canciones>> BuscarAsync(Canciones pCanciones)
        {
            var canciones = new List<Canciones>();
            using (var bdContexto = new DBContexto())
            {
                var select = bdContexto.Canciones.AsQueryable();
                select = QuerySelect(select, pCanciones);
                canciones = await select.ToListAsync();
            }
            return canciones;
        }
        public static async Task<List<Canciones>> BuscarIncluirArtistasAsync(Canciones pCanciones)
        {
            var Canciones = new List<Canciones>();
            using (var bdContexto = new DBContexto())
            {
                var select = bdContexto.Canciones.AsQueryable();
                select = QuerySelect(select, pCanciones).Include(s => s.Artista).AsQueryable();
                Canciones = await select.ToListAsync();
            }
            return Canciones;
        }
        public static async Task<List<Canciones>> BuscarIncluirGenerosAsync(Canciones pCanciones)
        {
            var Canciones = new List<Canciones>();
            using (var bdContexto = new DBContexto())
            {
                var select = bdContexto.Canciones.AsQueryable();
                select = QuerySelect(select, pCanciones).Include(s => s.Genero).AsQueryable();
                Canciones = await select.ToListAsync();
            }
            return Canciones;
        }

    }
}