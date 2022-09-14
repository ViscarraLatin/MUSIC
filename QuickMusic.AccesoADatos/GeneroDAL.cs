using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickMusic.EntidadesDeNegocio;

namespace QuickMusic.AccesoADatos
{
    public class GeneroDAL
    {
        public static async Task<int> CrearAsync( Genero pGenero)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pGenero);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Genero pGenero)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var genero = await dbContexto.Genero.FirstOrDefaultAsync(s => s.Id == pGenero.Id);
                genero.Nombre = pGenero.Nombre;
                dbContexto.Update(genero);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Genero pGenero)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var genero = await dbContexto.Genero.FirstOrDefaultAsync(s => s.Id == pGenero.Id);
                dbContexto.Genero.Remove(genero);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Genero> ObtenerPorIdAsync(Genero pGenero)
        {
            var genero = new Genero();
            using (var dbContexto = new DBContexto())
            {
                genero = await dbContexto.Genero.FirstOrDefaultAsync(s => s.Id == pGenero.Id);
            }
            return genero;
        }

        public static async Task<List<Genero>> ObtenerTodosAsync()
        {
            var generos = new List<Genero>();
            using (var bdContexto = new DBContexto())
            {
                generos = await bdContexto.Genero.ToListAsync();
            }
            return generos;
        }

        internal static IQueryable<Genero> QuerySelect(IQueryable<Genero> pQuery, Genero pGenero)
        {
            if (pGenero.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pGenero.Id);

            if (!string.IsNullOrWhiteSpace(pGenero.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pGenero.Nombre));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pGenero.Top_Aux > 0)
                pQuery = pQuery.Take(pGenero.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Genero>> BuscarAsync(Genero pGenero)
        {
            var generos = new List<Genero>();
            using (var bdContexto = new DBContexto())
            {
                var select = bdContexto.Genero.AsQueryable();
                select = QuerySelect(select, pGenero);
                generos = await select.ToListAsync();
            }
            return generos;
        }
    }
}