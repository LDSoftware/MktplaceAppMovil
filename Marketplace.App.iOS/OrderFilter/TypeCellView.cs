using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class TypeCellView : UITableViewCell
    {
        public TypeCellView (IntPtr handle) : base (handle)
        {
        }

        internal void FillOptions(List<string> tipo, NSIndexPath indexPath)
        {
            SelectedView.Layer.BorderWidth = 1.0f;
            SelectedView.Layer.CornerRadius = SelectedView.Frame.Size.Width / 2;
            ViewInside.Layer.CornerRadius = ViewInside.Frame.Size.Width / 2;
            //ViewInside.BackgroundColor = UIColor.FromRGB(252, 72, 80);
            OptionLabel.Text = tipo[indexPath.Row];
        }

        internal void SelectOption()
        {
            ViewInside.BackgroundColor = UIColor.FromRGB(252, 72, 80);
        }

        internal void DeselectOption()
        {
            ViewInside.BackgroundColor = null;
        }

    }
}