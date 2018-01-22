using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace SharedListsApp_Android
{
    [Activity(Label = "Phoneword", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme1")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Listas Locas" ;

        }
    }
}

