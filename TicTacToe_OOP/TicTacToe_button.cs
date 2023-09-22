using Android.Content;
using Android.Widget;
namespace TicTacToe_OOP
{


    public class TicTacToeButton : Button
    {
        public int Row { get; }
        public int Column { get; }

        public TicTacToeButton(Context context, int row, int col) : base(context)
        {
            Row = row;
            Column = col;
        }
    }

}