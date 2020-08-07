using Foundation;
using System;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class BuildingViewController : UIViewController
    {
        public BuildingViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BorderView.Layer.CornerRadius = 8;
            BorderView.Layer.BorderWidth = 2;
            BorderView.Layer.BorderColor = UIColor.DarkGray.CGColor;
        }
    }
}