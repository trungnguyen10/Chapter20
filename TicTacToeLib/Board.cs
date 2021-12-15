using System;
using static System.Console;

namespace TicTacToeLib
{
    public class Board
    {
        private string[,] cells;
        public int Rows { get; }
        public int Cols { get; }

        /// <summary>
        /// Construct a board with N rows and M columns
        /// </summary>
        /// <param name="numberOfRow"> Number of rows</param>
        /// <param name="numberOfCol">Number of columns</param>
        public Board(int numberOfRow, int numberOfCol)
        {
            Rows = numberOfRow;
            Cols = numberOfCol;
            cells = new string[numberOfRow, numberOfCol];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = " ";
                }
            }
        }

        /// <summary>
        /// Get the symbol at the cell specified by the position. 
        /// </summary>
        /// <param name="position">The position of the cell.</param>
        /// <returns>The string represents the symbol at the specified cell.</returns>
        public string GetCell(Position position)
        {
            return cells[position.Row,position.Col];
        }

        /// <summary>
        /// Display the board on the console
        /// </summary>
        public void DisplayBoard()
        {
            for (int i = cells.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Write($" {cells[i, j]} ");
                    }
                    else
                    {
                        Write("|");
                        Write($" {cells[i, j]} ");
                    }
                }
                WriteLine();
                if (i == 0) { }
                else { WriteLine("---+---+---"); }

            }
        }

        /// <summary>
        /// Mark a cell specified by the position with the specified symbol
        /// </summary>
        /// <param name="position">the position of the cell</param>
        /// <param name="markSymbol">the symbol </param>
        /// <returns>Return true when successfully marked, otherwise return false</returns>
        public bool Mark(Position position, string markSymbol = " ")
        {
            if (position.Row >= 0 && position.Row <= 2
             && position.Col >= 0 && position.Col <= 2
             && markSymbol.Length == 1)
            {
                if (this.cells[position.Row, position.Col] == " ")
                {
                    this.cells[position.Row, position.Col] = markSymbol;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}