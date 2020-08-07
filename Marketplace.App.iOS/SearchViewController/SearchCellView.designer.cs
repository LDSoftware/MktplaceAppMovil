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
    [Register ("SearchCellView")]
    partial class SearchCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ResultLabel != null) {
                ResultLabel.Dispose ();
                ResultLabel = null;
            }
        }
    }
}