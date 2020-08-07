using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS.Categories
{
    public class CatetoriesCollectionViewSource : UICollectionViewSource
    {
        List<Schemas.Category.CategoryInfo> rows { get; set; }
        CategoriasViewController categoriasViewController;

        public CatetoriesCollectionViewSource(List<Schemas.Category.CategoryInfo> _rows, CategoriasViewController _categoriasViewController)
        {
            rows = _rows;
            categoriasViewController = _categoriasViewController;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return rows.Count;
        }
        
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            Schemas.Category.CategoryInfo CellCategory = rows[indexPath.Row];
            var cell = (CategoriaCellView)collectionView.DequeueReusableCell(CategoriaCellView.CellID, indexPath);
            cell.Layer.BorderColor = UIColor.LightGray.CGColor;
            cell.Layer.BorderWidth = 2.0f;
            cell.Layer.CornerRadius = 8;

            cell.updateCell(rows[indexPath.Row]);
            cell.SetCategory(CellCategory);

            return cell;
        }
        

    }
}
