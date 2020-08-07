using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS
{
    public class ProductsTableViewSource : UITableViewSource
    {
        List<Schemas.Product.ProductInfo> rows { get; set; }
        public event EventHandler<Schemas.Product.ProductInfo> ProductButtonTapped;
        ProductsViewController productsViewController;

        public ProductsTableViewSource(List<Schemas.Product.ProductInfo> _rows, ProductsViewController _productsViewController)
        {
            rows = _rows;
            productsViewController = _productsViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ProductsCellView)tableView.DequeueReusableCell(ProductsCellView.CellID, indexPath);
            var Product = rows[indexPath.Row];

            cell.ProductButtonTapped -= OnCellSpeakButtonTapped;
            cell.ProductButtonTapped += OnCellSpeakButtonTapped;

            cell.UpdateCell(Product);
            cell.SetProduct(Product);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return rows.Count;
        }

        void OnCellSpeakButtonTapped(object sender, Schemas.Product.ProductInfo e)
        {
            // This is the event handler for the AnimalTableViewCell's SpeakButtonTapped event.
            // In this handler, we will invoke the AnimalTableViewSource's SpeakButtonTapped event causing it to "bubble up" into the view controller.

            if (ProductButtonTapped != null)
                ProductButtonTapped(sender, e);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            ProductsDetailController controllerProducts = (ProductsDetailController)storyboard.InstantiateViewController("ProductsDetailController");
            controllerProducts.ProductID = rows[indexPath.Row].Id;
            controllerProducts.Title = rows[indexPath.Row].FullDescription;

            productsViewController.NavigationController.PushViewController(controllerProducts, false);
        }
    }
}
