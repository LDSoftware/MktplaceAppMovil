using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Marketplace.Schemas.Order;

namespace Marketplace.App.iOS.Orders
{
    public class OrdersCollectionViewSource : UICollectionViewSource
    {

        string CellId = "OrderCellView";
        List<OrderModel> rows;

        public OrdersCollectionViewSource(List<OrderModel> _rows, OrdersViewController ordersViewController)
        {
            rows = _rows;
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
            var cell = (OrderCellView)collectionView.DequeueReusableCell(CellId, indexPath);
            var Order = rows[indexPath.Row];

            cell.Layer.BorderColor = UIColor.LightGray.CGColor;
            cell.Layer.BorderWidth = 2.0f;
            cell.Layer.CornerRadius = 8;
            cell.updateCell(Order);
            return cell;
        }

    }
}