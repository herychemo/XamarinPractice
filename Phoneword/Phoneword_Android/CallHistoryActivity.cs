using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Phoneword_Android
{
    [Activity(Label = "@string/CallHistory", Icon = "@drawable/icon") ]
    public class CallHistoryActivity : ListActivity
    {
        public static readonly String EXTRA_PHONE_NUMBERS = "phone_numbers";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var PhoneNumbers = Intent.Extras.GetStringArrayList(EXTRA_PHONE_NUMBERS) ?? new string[0];
            this.ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, PhoneNumbers);
        }
    }
}