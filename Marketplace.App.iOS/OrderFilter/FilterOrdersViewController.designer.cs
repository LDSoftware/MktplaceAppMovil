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
    [Register ("FilterOrdersViewController")]
    partial class FilterOrdersViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DateOneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DateTwoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPeriodo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint PeriodHeigthCL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView PeriodTebleView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PeriodView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TypeHeightCL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TypeTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateOneButton != null) {
                DateOneButton.Dispose ();
                DateOneButton = null;
            }

            if (DateTwoButton != null) {
                DateTwoButton.Dispose ();
                DateTwoButton = null;
            }

            if (lblPeriodo != null) {
                lblPeriodo.Dispose ();
                lblPeriodo = null;
            }

            if (PeriodHeigthCL != null) {
                PeriodHeigthCL.Dispose ();
                PeriodHeigthCL = null;
            }

            if (PeriodTebleView != null) {
                PeriodTebleView.Dispose ();
                PeriodTebleView = null;
            }

            if (PeriodView != null) {
                PeriodView.Dispose ();
                PeriodView = null;
            }

            if (TypeHeightCL != null) {
                TypeHeightCL.Dispose ();
                TypeHeightCL = null;
            }

            if (TypeTableView != null) {
                TypeTableView.Dispose ();
                TypeTableView = null;
            }
        }
    }
}