using Foundation;
using Marketplace.Schemas.Order;
using System;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class OrderDetailCell : UICollectionViewCell
    {
        public OrderDetailCell (IntPtr handle) : base (handle)
        {
        }


        internal void updateCell(OrderItemInfo Entity)
        {
            NameProdLabel.Text = Entity.ProductName;
            ProductLabel.Text = Entity.Sku;
            TotalLabel.Text = Entity.Total.ToString("C");
            UsersLabel.Text = Entity.Quantity.ToString(); 
        }
    }
}