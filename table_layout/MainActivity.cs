using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace table_layout
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        Button btn1, btn2, btn3;
        TableRow row1, row2, row3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout1);

            row1 = FindViewById<TableRow>(Resource.Id.row1);
            row2 = FindViewById<TableRow>(Resource.Id.row2);
            row3 = FindViewById<TableRow>(Resource.Id.row3);

            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn1.SetOnClickListener(this);

            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn2.SetOnClickListener(this);

            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn3.SetOnClickListener(this);

        }
        public void OnClick(View v)
        {
            if (btn1 == v)
            {

                row1.Visibility = ViewStates.Visible;
                row2.Visibility = ViewStates.Invisible;
                row3.Visibility = ViewStates.Invisible;
            }

            else if (btn2 == v)
            {
                row1.Visibility = ViewStates.Invisible;
                row2.Visibility = ViewStates.Visible;
                row3.Visibility = ViewStates.Invisible;
            }

            else if (btn3 == v)
            {
                row1.Visibility = ViewStates.Invisible;
                row2.Visibility = ViewStates.Invisible;
                row3.Visibility = ViewStates.Visible;
            }



        }
    }
}