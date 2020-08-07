using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class BasketTableCell : UITableViewCell
    {
        public BasketTableCell (IntPtr handle) : base (handle)
        {
        }

        internal void FillProducts(Schemas.Product.ProductInfo entity)
        {

            ProductDescriptionLabel.Text = entity.Name;
            //PorductImageView.Image = FromUrl(entity.Image);
            ProductPriceLabel.Text = "$3333.33";
            ProductQuantityTextField.Text = "1";

        }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}