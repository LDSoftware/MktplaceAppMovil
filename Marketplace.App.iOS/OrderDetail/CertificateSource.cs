using System;
using System.Collections.Generic;
using Foundation;
using Marketplace.Schemas.Order;
using UIKit;
namespace Marketplace.App.iOS
{
    internal class CertificateSource : UITableViewSource
    {

        string cellIdentifier = "CertificatesTableCell";
        private List<OrderItemLicenseInfo> rows;

        private InfoPartidaViewController infoPartidaViewController;

        public CertificateSource(List<OrderItemLicenseInfo> _rows, InfoPartidaViewController infoPartidaViewController)
        {
            this.rows = _rows;
            this.infoPartidaViewController = infoPartidaViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CertificatesTableCell)tableView.DequeueReusableCell(cellIdentifier, indexPath);
            var License = rows[indexPath.Row];

            cell.FillOptions(License);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return rows.Count;
        }
    }
}