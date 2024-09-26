using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;

namespace XOOOP
{
    internal class XOBoard
    { 
        private XOButton[,] buttons = new XOButton[3, 3];

        public XOButton this[int row, int col]
        {
            get { return buttons[row, col]; }
            set { buttons[row, col] = value; }
        }

        public XOBoard()
        {

        }
        public bool IsFull()
        {
            // Implement logic to check if the board is full
            foreach (XOButton button in buttons)
            {
                if (button.Text == "")
                    return false;
            }
            return true;
        }
    }
}
