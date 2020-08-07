using System;
using System.Collections.Generic;
using Foundation;
using Marketplace.App.Runtime;
using UIKit;

namespace Marketplace.App.iOS
{
    internal class SearchSource : UITableViewSource
    {
        string CellIdentifier = "SearchCellView";
        List<Schemas.Search.SearchProductModel> rows { get; set; }
        public event EventHandler<Schemas.Search.SearchProductModel> ProductButtonTapped;
        UIViewController owner;

        public SearchSource(List<Schemas.Search.SearchProductModel> _rows, UIViewController _owner)
        {
            this.rows = _rows;
           
            owner = _owner;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (SearchCellView)tableView.DequeueReusableCell(CellIdentifier, indexPath);
            cell.FillResults(rows, indexPath);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return rows.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Insertamos el producto para registarlo
            // en las busquedas recurrentes
            AppRuntime.MarketliteDB.InsertRecurringSearches(rows[indexPath.Row]);

            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            ProductsDetailController controllerProducts = (ProductsDetailController)storyboard.InstantiateViewController("ProductsDetailController");
            controllerProducts.ProductID = rows[indexPath.Row].IdProduct;
            controllerProducts.Title = rows[indexPath.Row].ProductName;

            owner.NavigationController.PushViewController(controllerProducts, false);
        }
    }
}