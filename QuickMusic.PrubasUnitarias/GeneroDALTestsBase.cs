using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickMusic.AccesoADatos.Tests
{
    [TestClass]
    public class GeneroDALTestsBase
    {

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            var resultGenero = await GeneroDAL.ObtenerPorIdAsync(genero);
            Assert.AreEqual(genero.Id, resultGenero.Id);
        }
    }
}