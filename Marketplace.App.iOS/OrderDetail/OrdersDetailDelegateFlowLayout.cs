using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using Marketplace.Schemas.Order;
using UIKit;

namespace Marketplace.App.iOS
{
    internal class OrdersDetailDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        private OrderDetailViewController orderDetailViewController;
        private List<OrderItemInfo> rows;

        public OrdersDetailDelegateFlowLayout(List<OrderItemInfo> _rows,OrderDetailViewController orderDetailViewController)
        {
            this.rows = _rows;
            this.orderDetailViewController = orderDetailViewController;
        }

        [Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            UICollectionViewFlowLayout layout1 = (UICollectionViewFlowLayout)collectionView.CollectionViewLayout;
            var space = layout1.MinimumInteritemSpacing + layout1.SectionInset.Left + layout1.SectionInset.Right;
            var size = (orderDetailViewController.View.Frame.Size.Width / 2.5) - space;
            return new CGSize(size, size);
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var Detail = rows[indexPath.Row];
            InfoPartidaViewController detailViewController = orderDetailViewController.Storyboard.InstantiateViewController("InfoPartidaViewController") as InfoPartidaViewController;
            detailViewController.detail = Detail;
            detailViewController.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
            orderDetailViewController.PresentViewController(detailViewController, true, null);
        }
    }
}