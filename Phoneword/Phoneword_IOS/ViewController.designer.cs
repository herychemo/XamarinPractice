// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Phoneword_IOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallHistoryButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PhoneNumberText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PrinterTvExtra { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PrinterTvExtra2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PrinterTvExtra3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TranslateButton { get; set; }

        [Action ("CallButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CallButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("CallHistoryButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CallHistoryButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("PrinterTvExtra_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrinterTvExtra_TouchUpInside (UIKit.UIButton sender);

        [Action ("PrinterTvExtra2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrinterTvExtra2_TouchUpInside (UIKit.UIButton sender);

        [Action ("PrinterTvExtra3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PrinterTvExtra3_TouchUpInside (UIKit.UIButton sender);

        [Action ("TranslateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void TranslateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CallButton != null) {
                CallButton.Dispose ();
                CallButton = null;
            }

            if (CallHistoryButton != null) {
                CallHistoryButton.Dispose ();
                CallHistoryButton = null;
            }

            if (PhoneNumberText != null) {
                PhoneNumberText.Dispose ();
                PhoneNumberText = null;
            }

            if (PrinterTvExtra != null) {
                PrinterTvExtra.Dispose ();
                PrinterTvExtra = null;
            }

            if (PrinterTvExtra2 != null) {
                PrinterTvExtra2.Dispose ();
                PrinterTvExtra2 = null;
            }

            if (PrinterTvExtra3 != null) {
                PrinterTvExtra3.Dispose ();
                PrinterTvExtra3 = null;
            }

            if (TranslateButton != null) {
                TranslateButton.Dispose ();
                TranslateButton = null;
            }
        }
    }
}