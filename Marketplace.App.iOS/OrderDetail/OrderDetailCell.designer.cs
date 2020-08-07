// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Marketplace.App.iOS
{
    [Register ("OrderDetailCell")]
    partial class OrderDetailCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameProdLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TotalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UsersLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NameProdLabel != null) {
                NameProdLabel.Dispose ();
                NameProdLabel = null;
            }

            if (ProductLabel != null) {
                ProductLabel.Dispose ();
                ProductLabel = null;
            }

            if (TotalLabel != null) {
                TotalLabel.Dispose ();
                TotalLabel = null;
            }

            if (UsersLabel != null) {
                UsersLabel.Dispose ();
                UsersLabel = null;
            }
        }
    }
}