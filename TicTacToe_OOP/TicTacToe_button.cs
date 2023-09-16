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
    using Android.Content;
    using Android.Widget;

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