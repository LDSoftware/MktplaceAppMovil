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

namespace Marketplace.App.iOS.Categories
{
    [Register ("CategoriasViewController")]
    partial class CategoriasViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CancelButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CanvelView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView CategoriasCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView OptionsView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView SearchTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SearchTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton UserButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CancelButton != null) {
                CancelButton.Dispose ();
                CancelButton = null;
            }

            if (CanvelView != null) {
                CanvelView.Dispose ();
                CanvelView = null;
            }

            if (CarButton != null) {
                CarButton.Dispose ();
                CarButton = null;
            }

            if (CategoriasCollectionView != null) {
                CategoriasCollectionView.Dispose ();
                CategoriasCollectionView = null;
            }

            if (OptionsView != null) {
                OptionsView.Dispose ();
                OptionsView = null;
            }

            if (SearchTableView != null) {
                SearchTableView.Dispose ();
                SearchTableView = null;
            }

            if (SearchTextField != null) {
                SearchTextField.Dispose ();
                SearchTextField = null;
            }

            if (UserButton != null) {
                UserButton.Dispose ();
                UserButton = null;
            }
        }
    }
}