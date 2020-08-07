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
    [Register ("BasketTableCell")]
    partial class BasketTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView PorductImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductDescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductPriceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ProductQuantityTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PorductImageView != null) {
                PorductImageView.Dispose ();
                PorductImageView = null;
            }

            if (ProductDescriptionLabel != null) {
                ProductDescriptionLabel.Dispose ();
                ProductDescriptionLabel = null;
            }

            if (ProductPriceLabel != null) {
                ProductPriceLabel.Dispose ();
                ProductPriceLabel = null;
            }

            if (ProductQuantityTextField != null) {
                ProductQuantityTextField.Dispose ();
                ProductQuantityTextField = null;
            }
        }
    }
}