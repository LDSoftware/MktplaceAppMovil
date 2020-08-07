using Foundation;
using Marketplace.App.iOS.Basket;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class BasketVieController : UIViewController
    {
        List<Schemas.Product.ProductInfo> rows { get; set; }
        Boolean isEditing = false;
        public BasketVieController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = true;
            this.Title = "Carrito";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            rows = new List<Schemas.Product.ProductInfo>();
            var product = new Schemas.Product.ProductInfo();
            product.Id = 1;
            product.Name = "CONTPAQI® XML EN LÍNEA +, MULTIEMPRESA, LICENCIA ANUAL 100 USUARIO(S) - PAQUETE(PLXLMUL)";
            rows.Add(product);
            var product1 = new Schemas.Product.ProductInfo();
            product1.Id = 2;
            product1.Name = "CONTPAQI® BANCOS, MULTIEMPRESA, LICENCIA ANUAL 3 USUARIO(S) - RENOVACIÓN(ALBANLA)";
            rows.Add(product1);
            BasketSource TableSource = new BasketSource(rows, this);
            BasketTableView.Source = TableSource;
            BasketTableView.RowHeight = 176f;
            BasketTableView.ReloadData();
            BasketTableView.TableFooterView = new UIView();

            CheckoutButton.Layer.CornerRadius = 8;
        }

        partial void EditBasketDidTouch(UIButton sender)
        {
            if (isEditing)
            {
                isEditing = false;
                EditTableButton.SetTitle("Editar", UIControlState.Normal);
                BasketTableView.SetEditing(false, true);
            }
            else
            {
                isEditing = true;
                EditTableButton.SetTitle("Listo", UIControlState.Normal);
                BasketTableView.SetEditing(true, true);
            }
        }

        partial void CheckoutDidTouch(UIButton sender)
        {
            Console.WriteLine("go to checkout");
        }
    }
}