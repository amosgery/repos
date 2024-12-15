using System;
using Android.App;
using Android.OS;

using Android.Text;
using Android.Views;
using Android.Widget;


namespace tableLayout
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        GridLayout gridLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            gridLayout = FindViewById<GridLayout>(Resource.Id.gridLayout);

            CreateGrid(10, 3);
 
        }

        private void CreateGrid(int rows, int cols)
        {
            gridLayout.RowCount = rows;
            gridLayout.ColumnCount = cols;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    TableCell editText = new TableCell(this, row, col)
                    {
                        LayoutParameters = new GridLayout.LayoutParams
                        {
                            Width = 0,
                            Height = 0,
                            ColumnSpec = GridLayout.InvokeSpec(col, GridLayout.Fill, 1f),
                            RowSpec = GridLayout.InvokeSpec(row, GridLayout.Fill, 1f)
                        }
                    };

                    editText.Gravity = GravityFlags.Center;
                    editText.InputType = InputTypes.ClassText | InputTypes.TextVariationVisiblePassword;
                    editText.SetMaxLines(1);
                    editText.SetTextSize(Android.Util.ComplexUnitType.Sp, 150/rows);
                    editText.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(1)});
                    editText.SetBackgroundResource(Resource.Drawable.border);
                    gridLayout.AddView(editText);
                    editText.FocusChange += CellClicked;
                    editText.TextChanged += EditText_TextChanged;
                }
            }
        }

        private void EditText_TextChanged(object sender, TextChangedEventArgs e)
        {
            TableCell cell = (TableCell)sender;
            if (cell.Length() > 0 )
            {
                // move focus to next cell

            }
        }

        private void CellClicked(object sender, EventArgs e)
        {
            TableCell cell = (TableCell)sender;
            if (cell.HasFocus)
            {
                Toast.MakeText(this, "Cell clicked: Row=" + cell.Row + " Coloumn=" + cell.Column, ToastLength.Short).Show();
            }
        }
    }
}