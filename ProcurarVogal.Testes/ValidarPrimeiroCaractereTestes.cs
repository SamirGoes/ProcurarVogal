using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProcurarVogal.Testes
{
    [TestClass]
    public class ValidarPrimeiroCaractereTestes
    {
        [TestMethod]
        public void DeveRetornarNullQuandoNaoAcharVogal()
        {
            string input = "ccdfr";
            IStream myStream = new MyStream(input.ToString());

            char caractere = ValidarPrimeiroCaractere.FirstChar(myStream);

            Assert.AreEqual('\0', caractere);
        }

        [TestMethod]
        public void DeveRetornarNullQuandoContemMaisDeUmaVogal()
        {
            string input = "aaccadfrii";
            IStream myStream = new MyStream(input.ToString());

            char caractere = ValidarPrimeiroCaractere.FirstChar(myStream);

            Assert.AreEqual('\0', caractere);
        }

        [TestMethod]
        public void DeveRetornarPrimeiraVogalDoFimStream()
        {
            string input = "aAbBABacfe";
            IStream myStream = new MyStream(input.ToString());

            char caractere = ValidarPrimeiroCaractere.FirstChar(myStream);

            Assert.AreEqual('e', caractere);
        }

        [TestMethod]
        public void DeveRetornarNullQuandoVogalSomenteNoComecoStream()
        {
            string input = "abBBfdg";
            IStream myStream = new MyStream(input.ToString());

            char caractere = ValidarPrimeiroCaractere.FirstChar(myStream);

            Assert.AreEqual('\0', caractere);
        }

        [TestMethod]
        public void DeveRetornarNullQuandoExistemSomenteVogais()
        {
            string input = "aaeeiioouu";
            IStream myStream = new MyStream(input.ToString());

            char caractere = ValidarPrimeiroCaractere.FirstChar(myStream);

            Assert.AreEqual('\0', caractere);
        }
    }
}
