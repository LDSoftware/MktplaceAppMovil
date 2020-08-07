using Foundation;
using Marketplace.App.iOS.Helper;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class BusquedaCellView : UICollectionViewCell
    {
        internal static string CellID = "BusquedaCellView";

        public BusquedaCellView (IntPtr handle) : base (handle)
        {
        }

        internal void fillData(List<Schemas.Search.SearchProductModel> listData, NSIndexPath indexPath)
        {
            ProductNameLabel.Text = listData[indexPath.Row].ProductName;
            ProductImageView.Image = MarketHelper.FromUrl(listData[indexPath.Row].Image);
        }
    }
}