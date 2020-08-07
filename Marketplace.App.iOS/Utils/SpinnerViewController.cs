using System;
using CoreFoundation;
using UIKit;

namespace Marketplace.App.iOS.Utils
{
    public partial class SpinnerViewController : UIViewController
    {
        UIActivityIndicatorView miniSpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
        UIView view = new UIView();
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }


        public override void LoadView()
        {
             base.LoadView();
             view = new UIView();
             view.Frame = this.View.Frame;
             view.BackgroundColor = UIColor.Black.ColorWithAlpha((float)0.7);
             miniSpinner.Frame = this.View.Frame;
             miniSpinner.Center = this.View.Center;
             miniSpinner.HidesWhenStopped = true;
             miniSpinner.StartAnimating();

             view.AddSubview(miniSpinner);
             var window = UIApplication.SharedApplication.KeyWindow;
             window.AddSubview(view);

        }

        public void RemoveView()
        {
            view.RemoveFromSuperview();
            view.Hidden = true;
        }

    }

}

