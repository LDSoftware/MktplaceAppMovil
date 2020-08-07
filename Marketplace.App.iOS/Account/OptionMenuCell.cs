using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class OptionMenuCell : UITableViewCell
    {
        public OptionMenuCell (IntPtr handle) : base (handle)
        {
        }
        internal void FillOptions(string v, NSIndexPath indexPath)
        {
            OptionLabel.Text = v;
        }
    }
}