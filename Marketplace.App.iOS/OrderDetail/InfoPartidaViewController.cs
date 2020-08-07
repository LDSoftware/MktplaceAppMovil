using Foundation;
using Marketplace.Schemas.Order;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class InfoPartidaViewController : UIViewController
    {
        public OrderItemInfo detail { get; set; }


        public InfoPartidaViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
            
            TitleLabel.Text = detail.ProductName;//"CONTPAQI® 500 TIMBRES - PAQUETE(PDTIM500)";

            var certificados = detail.Licenses;

            CertificateSource TableSource = new CertificateSource(certificados, this);

            CertificatesTableView.Source = TableSource;
            CertificatesTableView.ReloadData();
            CertificatesTableView.TableFooterView = new UIView();
        }

        partial void CloseInfoAction(UIButton sender)
        {
            this.DismissViewController(true, null);
        }
    }
}