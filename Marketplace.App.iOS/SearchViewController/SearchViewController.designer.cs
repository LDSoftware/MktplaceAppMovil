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
    [Register ("SearchViewController")]
    partial class SearchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnclosesearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ResultsSearchTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFindProduct { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnclosesearch != null) {
                btnclosesearch.Dispose ();
                btnclosesearch = null;
            }

            if (ResultsSearchTableView != null) {
                ResultsSearchTableView.Dispose ();
                ResultsSearchTableView = null;
            }

            if (txtFindProduct != null) {
                txtFindProduct.Dispose ();
                txtFindProduct = null;
            }
        }
    }
}