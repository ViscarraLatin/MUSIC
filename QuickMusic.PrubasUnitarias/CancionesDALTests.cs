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
    public class CancionesDALTests
    {
        private static Canciones cancionInicial = new Canciones
        {
            Id = 4,
            Id_Artista = 2,
            Id_Genero = 4,
        };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id_Artista = cancionInicial.Id_Artista;
            canciones.Id_Genero = cancionInicial.Id_Genero;
            canciones.Titulo = "Eminem";
            int result = await CancionesDAL.CrearAsync(canciones);
            Assert.AreNotEqual(0, result);
            cancionInicial.Id = canciones.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id = cancionInicial.Id;
            canciones.Id_Artista = cancionInicial.Id_Artista;
            canciones.Id_Genero = cancionInicial.Id_Genero;
            canciones.Titulo = "Lose yourself";
            int result = await CancionesDAL.ModificarAsync(canciones);
            Assert.AreNotEqual(0, result);
           
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id = cancionInicial.Id;
            var reultCanciones = await CancionesDAL.ObtenerPorIdAsync(canciones);
            Assert.AreEqual(canciones.Id, reultCanciones.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var reultCanciones = await CancionesDAL.ObtenerTodosAsync();
            Assert.AreEqual(0, reultCanciones.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id_Artista = cancionInicial.Id_Artista;
            canciones.Titulo = "i";
            var resultCanciones = await CancionesDAL.BuscarAsync(canciones);
            Assert.AreEqual(0, resultCanciones.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirArtistasAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id_Artista = cancionInicial.Id_Artista;
            canciones.Titulo = "Lose";
            var resultCanciones = await CancionesDAL.BuscarIncluirArtistasAsync(canciones);
            Assert.AreNotEqual(0, resultCanciones.Count);
            var ultimoCanciones = resultCanciones.FirstOrDefault();
            Assert.IsTrue(ultimoCanciones.Artista != null && canciones.Id_Artista == ultimoCanciones.Artista.Id);
        }

        [TestMethod()]
        public async Task T7BuscarIncluirGenerosAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id_Genero = cancionInicial.Id_Genero;
            canciones.Titulo = "Lose";
            var resultCanciones = await CancionesDAL.BuscarIncluirGenerosAsync(canciones);
            Assert.AreNotEqual(0, resultCanciones.Count);
            var ultimoCanciones = resultCanciones.FirstOrDefault();
            Assert.IsTrue(ultimoCanciones.Genero != null && canciones.Id_Genero == ultimoCanciones.Genero.Id);
        }

        [TestMethod()]
        public async Task T8EliminarAsyncTest()
        {
            var canciones = new Canciones();
            canciones.Id = cancionInicial.Id;
            int result = await CancionesDAL.EliminarAsync(canciones);
            Assert.AreNotEqual(0, result);
        }
    }
}