﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess_console.tabuleiro;
using chess_console.xadrez;

namespace chess_console
{
    class Tela
    {

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {

                Console.Write(8 - i + " ");

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {   
                    ImprimirPeca(tabuleiro.Peca(i, j));   
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");

        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOrinal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {

                Console.Write(8 - i + " ");

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {

                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else 
                    {
                        Console.BackgroundColor = fundoOrinal;
                    }
                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOrinal;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOrinal;

        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine() ?? string.Empty;
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
        }

    }
}
