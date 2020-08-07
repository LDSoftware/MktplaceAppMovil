using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS
{
    internal class FavoriteViewSource : UITableViewSource
    {
        string CellId = "FavoriteCellView";
        private List<Schemas.Product.ProductInfo> rows;
        private FavoritesViewController favoritesViewController;

        public FavoriteViewSource(List<Schemas.Product.ProductInfo> _rows, FavoritesViewController favoritesViewController)
        {
            this.rows = _rows;
            this.favoritesViewController = favoritesViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (FavoriteCellView)tableView.DequeueReusableCell(CellId, indexPath);
            var product = rows[indexPath.Row];

            cell.FillProducts(product, indexPath);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return rows.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Si esta en modo edicion
            if (tableView.Editing)
            {
                var product = rows[indexPath.Row];

                favoritesViewController.ItemsForDelete(product);
            }
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            // Si esta en modo edicion
            if (tableView.Editing)
            {
                var product = rows[indexPath.Row];

                favoritesViewController.removeItemsForDelete(product);
            }
        }

        }
}