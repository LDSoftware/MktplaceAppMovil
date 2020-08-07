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
    [Register ("BusquedaCellView")]
    partial class BusquedaCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProductImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProductImageView != null) {
                ProductImageView.Dispose ();
                ProductImageView = null;
            }

            if (ProductNameLabel != null) {
                ProductNameLabel.Dispose ();
                ProductNameLabel = null;
            }
        }
    }
}