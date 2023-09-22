
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
            foreach (TicTacToeButton button in buttons)
            {
                if (button.Text == "")
                    return false;
            }
            return true;
        }
    }

}