using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace menu
{
    [Activity(Label = "menu", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            tv = FindViewById<TextView>(Resource.Id.tv);

            RegisterForContextMenu(tv);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "you selected login " + item.ItemId, ToastLength.Long);
            if (item.ItemId == Resource.Id.action_login)
            {
                Toast.MakeText(this, "you selected login", ToastLength.Long).Show();
                return true;
            }
            else if (item.ItemId == Resource.Id.action_register)
            {
                Toast.MakeText(this, "you selected register", ToastLength.Long).Show();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        public override void OnCreateContextMenu(Android.Views.IContextMenu menu, Android.Views.View v, Android.Views.IContextMenuContextMenuInfo menuInfo)

        {

            base.OnCreateContextMenu(menu, v, menuInfo);

            MenuInflater.Inflate(Resource.Menu.context_menu, menu);

        }
        public override bool OnContextItemSelected(Android.Views.IMenuItem item)

        {

             Toast.MakeText(this, "You selected " + item.ToString(), ToastLength.Long).Show();
             return true;

        }
    }
}