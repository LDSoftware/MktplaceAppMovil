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
    [Register ("BusquedaViewController")]
    partial class BusquedaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnClearSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView BusquedaCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField SearchTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnClearSearch != null) {
                btnClearSearch.Dispose ();
                btnClearSearch = null;
            }

            if (BusquedaCollectionView != null) {
                BusquedaCollectionView.Dispose ();
                BusquedaCollectionView = null;
            }

            if (SearchTextField != null) {
                SearchTextField.Dispose ();
                SearchTextField = null;
            }
        }
    }
}