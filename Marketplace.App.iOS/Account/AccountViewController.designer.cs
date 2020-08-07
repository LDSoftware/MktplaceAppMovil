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
    [Register ("AccountViewController")]
    partial class AccountViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCreditContpaq { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCurrentBalance { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDistributorId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblEmailDistributor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPendingBalance { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MenuTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblCreditContpaq != null) {
                lblCreditContpaq.Dispose ();
                lblCreditContpaq = null;
            }

            if (lblCurrentBalance != null) {
                lblCurrentBalance.Dispose ();
                lblCurrentBalance = null;
            }

            if (lblDistributorId != null) {
                lblDistributorId.Dispose ();
                lblDistributorId = null;
            }

            if (lblEmailDistributor != null) {
                lblEmailDistributor.Dispose ();
                lblEmailDistributor = null;
            }

            if (lblPendingBalance != null) {
                lblPendingBalance.Dispose ();
                lblPendingBalance = null;
            }

            if (MenuTableView != null) {
                MenuTableView.Dispose ();
                MenuTableView = null;
            }
        }
    }
}