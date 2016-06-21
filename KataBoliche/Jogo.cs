namespace KataBoliche
{
    public class Jogo
    {
        private int[] Jogadas = new int[21];
        private int JogadaAtual = 0;

        public void FazerJogada(int pinosDerrubados)
        {
            Jogadas[JogadaAtual] = pinosDerrubados;
            JogadaAtual++;
        }

        public int Placar()
        {
            int placarAtual = 0;
            int bolaAtual = 0;

            for (int quadro = 0; quadro < 10; quadro++)
            {
                if (Strike(bolaAtual))
                {
                    placarAtual += ProximasDuasBolasParaStrike(bolaAtual);
                    bolaAtual++;
                }
                else if (Spare(bolaAtual))
                {
                    placarAtual += 10 + ProximaBolaParaSpare(bolaAtual);
                    bolaAtual += 2;
                }
                else
                {
                    placarAtual += DuasBolasParaQuadroAtual(bolaAtual);
                    bolaAtual += 2;
                }
            }

            return placarAtual;
        }

        private bool Strike(int i)
        {
            return Jogadas[i] == 10;
        }

        private int ProximasDuasBolasParaStrike(int bolaAtual)
        {
            return 10 + Jogadas[bolaAtual + 1] + Jogadas[bolaAtual + 2];
        }

        private bool Spare(int i)
        {
            return Jogadas[i] + Jogadas[i + 1] == 10;
        }

        private int ProximaBolaParaSpare(int bolaAtual)
        {
            return Jogadas[bolaAtual + 2];
        }

        private int DuasBolasParaQuadroAtual(int bolaAtual)
        {
            return Jogadas[bolaAtual] + Jogadas[bolaAtual + 1];
        }
    }
}