using Foundation;
using Marketplace.App.Runtime;
using System;
using System.Linq;
using UIKit;
using Xamarin.Essentials;

namespace Marketplace.App.iOS
{
    public partial class ProductsViewController : UIViewController
    {
        public int CategoryID { get; set; }

        public ProductsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = false;
            BindProducts();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                var resultProducts = AppRuntime.MarketData.getProductsByCategories(CategoryID);
                if (resultProducts.ServiceResponseStatus.IsSuccess)
                {
                    var listProducts = resultProducts.Products.ToList();
                    ProductsTableViewSource TableSource = new ProductsTableViewSource(listProducts, this);
                    ProductsTableView.Source = TableSource;
                    ProductsTableView.RowHeight = 176f;
                    ProductsTableView.ReloadData();

                    TableSource.ProductButtonTapped -= ButtonInCellClicked;
                    TableSource.ProductButtonTapped += ButtonInCellClicked;
                }
                else
                {
                    //wait DisplayAlert("Alert", "You have been alerted", "OK");
                }
            }
        }

        void ButtonInCellClicked(object sender, Schemas.Product.ProductInfo e)
        {
            ProductsDetailController controllerProducts = this.Storyboard.InstantiateViewController("ProductsDetailController") as ProductsDetailController;
            controllerProducts.ProductID = e.Id;
            controllerProducts.Title = e.Name.ToUpper();
            this.NavigationController.PushViewController(controllerProducts, true);
        }

        void BindProducts() {
            ProductsTableView.ReloadData();
        }
    }
}