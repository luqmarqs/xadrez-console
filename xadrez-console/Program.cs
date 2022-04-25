﻿using tabuleiro;
using xadrez;
using xadrez_console;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        Console.Clear();
        Tela.imprimirTabuleiro(partida.Tab);

        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

        bool[,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();

        Console.Clear();
        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);


        Console.Write("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

        partida.executaMovimento(origem, destino);
    }
    
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}
