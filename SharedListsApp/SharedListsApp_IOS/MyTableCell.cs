using Foundation;
using SharedListsApp.Entities;
using System;
using UIKit;

namespace SharedListsApp_IOS
{
    public partial class MyTableCell : UITableViewCell
    {
        public MyTableCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(Post post)
        {
            TitleLabel.Text = post.Title;
            UserLabel.Text = post.UserId;
            DescriptionLabel.Text = post.Body;
        }
    }
}