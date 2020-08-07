using Foundation;
using Marketplace.App.Runtime;
using System;
using System.Collections.Generic;
using UIKit;
using Marketplace.Schemas.Services;
using Marketplace.Schemas.Order;

namespace Marketplace.App.iOS
{
    public partial class OrderDetailViewController : UIViewController
    {
        public int OrderId { get; set; }
        public string TitleOrderId { get; internal set; }

        private OrderDetailInfoRequest requestService;
        private OrderItemModel orderDetail;

        public OrderDetailViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.TabBarController.TabBar.Hidden = true;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            this.TabBarController.TabBar.Hidden = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = string.Format(TitleOrderId);

            requestService = new OrderDetailInfoRequest()
            {
                OrderId = OrderId,
                SessionInfo = new SessionInfoRequest()
                { TokenSession= AppSecurity.securityToken.SessionId }
            };

            var resultOrder = AppRuntime.MarketData.getOrderById(requestService, AppSecurity.securityToken.Token);

            AppSecurity.hasExpired(resultOrder.SessionInfoResponse, this);

            List<OrderItemInfo> listOrders = new List<OrderItemInfo>();

            if (resultOrder.ServiceResponseStatus.IsSuccess) {
                orderDetail = resultOrder.OrderDetailInfo;
                listOrders = orderDetail.ItemsInfo;
            }

            OrdersDetailCollectionViewSource ordersS = new OrdersDetailCollectionViewSource(listOrders, this);
            OrderDetailCollectionView.Source = ordersS;
            OrdersDetailDelegateFlowLayout ordersDelegateFlowLayout = new OrdersDetailDelegateFlowLayout(listOrders, this);
            OrderDetailCollectionView.Delegate = ordersDelegateFlowLayout;
            OrderDetailCollectionView.ReloadData();

            SubtotalLabel.Text = orderDetail.TotalInfo.SubTotal.ToString("C");
            ImpuestoLabel.Text = orderDetail.TotalInfo.Taxes.ToString("C");
            TotalLabel.Text = orderDetail.TotalInfo.Total.ToString("C");

            loadFirstSegment();

            if (orderDetail.Invoice != null) {
                btnInvoice.TouchUpInside += (sender, e) => {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl(orderDetail.Invoice.CFDI));
                };
            }
        }

        partial void DataChanging(UISegmentedControl sender)
        {
            switch (OptionsSegment.SelectedSegment)
            {
                case 0:
                    KeyOneLabel.Text = "Estado de la orden";
                    KeyTwoLabel.Text = "Fecha";
                    KeyThreeLabel.Text = "Total";
                    loadFirstSegment();
                    break;
                case 1:
                    KeyOneLabel.Text = "Cliente";
                    KeyTwoLabel.Text = "Correo electrónico";
                    KeyThreeLabel.Text = "Teléfono";
                    ValueOneLabel.Text = AppSecurity.distributorLogged.FullName;
                    ValueTwoLabel.Text = AppSecurity.distributorLogged.Email;
                    ValueThreeLabel.Text = AppSecurity.distributorLogged.FiscalAddressInfo.PhoneNumber;
                    break;
                case 2:
                    KeyOneLabel.Text = "RFC";
                    KeyTwoLabel.Text = "Cliente";
                    KeyThreeLabel.Text = "Dirección";
                    ValueOneLabel.Text = AppSecurity.distributorLogged.Rfc;
                    ValueTwoLabel.Text = AppSecurity.distributorLogged.CompanyName;
                    ValueThreeLabel.Text = AppSecurity.distributorLogged.FiscalAddressInfo.Address;
                    break;
                case 3:
                    KeyOneLabel.Text = "Método de pago";
                    KeyTwoLabel.Text = "Estado de pago";
                    KeyThreeLabel.Text = "";
                    ValueOneLabel.Text = orderDetail.PaymentInfo.PaymentMethod;
                    ValueTwoLabel.Text = orderDetail.PaymentInfo.PaymentState;
                    ValueThreeLabel.Text = "";
                    break;
            }
        }

        void loadFirstSegment() {
            if (orderDetail.OrderInfo == null)
            {
                ValueOneLabel.Text = "-";
                ValueTwoLabel.Text = "-";
                ValueThreeLabel.Text = "-";
            }
            else {
                ValueOneLabel.Text = orderDetail.OrderInfo.Status;
                ValueTwoLabel.Text = orderDetail.OrderInfo.CreationDate.ToString("dd/MM/yyyy"); ;
                ValueThreeLabel.Text = orderDetail.OrderInfo.Total.ToString("C");
            }
           
        }
    }
}