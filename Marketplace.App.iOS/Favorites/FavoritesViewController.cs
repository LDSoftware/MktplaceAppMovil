using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using ObjCRuntime;
using Marketplace.App.Runtime;
using Marketplace.Schemas.Product;

namespace Marketplace.App.iOS
{
    public partial class FavoritesViewController : UIViewController
    {
      
        List<ProductInfo> itemsForDelete = new List<ProductInfo>();

        public FavoritesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            BuildButtons(false);
            base.ViewDidLoad();
            bindFavoriteProduct();
        }

        private void BuildButtons(bool editing)
        {
            NavigationItem.RightBarButtonItems = null;
            if (editing)
            {
                UIBarButtonItem cancel = new UIBarButtonItem(title: "Cancelar", style: UIBarButtonItemStyle.Plain, target: this, action: new Selector("CancelEdit:"));
                UIBarButtonItem delete = new UIBarButtonItem(title: "Eliminar", style: UIBarButtonItemStyle.Plain, target: this, action: new Selector("DeleteFavorite:"));
                UIBarButtonItem[] items = new UIBarButtonItem[2] { cancel, delete };
                NavigationItem.RightBarButtonItems = items;

            }
            else
            {
                this.NavigationItem.RightBarButtonItem = new UIBarButtonItem(title: "Editar", style: UIBarButtonItemStyle.Plain, target: this, action: new Selector("EditFavorites:"));
            }
        }
     
        [Export("EditFavorites:")]
        private void EditFavorites(UIBarButtonItem sender)
        {
            BuildButtons(true);
            FavoritesTableView.SetEditing(true, true);
        }

        [Export("CancelEdit:")]
        private void CancelEdit(UIBarButtonItem sender)
        {
            BuildButtons(false);
            FavoritesTableView.SetEditing(false, true);
            itemsForDelete = new List<ProductInfo>();
        }

        [Export("DeleteFavorite:")]
        private void DeleteFavorite(UIBarButtonItem sender)
        {
            var optionMenu = UIAlertController.Create(null, null, UIAlertControllerStyle.ActionSheet);
            optionMenu.AddAction(UIAlertAction.Create("Eliminar", UIAlertActionStyle.Destructive,
                alert =>
                {
                    for (int i = 0; i < itemsForDelete.Count; i++)
                    {
                        var prd = itemsForDelete[i];
                        AppRuntime.MarketliteDB.DeleteFavoriteProduct(prd);
                    }

                    BuildButtons(false);
                    FavoritesTableView.SetEditing(false, true);
                    bindFavoriteProduct();
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel,
               alert =>
               {
                   Console.WriteLine("Cancelar");
               }
           ));

            PresentViewController(optionMenu, true, null);
        }

        void bindFavoriteProduct() {
            var resultFavorites = AppRuntime.MarketliteDB.getFavoriteProduct();

            FavoriteViewSource favorites = new FavoriteViewSource(resultFavorites, this);
            FavoritesTableView.Source = favorites;
            FavoritesTableView.ReloadData();
            FavoritesTableView.AllowsMultipleSelectionDuringEditing = true;
            FavoritesTableView.TableFooterView = new UIView();
        }

        public void ItemsForDelete(ProductInfo id) {
            itemsForDelete.Add(id);
        }

        public void removeItemsForDelete(ProductInfo id)
        {
            itemsForDelete.Remove(id);
        }

    }
}