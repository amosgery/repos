using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;

namespace XOOOP
{
    internal class XOButton : Button
    {
        public int Row { get; }
        public int Column { get; }

        public XOButton(Context context, int row, int col) : base(context)
        {
            Row = row;
            Column = col;
        }
    }
}
