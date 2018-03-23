// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SharedListsApp_IOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MyTableList { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MyTableList != null) {
                MyTableList.Dispose ();
                MyTableList = null;
            }
        }
    }
}