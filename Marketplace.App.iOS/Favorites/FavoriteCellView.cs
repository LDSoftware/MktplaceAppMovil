using Foundation;
using Marketplace.App.iOS.Helper;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class FavoriteCellView : UITableViewCell
    {
        public FavoriteCellView (IntPtr handle) : base (handle)
        {
        }

        internal void FillProducts(Schemas.Product.ProductInfo entity, NSIndexPath indexPath)
        {
            ProductName.Text = entity.Name;
            ProductDescription.Text = entity.FullDescription;
            ProductImage.Image = MarketHelper.FromUrl(entity.Image);
        }
    }
}