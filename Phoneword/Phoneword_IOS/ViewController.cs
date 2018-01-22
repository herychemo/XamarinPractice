using Foundation;
using ModernHttpClient;
using Phoneword_BLL;
using System;
using System.Collections.Generic;
using System.Net.Http;
using UIKit;

namespace Phoneword_IOS
{
    public partial class ViewController : UIViewController
    {
        //      Phone to Call
        private string translatedNumber { get; set; }

        public List<string> PhoneNumbers { get; set; }

        public ViewController(IntPtr handle) : base(handle)
        {
            PhoneNumbers = new List<string>();
            translatedNumber = "";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void TranslateButton_TouchUpInside(UIButton sender)
        {
            // Convert the phone number with text to a number
            // using PhoneTranslator.cs
            translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);

            // Dismiss the keyboard if text field was tapped
            PhoneNumberText.ResignFirstResponder();

            if (translatedNumber == "")
            {
                CallButton.SetTitle("Call", UIControlState.Normal);
                CallButton.Enabled = false;
            }
            else
            {
                CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                CallButton.Enabled = true;
            }
        }

        partial void CallButton_TouchUpInside(UIButton sender)
        {
            //Store the phone number that we're dialing in PhoneNumbers
            PhoneNumbers.Add(translatedNumber);

            var url = new NSUrl("tel:" + translatedNumber);

            // Use URL handler with tel: prefix to invoke Apple's Phone app,
            // otherwise show an alert dialog

            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
        }

        partial void CallHistoryButton_TouchUpInside(UIButton sender)
        {
            // Launches a new instance of CallHistoryController
            CallHistoryController callHistory = this.Storyboard.InstantiateViewController("CallHistoryController") as CallHistoryController;
            if (callHistory != null)
            {
                callHistory.PhoneNumbers = PhoneNumbers;
                this.NavigationController.PushViewController(callHistory, true);
            }
        }

        private async void doIt(int op)
        {
            RestClient restClient = new RestClient(new NativeMessageHandler());
            
            switch (op)
            {
                case 1:
                default:
                    string response = await restClient.GetPublicIp();
                    PrinterTvExtra.SetTitle(response, UIControlState.Normal);
                    break;
                case 2:
                    Post post = await restClient.GetTestPost();
                    PrinterTvExtra2.SetTitle(post.Title, UIControlState.Normal);
                    break;
                case 3:
                    List<Post> posts = await restClient.GetTestPostList();
                    PrinterTvExtra3.SetTitle("There is: " + posts.Count, UIControlState.Normal);
                    break;
            }


        }

        partial void PrinterTvExtra_TouchUpInside(UIButton sender)
        {
            doIt(1);
        }

        partial void PrinterTvExtra2_TouchUpInside(UIButton sender)
        {
            doIt(2);
        }

        partial void PrinterTvExtra3_TouchUpInside(UIButton sender)
        {
            doIt(3);
        }
    }
}