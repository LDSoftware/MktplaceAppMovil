using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Marketplace.Schemas.Order;
using UIKit;

namespace Marketplace.App.iOS.Orders
{
    public class OrdersDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        List<OrderModel> rows;

        public OrdersDelegateFlowLayout()
        {
        }
        OrdersViewController ordersViewController;

        public OrdersDelegateFlowLayout(List<OrderModel> _rows,OrdersViewController ordersViewController)
        {
            rows = _rows;
            this.ordersViewController = ordersViewController;
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            UICollectionViewFlowLayout layout1 = (UICollectionViewFlowLayout)collectionView.CollectionViewLayout;
            var space = layout1.MinimumInteritemSpacing + layout1.SectionInset.Left + layout1.SectionInset.Right;
            var size = (collectionView.Frame.Size.Width / 2) - space;
            return new CGSize(size, size);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var Order = rows[indexPath.Row];
            OrderDetailViewController detailViewController = ordersViewController.Storyboard.InstantiateViewController("OrderDetailViewController") as OrderDetailViewController;
            detailViewController.OrderId = Order.Id;
            detailViewController.TitleOrderId = Order.OrderId;
            ordersViewController.NavigationController.PushViewController(detailViewController, true);
        }
    }
}
