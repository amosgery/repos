
using Android.Views;

namespace OptionsMenu
{


    [Activity(Label = "Options Menu Example", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }

        // Inflate the menu from the XML file
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return true; // Return true to display the menu
        }

        // Handle menu item clicks
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_settings:
                    Toast.MakeText(this, "Settings Clicked", ToastLength.Short).Show();
                    return true;

                case Resource.Id.action_about:
                    Toast.MakeText(this, "About Clicked", ToastLength.Short).Show();
                    return true;

                case Resource.Id.action_exit:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }

}