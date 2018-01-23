using System;
using System.Collections.Generic;
using Foundation;
using SharedListsApp.Entities;
using UIKit;

namespace SharedListsApp_IOS
{
    internal class MyTableSource : UITableViewSource
    {
        private List<Post> posts;

        public MyTableSource(List<Post> posts)
        {
            this.posts = posts;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (MyTableCell)tableView.DequeueReusableCell("MyCell_Id", indexPath);

            cell.UpdateCell( posts[indexPath.Row] );

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return posts.Count;
        }
    }
}