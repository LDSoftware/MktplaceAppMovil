using System;
using UIKit;

namespace Marketplace.App.iOS.Utils
{
    public static class MarketUtils
    {
        public static void AlertView(UIViewController controller,string tittle, string message)
        {
            //Create Alert
            var okAlertController = UIAlertController.Create(tittle, message, UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            // Present Alert
            controller.PresentViewController(okAlertController, true, null);
        }
    }
}
