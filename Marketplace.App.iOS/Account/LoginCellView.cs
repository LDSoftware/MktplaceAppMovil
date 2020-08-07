using Foundation;
using System;
using System.Globalization;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class LoginCellView : UITableViewCell
    {

        public LoginCellView (IntPtr handle) : base (handle)
        {
        }

        internal void FillOptions(Schemas.Login.DistributorInfo distributor, NSIndexPath indexPath,
            AccountViewController controller)
        {

            lblDistributorId.Text = "Distribuidor " + distributor.Id;
            lblDistributorMail.Text = distributor.Email;
            lblCreditContpaq.Text = distributor.BalanceInfo.CreditLimit.ToString("C", CultureInfo.CurrentCulture);
            lblPendingBalance.Text = distributor.BalanceInfo.PendingBalance.ToString("C", CultureInfo.CurrentCulture);
            lblCurrentBalance.Text = distributor.BalanceInfo.CurrentBalance.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}