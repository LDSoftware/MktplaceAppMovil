using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Marketplace.App.iOS
{
    internal class BusquedaSource : UICollectionViewSource
    {
        List<Schemas.Search.SearchProductModel> rows { get; set; }

        public BusquedaSource(List<Schemas.Search.SearchProductModel> _rows)
        {
            this.rows = _rows;
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
            var cell = (BusquedaCellView)collectionView.DequeueReusableCell(BusquedaCellView.CellID, indexPath);
            cell.Layer.BorderColor = UIColor.LightGray.CGColor;
            cell.Layer.BorderWidth = 1.0f;
            cell.Layer.CornerRadius = 5;
            cell.fillData(rows, indexPath);

            return cell;
        }

    }
}