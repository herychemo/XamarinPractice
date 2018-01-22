using Android.App;
using Android.Widget;
using Android.OS;
using Phoneword_BLL;
using Android;
using Android.Content.PM;
using static Phoneword_Android.AndroidAppUtils;
using System.Collections.Generic;
using Android.Support.Design.Widget;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using System.Threading.Tasks;
using System.Net.Http;
using ModernHttpClient;

namespace Phoneword_Android
{
    [Activity(Label = "Phoneword", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme1")]
    public class MainActivity : AppCompatActivity
    {
        //Constants
        readonly int RequestPermissionsId = 11;
        readonly string[] PermissionsToRequest = {
                Manifest.Permission.CallPhone
            };
        readonly Dictionary<string, OnPermissionFunctionReady> PermissionsAndCallbacks = new Dictionary<string, OnPermissionFunctionReady>();


        // Constants Mutables
        static readonly List<string> PhoneNumbers = new List<string>();


        //Variables
        private string TranslatedNumber;

        //Views
        private Button CallHistoryButton, CallButton;
        private TextView PrinterTvExtra, PrinterTvExtra2, PrinterTvExtra3;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Hello from Appcompat Toolbar";

            ConfigureCallBackPermissions();

            var PhoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            CallButton = FindViewById<Button>(Resource.Id.CallButton);
            CallHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            PrinterTvExtra = FindViewById<TextView>(Resource.Id.printer_tv_extra);
            PrinterTvExtra2 = FindViewById<TextView>(Resource.Id.printer_tv_extra2);
            PrinterTvExtra3 = FindViewById<TextView>(Resource.Id.printer_tv_extra3);


            CallButton.Enabled = false;

            TranslatedNumber = string.Empty;

            TranslateButton.Click += (object sender, System.EventArgs e) =>
            {
                TranslatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.Text = "Call";
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.Text = $"Call to {TranslatedNumber}";
                    CallButton.Enabled = true;
                }
            };
            CallButton.Click += (object sender, System.EventArgs e) => {
                var CallDialog = new Android.Support.V7.App.AlertDialog.Builder(this);
                CallDialog.SetMessage($"Call to {TranslatedNumber}");
                CallDialog.SetNeutralButton("Call", delegate {
                    CheckPermissionsToGo(Manifest.Permission.CallPhone);
                });
                CallDialog.SetNegativeButton("Cancelar", delegate { });
                CallDialog.Show();
            };
            CallHistoryButton.Click += delegate {
                var i = new Android.Content.Intent(this, typeof(CallHistoryActivity));
                i.PutStringArrayListExtra(CallHistoryActivity.EXTRA_PHONE_NUMBERS, PhoneNumbers);
                StartActivity(i);
            };


            PrinterTvExtra.Click += async delegate
            {
                string response = await new RestClient(new NativeMessageHandler()).GetPublicIp();
                PrinterTvExtra.Text = response;
            };

            PrinterTvExtra2.Click += async delegate
            {
                Post post = await new RestClient(new NativeMessageHandler()).GetTestPost();
                PrinterTvExtra2.Text = post.Title;
            };

            PrinterTvExtra3.Click += async delegate
            {
                List<Post> posts = await new RestClient(new NativeMessageHandler()).GetTestPostList();
                PrinterTvExtra3.Text = "There is: " + posts.Count;
            };

        }

        private void CheckPermissionsToGo(string permission)
        {
            if (ContextCompat.CheckSelfPermission(this, permission) == (int)Permission.Granted)
            {
                PermissionsAndCallbacks[permission]();
                return;
            }

            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, permission))
            {
                Snackbar.Make(CallButton, "Location access is required to show coffee shops nearby.", Snackbar.LengthIndefinite)
                        .SetAction("OK", v => ActivityCompat.RequestPermissions(this, new string[] { permission }, RequestPermissionsId))
                        .Show();
                return;
            }

            ActivityCompat.RequestPermissions(this, new string[] { permission }, RequestPermissionsId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == RequestPermissionsId)
            {
                int idx = 0;
                foreach (var permission in grantResults)
                {
                    if (permission == Permission.Granted)
                        PermissionsAndCallbacks[permissions[idx]]();
                    idx++;
                }
            }
        }

        private void OnPermissionCallPhoneReady()
        {
            PhoneNumbers.Add(TranslatedNumber);
            CallHistoryButton.Enabled = true;
            var CallIntent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
            CallIntent.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
            StartActivity(CallIntent);
        }

        private void ConfigureCallBackPermissions()
        {
            PermissionsAndCallbacks.Add(Manifest.Permission.CallPhone, OnPermissionCallPhoneReady);

        }

    }
}

