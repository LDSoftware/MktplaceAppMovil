using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class SearchCellView : UITableViewCell
    {
        public SearchCellView (IntPtr handle) : base (handle)
        {
        }

        public override bool Selected { get => base.Selected; set => base.Selected = value; }

        internal void FillResults(List<Schemas.Search.SearchProductModel> options, NSIndexPath indexPath)
        {
            ResultLabel.Text = options[indexPath.Row].ProductName;
        }
    }
}