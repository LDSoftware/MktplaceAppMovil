using System;
using System.Collections.Generic;
using Foundation;
using Marketplace.Schemas.Order;
using UIKit;


namespace Marketplace.App.iOS
{
    internal class OrdersDetailCollectionViewSource : UICollectionViewSource
    {
        string CellId = "OrderDetailCell";
        List<OrderItemInfo> rows;
        private OrderDetailViewController orderDetailViewController;

        public OrdersDetailCollectionViewSource(List<OrderItemInfo> _rows, OrderDetailViewController orderDetailViewController)
        {
            this.rows = _rows;
            this.orderDetailViewController = orderDetailViewController;
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
            var cell = (OrderDetailCell)collectionView.DequeueReusableCell(CellId, indexPath);
            var OrderDetail = rows[indexPath.Row];
            cell.Layer.BorderColor = UIColor.LightGray.CGColor;
            cell.Layer.BorderWidth = 2.0f;
            cell.Layer.CornerRadius = 8;
            cell.updateCell(OrderDetail);
            return cell;
        }
    }
}