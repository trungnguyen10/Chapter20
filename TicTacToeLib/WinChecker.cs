namespace TicTacToeLib
{
    public class WinChecker
    {
        /// <summary>
        /// Check if the Board's state is draw or not
        /// </summary>
        /// <param name="board">The playing board</param>
        /// <returns>Return true when the game is draw</returns>
        public bool IsDraw(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    if (board.GetCell(new Position(row, col)) == " ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Player GetWinner(Board board, Player player1, Player player2)
        {
            if (CheckForWin(board, player1.Symbol)) return player1;
            if (CheckForWin(board, player2.Symbol)) return player2;
            return null;
        }

        private bool AreTheSame(Board board, Position[] positions, string symbol)
        {
            foreach (Position position in positions)
            {
                if (board.GetCell(position) != symbol) { return false; }
            }
            return true;
        }

        private bool CheckForWin(Board board, string symbol)
        {
            // array of position with size equals either rows or cols of the board
            Position[] positions = new Position[board.Rows];

            //check every row for the same symbol
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    positions[col] = new Position(row, col);
                }
                if (AreTheSame(board, positions, symbol)) return true;
            }

            //check every col for the same symbol
            for (int col = 0; col < board.Cols; col++)
            {
                for (int row = 0; row < board.Rows; row++)
                {
                    positions[row] = new Position(row, col);
                }
                if (AreTheSame(board, positions, symbol)) return true;
            }

            // check the diagonal for the same symbol
            for (int i = 0; i < board.Rows; i++)
            {
                positions[i] = new Position(i, i);
            }
            if (AreTheSame(board, positions, symbol)) return true;

            // check the diagonal for the same symbol
            for (int i = 0; i < board.Rows; i++)
            {
                positions[i] = new Position(i, board.Rows - 1 - i);
            }
            if (AreTheSame(board, positions, symbol)) return true;

            // if no true returned, return false
            return false;


        }
    }
}