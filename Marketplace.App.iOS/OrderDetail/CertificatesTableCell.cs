using Foundation;
using Marketplace.Schemas.Order;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class CertificatesTableCell : UITableViewCell
    {
        public CertificatesTableCell (IntPtr handle) : base (handle)
        {
        }

        internal void FillOptions(OrderItemLicenseInfo certificados)
        {
            SerieLabel.Text = certificados.Serie;
            LoteLabel.Text = certificados.Lote;
            ClaveLabel.Text = "XXX-XXX-XXX";
        }
    }
}