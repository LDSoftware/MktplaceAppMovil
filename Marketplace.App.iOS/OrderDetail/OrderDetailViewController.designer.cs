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
    [Register ("OrderDetailViewController")]
    partial class OrderDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnInvoice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ButtonsHeightConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ButtonsView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ImpuestoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel KeyOneLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel KeyThreeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel KeyTwoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl OptionsSegment { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView OrderDetailCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PdfButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubtotalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TotalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ValueOneLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ValueThreeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ValueTwoLabel { get; set; }

        [Action ("DataChanging:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DataChanging (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnInvoice != null) {
                btnInvoice.Dispose ();
                btnInvoice = null;
            }

            if (ButtonsHeightConstraint != null) {
                ButtonsHeightConstraint.Dispose ();
                ButtonsHeightConstraint = null;
            }

            if (ButtonsView != null) {
                ButtonsView.Dispose ();
                ButtonsView = null;
            }

            if (ImpuestoLabel != null) {
                ImpuestoLabel.Dispose ();
                ImpuestoLabel = null;
            }

            if (KeyOneLabel != null) {
                KeyOneLabel.Dispose ();
                KeyOneLabel = null;
            }

            if (KeyThreeLabel != null) {
                KeyThreeLabel.Dispose ();
                KeyThreeLabel = null;
            }

            if (KeyTwoLabel != null) {
                KeyTwoLabel.Dispose ();
                KeyTwoLabel = null;
            }

            if (OptionsSegment != null) {
                OptionsSegment.Dispose ();
                OptionsSegment = null;
            }

            if (OrderDetailCollectionView != null) {
                OrderDetailCollectionView.Dispose ();
                OrderDetailCollectionView = null;
            }

            if (PdfButton != null) {
                PdfButton.Dispose ();
                PdfButton = null;
            }

            if (SubtotalLabel != null) {
                SubtotalLabel.Dispose ();
                SubtotalLabel = null;
            }

            if (TotalLabel != null) {
                TotalLabel.Dispose ();
                TotalLabel = null;
            }

            if (ValueOneLabel != null) {
                ValueOneLabel.Dispose ();
                ValueOneLabel = null;
            }

            if (ValueThreeLabel != null) {
                ValueThreeLabel.Dispose ();
                ValueThreeLabel = null;
            }

            if (ValueTwoLabel != null) {
                ValueTwoLabel.Dispose ();
                ValueTwoLabel = null;
            }
        }
    }
}