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
    [Register ("InfoDirTableCell")]
    partial class InfoDirTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OneInfoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OneTitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TwoInfoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TwoTitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (OneInfoLabel != null) {
                OneInfoLabel.Dispose ();
                OneInfoLabel = null;
            }

            if (OneTitleLabel != null) {
                OneTitleLabel.Dispose ();
                OneTitleLabel = null;
            }

            if (TwoInfoLabel != null) {
                TwoInfoLabel.Dispose ();
                TwoInfoLabel = null;
            }

            if (TwoTitleLabel != null) {
                TwoTitleLabel.Dispose ();
                TwoTitleLabel = null;
            }
        }
    }
}