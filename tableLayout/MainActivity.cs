using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace tableLayout
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        GridLayout gridLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            gridLayout = FindViewById<GridLayout>(Resource.Id.gridLayout);

            CreateGrid(5, 5);
 
        }

        private void CreateGrid(int rows, int cols)
        {
            gridLayout.RowCount = rows;
            gridLayout.ColumnCount = cols;


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    EditText editText = new EditText(this)
                    {
                        LayoutParameters = new GridLayout.LayoutParams
                        {
                            Width = 0,
                            Height = 0,
                            ColumnSpec = GridLayout.InvokeSpec(col, GridLayout.Fill, 1f),
                            RowSpec = GridLayout.InvokeSpec(row, GridLayout.Fill, 1f)
                        }
                    };

                    editText.Gravity = Android.Views.GravityFlags.Center;
                    editText.InputType = Android.Text.InputTypes.TextVariationVisiblePassword;
                    editText.SetMaxLines(1);
                    editText.SetTextSize(Android.Util.ComplexUnitType.Sp, 150/rows);
                    editText.SetFilters(new Android.Text.IInputFilter[] { new Android.Text.InputFilterLengthFilter(1) });
                    editText.SetBackgroundResource(Resource.Drawable.border);
                    gridLayout.AddView(editText);
                }
            }
        }
    }
}