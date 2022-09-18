using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickMusic.AccesoADatos;
using QuickMusic.EntidadesDeNegocio;

namespace QuickMusic.LogicaDeNegocio
{
    public class GeneroBL
    {
        public async Task<int> CrearAsync(Genero pGenero)
        {
            return await GeneroDAL.CrearAsync(pGenero);
        }

    

    public async Task<int> ModificarAsync(Genero pGenero)
    {
        return await GeneroDAL.ModificarAsync(pGenero);
    }
        public async Task<int> EliminarAsync(Genero pGenero)
        {
            return await GeneroDAL.EliminarAsync(pGenero);
        }

    public async Task<Genero>ObtenerPorIdAsync(Genero pGenero)
        {
            return await GeneroDAL.ObtenerPorIdAsync(pGenero);
}
        public async Task<List<Genero>>ObtenerTodosAsync()
        {
            return await GeneroDAL.ObtenerTodosAsync();
    }

        public async Task<List<Genero>> BuscarAsync(Genero pGenero)
        {
            return await GeneroDAL.BuscarAsync(pGenero);
        }
    }
}
