using Foundation;
using Marketplace.App.Runtime;
using System;
using System.Drawing;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class ProductsCellView : UITableViewCell
    {
        public static NSString CellID = new NSString("ProductCell_Id");
        public event EventHandler<Schemas.Product.ProductInfo> ProductButtonTapped;
        public Schemas.Product.ProductInfo CurrentProduct { get; private set; }

        public ProductsCellView (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(Schemas.Product.ProductInfo entity)
        {

            lblProductName.Text = entity.Name;
            ProductImage.Image = FromUrl(entity.Image);

            // Verificamos si el producto existe
            var favoriteProduct = AppRuntime.MarketliteDB.ExistFavoriteProduct(entity);

            if (favoriteProduct != null)
            {
                btnfavoritelist.ImageView.Image = btnfavoritelist.ImageView.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                btnfavoritelist.ImageView.TintColor = UIColor.Red;
            }

            }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        void OnSpeakButtonTapped(object sender, EventArgs e)
        {
            // This is the event handler for the actual UIButton TouchUpInside event.
            // In this handler, we will invoke this cell's SpeakButtonTapped event to "bubble up" to the TableViewSource.
            if (ProductButtonTapped != null)
                ProductButtonTapped(this, CurrentProduct);
        }

        public void SetProduct(Schemas.Product.ProductInfo entity)
        {
            this.CurrentProduct = entity;
        }
    }
}