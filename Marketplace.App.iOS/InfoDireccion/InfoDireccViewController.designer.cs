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
    [Register ("InfoDireccViewController")]
    partial class InfoDireccViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView OneTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TableOneHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint TableTwoHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleOne { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TwoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TwoTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (OneTableView != null) {
                OneTableView.Dispose ();
                OneTableView = null;
            }

            if (TableOneHeight != null) {
                TableOneHeight.Dispose ();
                TableOneHeight = null;
            }

            if (TableTwoHeight != null) {
                TableTwoHeight.Dispose ();
                TableTwoHeight = null;
            }

            if (TitleOne != null) {
                TitleOne.Dispose ();
                TitleOne = null;
            }

            if (TwoLabel != null) {
                TwoLabel.Dispose ();
                TwoLabel = null;
            }

            if (TwoTableView != null) {
                TwoTableView.Dispose ();
                TwoTableView = null;
            }
        }
    }
}