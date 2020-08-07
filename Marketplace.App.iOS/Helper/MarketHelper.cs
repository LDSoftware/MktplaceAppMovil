using System;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS.Helper
{
    public static class MarketHelper
    {
        public static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}
