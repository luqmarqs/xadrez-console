using tabuleiro;
using xadrez;
using xadrez_console;

Tabuleiro tab = new Tabuleiro(8, 8);

tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));

Tela.imprimirTabuleiro(tab);