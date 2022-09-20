using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickMusic.AccesoADatos;
using QuickMusic.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMusic.AccesoADatos.Tests
{
    [TestClass()]
    public class GeneroDALTests
    {
        private static Genero generoInicial = new Genero { Id = 2 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var genero = new Genero();
            genero.Nombre = "Rap";
            int result = await GeneroDAL.CrearAsync(genero);
            Assert.AreNotEqual(0, result);
            generoInicial.Id = genero.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            genero.Nombre = "Hip-Hop";
            int result = await GeneroDAL.ModificarAsync(genero);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            var resultGenero = await GeneroDAL.ObtenerPorIdAsync(genero);
            Assert.AreEqual(genero.Id, resultGenero.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultGeneros = await GeneroDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultGeneros.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var genero = new Genero();
            genero.Nombre = "H";
            genero.Top_Aux = 10;
            var resultGeneros = await GeneroDAL.BuscarAsync(genero);
            Assert.AreNotEqual(0, resultGeneros.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            int result = await GeneroDAL.EliminarAsync(genero);
            Assert.AreNotEqual(0, result);
        }
    }
}