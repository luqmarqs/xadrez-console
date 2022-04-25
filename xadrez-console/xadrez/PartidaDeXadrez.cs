using System;
using tabuleiro;


namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.retirarPeca(origem);
            p.incrementarMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            if (JogadorAtual != Tab.peca(pos).Cor)
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            if (!Tab.peca(pos).existeMovimentoPossivel())
                throw new TabuleiroException("Não existem movimentos possíveis para esta peça!");
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.peca(origem).podeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }

        private void mudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual= Cor.Preta;
        }

        private void colocarPecas()
        {
            Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('a', 1).toPosicao());
            Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('a', 7).toPosicao());
        }
    }
}
