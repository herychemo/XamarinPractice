using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Custom.Views;

namespace SharedListsApp_Android
{
    [Activity(Label = "Shared Lists App", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme1")]
    public class MainActivity : AppCompatActivity
    {

        private RecyclerViewEmptySpacesSupport MyRecyclerList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Listas Locas" ;

            MyRecyclerList = FindViewById<RecyclerViewEmptySpacesSupport>(Resource.Id.MyRecyclerList);


        }
    }
}

