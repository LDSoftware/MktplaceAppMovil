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
    [Register ("OrdersViewController")]
    partial class OrdersViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BorderNoOrdersView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView NoOrdersView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView OrdersCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SearchButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SearchTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BorderNoOrdersView != null) {
                BorderNoOrdersView.Dispose ();
                BorderNoOrdersView = null;
            }

            if (NoOrdersView != null) {
                NoOrdersView.Dispose ();
                NoOrdersView = null;
            }

            if (OrdersCollectionView != null) {
                OrdersCollectionView.Dispose ();
                OrdersCollectionView = null;
            }

            if (SearchButton != null) {
                SearchButton.Dispose ();
                SearchButton = null;
            }

            if (SearchTextField != null) {
                SearchTextField.Dispose ();
                SearchTextField = null;
            }
        }
    }
}