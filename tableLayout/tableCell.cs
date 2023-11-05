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

namespace tableLayout
{
    internal class TableCell : EditText
    {
        public int Row { get; set; }
        public int Column { get; set; }

        protected TableCell(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        public TableCell(Context context, int row, int col) : base(context)
        {
            Row = row; 
            Column = col;
        }

    }
}