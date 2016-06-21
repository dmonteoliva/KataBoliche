using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataBoliche
{
    [TestClass]
    public class BolicheTest
    {
        private Jogo j;

        private void FazerMuitasJogadas(int jogadas, int pinosDerrubados)
        {
            for (int i = 0; i < jogadas; i++)
                j.FazerJogada(pinosDerrubados);
        }

        [TestInitialize]
        public void IniciarJogo()
        {
            j = new Jogo();
        }

        [TestMethod]
        public void JogoVazio()
        {
            j.FazerJogada(0);
            Assert.AreEqual(0, j.Placar());
        }

        [TestMethod]
        public void AcertandoSempreUm()
        {
            FazerMuitasJogadas(20, 1);
            Assert.AreEqual(20, j.Placar());
        }

        [TestMethod]
        public void UmSpare()
        {
            j.FazerJogada(3);
            j.FazerJogada(7);
            j.FazerJogada(4);
            j.FazerJogada(2);

            Assert.AreEqual(20, j.Placar());
        }

        [TestMethod]
        public void UmStrike()
        {
            j.FazerJogada(10);
            j.FazerJogada(3);
            j.FazerJogada(6);

            Assert.AreEqual(28, j.Placar());
        }

        [TestMethod]
        public void JogoPerfeito()
        {
            FazerMuitasJogadas(20, 10);
            Assert.AreEqual(300, j.Placar());
        }
    }
}