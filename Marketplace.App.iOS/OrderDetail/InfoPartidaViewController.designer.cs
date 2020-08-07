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
    [Register ("InfoPartidaViewController")]
    partial class InfoPartidaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView CertificatesTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Action ("CloseInfoAction:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CloseInfoAction (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CertificatesTableView != null) {
                CertificatesTableView.Dispose ();
                CertificatesTableView = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}