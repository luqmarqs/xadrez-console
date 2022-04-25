using tabuleiro;
using xadrez;
using xadrez_console;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada)
    {
        try
        {
            Console.Clear();
            Tela.imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();

            Console.Clear();
            Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);


            Console.Write("Destino: ");
            Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeDestino(origem, destino);

            partida.realizaJogada(origem, destino);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Pressione enter para tentar novamente");
            Console.ReadLine();
        }
    }
    
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}
