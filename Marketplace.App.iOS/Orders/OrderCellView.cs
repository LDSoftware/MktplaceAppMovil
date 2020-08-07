using Foundation;
using Marketplace.Schemas.Order;
using System;
using System.Collections.Generic;
using System.Globalization;
using UIKit;


namespace Marketplace.App.iOS
{
    public partial class OrderCellView : UICollectionViewCell
    {

        public OrderCellView (IntPtr handle) : base (handle)
        {
        }

        internal void updateCell(OrderModel entity)
        {
            NumberOrderLabel.Text = string.Format("No. de Orden: {0}", entity.OrderId);
            EstatusLabel.Text = entity.Status;
            FechaLabel.Text = entity.CreateDate.ToString("dd/MM/yyyy");
            TotalLabel.Text = entity.Total.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}