using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOOOP
{
    internal class XOGame
    {

        public enum Player { None, X, O }

        private XOBoard board = new XOBoard();
        private Player currentPlayer = Player.X;
        private Player Winner = Player.None;
        public Player CurrentPlayer => currentPlayer;
        public void MakeMove(int row, int col)
        {
            board[row, col].Text = CurrentPlayer.ToString();

            if (!IsGameOver())
            {
                if (currentPlayer == Player.X)
                {
                    currentPlayer = Player.O;
                }
                else if (currentPlayer == Player.O)
                {
                    currentPlayer = Player.X;
                }
            }
        }

        internal bool IsGameOver()
        {
            int row, col = 0;
            // Check rows
            for (row = 0; row < 3; row++)
            {
                if (board[row, col].Text == "")
                    continue;
                if (board[row, col].Text == board[row, col + 1].Text && board[row, col].Text == board[row, col + 2].Text)
                {
                    Winner = currentPlayer;
                    return true;
                }
            }
            row = 0;
            // Check columns
            for (col = 0; col < 3; col++)
            {
                if (board[row, col].Text == "")
                    continue;
                if (board[row, col].Text == board[row + 1, col].Text && board[row, col].Text == board[row + 2, col].Text)
                {
                    Winner = currentPlayer;
                    return true;
                }
            }
            row = 0;
            col = 0;
            // Check diagonal
            if ((board[row, col].Text != "") &&
                    (board[row, col].Text == board[row + 1, col + 1].Text && board[row, col].Text == board[row + 2, col + 2].Text))
            {
                Winner = currentPlayer;
                return true;
            }
            row = 0;
            col = 2;
            // Check diagonal
            if ((board[row, col].Text != "") &&
                    (board[row, col].Text == board[row + 1, col - 1].Text && board[row, col].Text == board[row + 2, col - 2].Text))
            {
                Winner = currentPlayer;
                return true;
            }
            if (board.IsFull())
            {
                Winner = Player.None;
                return true;
            }
            return false;
        }

        internal void ResetBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                    board[row, col].Text = "";
            }
            currentPlayer = Player.X;
        }

        internal Player GetWinner()
        {
            // Implement logic to determine the winner

            return Winner;
        }

        internal void AddButton(XOButton button, int row, int col)
        {
            board[row, col] = button;
        }
    }
}

