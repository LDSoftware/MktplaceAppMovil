using System;
using System.Collections.Generic;
using Foundation;
using Marketplace.Schemas.Product;
using UIKit;

namespace Marketplace.App.iOS.Basket
{
    public class BasketSource : UITableViewSource
    {
        string CellId = "BasketTableCell";
        private List<ProductInfo> rows;
        private BasketVieController basketVieController;

        public BasketSource(List<ProductInfo> rows, BasketVieController basketVieController)
        {
            this.rows = rows;
            this.basketVieController = basketVieController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (BasketTableCell)tableView.DequeueReusableCell(CellId, indexPath);
            var Product = rows[indexPath.Row];
            cell.FillProducts(Product);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return rows.Count;
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableViewCellEditingStyle.Delete;
        }
    }
}
