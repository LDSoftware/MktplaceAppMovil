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
    [Register ("CertificatesTableCell")]
    partial class CertificatesTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ClaveLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LoteLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SerieLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ClaveLabel != null) {
                ClaveLabel.Dispose ();
                ClaveLabel = null;
            }

            if (LoteLabel != null) {
                LoteLabel.Dispose ();
                LoteLabel = null;
            }

            if (SerieLabel != null) {
                SerieLabel.Dispose ();
                SerieLabel = null;
            }
        }
    }
}