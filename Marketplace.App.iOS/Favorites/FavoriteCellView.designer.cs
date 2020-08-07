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
    [Register ("FavoriteCellView")]
    partial class FavoriteCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProductImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProductDescription != null) {
                ProductDescription.Dispose ();
                ProductDescription = null;
            }

            if (ProductImage != null) {
                ProductImage.Dispose ();
                ProductImage = null;
            }

            if (ProductName != null) {
                ProductName.Dispose ();
                ProductName = null;
            }
        }
    }
}