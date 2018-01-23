using ModernHttpClient;
using SharedListsApp;
using SharedListsApp.Entities;
using System;
using System.Collections.Generic;
using UIKit;

namespace SharedListsApp_IOS
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            LoadData();
        }

        public async void LoadData()
        {
            RestClient restClient = new RestClient(new NativeMessageHandler());

            List<Post> posts = await restClient.GetTestPostList();

            MyTableList.Source = new MyTableSource(posts);

            MyTableList.RowHeight = UITableView.AutomaticDimension;
            MyTableList.EstimatedRowHeight = 40f;
            MyTableList.ReloadData();

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}