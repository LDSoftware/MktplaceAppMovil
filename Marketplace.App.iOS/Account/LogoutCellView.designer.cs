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
    [Register ("LogoutCellView")]
    partial class LogoutCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogoutButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LogoutButton != null) {
                LogoutButton.Dispose ();
                LogoutButton = null;
            }
        }
    }
}