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
    [Register ("BasketVieController")]
    partial class BasketVieController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView BasketTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CheckoutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EditTableButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubtotalOrderLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TaxesLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TotalLabel { get; set; }

        [Action ("CheckoutDidTouch:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CheckoutDidTouch (UIKit.UIButton sender);

        [Action ("EditBasketDidTouch:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EditBasketDidTouch (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BasketTableView != null) {
                BasketTableView.Dispose ();
                BasketTableView = null;
            }

            if (CheckoutButton != null) {
                CheckoutButton.Dispose ();
                CheckoutButton = null;
            }

            if (EditTableButton != null) {
                EditTableButton.Dispose ();
                EditTableButton = null;
            }

            if (SubtotalOrderLabel != null) {
                SubtotalOrderLabel.Dispose ();
                SubtotalOrderLabel = null;
            }

            if (TaxesLabel != null) {
                TaxesLabel.Dispose ();
                TaxesLabel = null;
            }

            if (TotalLabel != null) {
                TotalLabel.Dispose ();
                TotalLabel = null;
            }
        }
    }
}