using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS.Categories
{
    public class CategoriesDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {

        List<Schemas.Category.CategoryInfo> rows { get; set; }
        CategoriasViewController categoriasVC;
        public CategoriesDelegateFlowLayout(System.Collections.Generic.List<Schemas.Category.CategoryInfo> listCategories, CategoriasViewController categoriasViewController)
        {
            rows = listCategories;
            categoriasVC = categoriasViewController;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            ProductsViewController controllerProducts = categoriasVC.Storyboard.InstantiateViewController("ProductsViewController") as ProductsViewController;
            controllerProducts.CategoryID = rows[indexPath.Row].Id;
            controllerProducts.Title = rows[indexPath.Row].Name.ToUpper();
            categoriasVC.NavigationController.PushViewController(controllerProducts, true);
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            UICollectionViewFlowLayout layout1 = (UICollectionViewFlowLayout)collectionView.CollectionViewLayout;
            var space = layout1.MinimumInteritemSpacing + layout1.SectionInset.Left + layout1.SectionInset.Right;
            Console.WriteLine("some name -> " + space);
            layout1.MinimumLineSpacing = 3;
            var size = (collectionView.Frame.Size.Width / 2) - space;
            return new CGSize(size, size);
        }
    }
}
