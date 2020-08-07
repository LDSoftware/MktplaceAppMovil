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
    [Register ("PeriodCellView")]
    partial class PeriodCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SelectedView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ViewInside { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (OptionLabel != null) {
                OptionLabel.Dispose ();
                OptionLabel = null;
            }

            if (SelectedView != null) {
                SelectedView.Dispose ();
                SelectedView = null;
            }

            if (ViewInside != null) {
                ViewInside.Dispose ();
                ViewInside = null;
            }
        }
    }
}