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
    [Register ("LoginCellView")]
    partial class LoginCellView
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
        UIKit.UILabel lblDistributorMail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPendingBalance { get; set; }

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

            if (lblDistributorMail != null) {
                lblDistributorMail.Dispose ();
                lblDistributorMail = null;
            }

            if (lblPendingBalance != null) {
                lblPendingBalance.Dispose ();
                lblPendingBalance = null;
            }
        }
    }
}