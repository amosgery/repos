using Android.App;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace Map
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private GoogleMap googleMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var mapFrag = MapFragment.NewInstance();
            FragmentManager.BeginTransaction()
                                    .Add(Resource.Id.map, mapFrag, "map_fragment")
                                    .Commit();
            //var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFrag.GetMapAsync(this);

            // remainder of code omitted
        }

        public void OnMapReady(GoogleMap map)
        {
            // Do something with the map, i.e. add markers, move to a specific location, etc.
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}