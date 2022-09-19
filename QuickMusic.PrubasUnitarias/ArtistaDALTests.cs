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
    public class ArtistaDALTests
    {
        private static Artista artistainicial = new Artista { Id = 1 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var artista = new Artista();
            artista.Nombre = "Bruno";
            int result = await ArtistaDAL.CrearAsync(artista);
            Assert.AreNotEqual(0, result);
            artistainicial.Id = artista.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var artista = new Artista();
            artista.Id = artistainicial.Id;
            artista.Nombre = "Kathya";
            var result = await ArtistaDAL.ModificarAsync(artista);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtnerPorIdAsyncTest()
        {
            var artista = new Artista();
            artista.Id = artistainicial.Id;
            var resultArtista = await ArtistaDAL.ObtnerPorIdAsync(artista);
            Assert.AreEqual(artista.Id, resultArtista.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultArtistas = await ArtistaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultArtistas.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var artista = new Artista();
            artista.Nombre = "k";
            artista.Top_Aux = 10;
            var resultArtistas = await ArtistaDAL.BuscarAsync(artista);
            Assert.AreNotEqual(0, resultArtistas.Count);

        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var artista = new Artista();
            artista.Id = artistainicial.Id;
            int result = await ArtistaDAL.EliminarAsync(artista);
            Assert.AreNotEqual(0, result);
        }
    }
}