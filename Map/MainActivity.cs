
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Widget;

namespace Map
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap googleMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
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
            googleMap = map;

            // Set up a click listener for the map
            googleMap.MapClick += GoogleMapOnMapClick;
        }

        private void GoogleMapOnMapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            LatLng clickedLatLng = e.Point;
            double latitude = clickedLatLng.Latitude;
            double longitude = clickedLatLng.Longitude;

            // Now you have the latitude and longitude of the clicked location
            Toast.MakeText(this, $"Clicked at: Lat {latitude}, Lng {longitude}", ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}