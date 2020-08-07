using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class PeriodCellView : UITableViewCell
    {
        public PeriodCellView (IntPtr handle) : base (handle)
        {
            
        }

        internal void FillOptions(List<string> periodo, NSIndexPath indexPath)
        {
            SelectedView.Layer.BorderWidth = 1.0f;
            SelectedView.Layer.CornerRadius = SelectedView.Frame.Size.Width/2;
            ViewInside.Layer.CornerRadius = ViewInside.Frame.Size.Width / 2;
            //ViewInside.BackgroundColor = UIColor.FromRGB(252, 72, 80);
            OptionLabel.Text = periodo[indexPath.Row];
        }

        internal void SelectOption()
        {
            ViewInside.BackgroundColor = UIColor.FromRGB(252, 72, 80);
        }

        internal void DeselectOption()
        {
            ViewInside.BackgroundColor = null;
        }

        internal void HidePeriod()
        {
          
        }

        internal void ShowPeriod()
        {
            ViewInside.BackgroundColor = null;
        }
    }
}