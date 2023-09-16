using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TicTacToe_OOP
{
    public class TicTacToeBoard
    {
        private TicTacToeButton[,] buttons = new TicTacToeButton[3, 3];

        public TicTacToeButton this[int row, int col]
        {
            get { return buttons[row, col]; }
            set { buttons[row, col] = value; }
        }

        public TicTacToeBoard()
        {
           
        }
        public bool IsFull()
        {
            // Implement logic to check if the board is full
            foreach (Button button in buttons)
            {
                if (button.Text == "")
                    return false;
            }
            return true;
        }
    }

}