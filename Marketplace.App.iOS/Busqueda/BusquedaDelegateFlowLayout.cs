using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS.Busqueda
{
    public class BusquedaDelegateFlowLayout: UICollectionViewDelegateFlowLayout
    {
        List<Schemas.Search.SearchProductModel> rows { get; set; }
        BusquedaViewController VC;
        public BusquedaDelegateFlowLayout(List<Schemas.Search.SearchProductModel> listSearch, BusquedaViewController ViewController)
        {
            rows = listSearch;
            VC = ViewController;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            ProductsDetailController controllerProducts = VC.Storyboard.InstantiateViewController("ProductsDetailController") as ProductsDetailController;
            controllerProducts.ProductID = rows[indexPath.Row].IdProduct;
            controllerProducts.Title = rows[indexPath.Row].ProductName;
            VC.NavigationController.PushViewController(controllerProducts, true);
        }


        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            UICollectionViewFlowLayout layout1 = (UICollectionViewFlowLayout)collectionView.CollectionViewLayout;
            var space = layout1.MinimumInteritemSpacing + layout1.SectionInset.Left + layout1.SectionInset.Right;
            Console.WriteLine("some name -> " + space);
            var size = (collectionView.Frame.Size.Width / 3) - space;
            
            return new CGSize(size, size * 1.5);
        }
    }
}
