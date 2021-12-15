using System;
using static System.Console;
using TicTacToeLib;

namespace TicTacToeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticTacToeBoard = new Board(3, 3);

            string inputAsString;

            Write("Player 1, please input your symbol: ");
            inputAsString = ReadLine();
            var player1 = new Player(inputAsString);

            Write("Player 2, please input your symbol: ");
            inputAsString = ReadLine();
            var player2 = new Player(inputAsString);

            WriteLine("The game starts.....");
            WriteLine("Instructions:");
            WriteLine("The board has the size 3x3");
            WriteLine("Every player will enter the position of the desired cell.");
            WriteLine("Use the digits 1 through 9 to address the cell, like the number pad on the keyboard.");

            bool isDraw = false;
            Player winner = null;
            int digit;
            WinChecker checker = new WinChecker();
            ticTacToeBoard.DisplayBoard();

            do
            {
                Write("Player 1, please enter your desired position: ");
                digit = int.Parse(ReadLine());
                ticTacToeBoard.Mark(GetPosition(digit), player1.Symbol);
                ticTacToeBoard.DisplayBoard();

                // check draw or winner for every move
                isDraw = checker.IsDraw(ticTacToeBoard);
                if (!isDraw)
                {
                    winner = checker.GetWinner(ticTacToeBoard, player1, player2);
                    if (winner != null) break;
                }
                else
                {
                    break;
                }

                Write("Player 2, please enter your desired position: ");
                digit = int.Parse(ReadLine());
                ticTacToeBoard.Mark(GetPosition(digit), player2.Symbol);
                ticTacToeBoard.DisplayBoard();

                // check draw or winner for every move
                isDraw = checker.IsDraw(ticTacToeBoard);
                if (!isDraw)
                {
                    winner = checker.GetWinner(ticTacToeBoard, player1, player2);
                    if (winner != null) break;
                }
                else
                {
                    break;
                }
            } while (true);

            if (isDraw) WriteLine("Game ended with draw result.");

            if (winner != null)
            {
                if (winner == player1) WriteLine($"The winner is {nameof(player1)}.");
                if (winner == player2) WriteLine($"The winner is {nameof(player2)}.");
            }
        }

        /// <summary>
        /// Convert the digit to the appropriate position
        /// </summary>
        /// <param name="num">The digit</param>
        /// <returns>The position</returns>
        static Position GetPosition(int num)
        {
            switch (num)
            {
                case 1: return new Position(0, 0);
                case 2: return new Position(0, 1);
                case 3: return new Position(0, 2);
                case 4: return new Position(1, 0);
                case 5: return new Position(1, 1);
                case 6: return new Position(1, 2);
                case 7: return new Position(2, 0);
                case 8: return new Position(2, 1);
                case 9: return new Position(2, 2);
                default: return null;
            }

        }
    }
}