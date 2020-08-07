using Foundation;
using System;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class LogoutCellView : UITableViewCell
    {
        public event EventHandler LoginButtonTapped;
        private AccountViewController accountViewController;

        public LogoutCellView (IntPtr handle) : base (handle)
        {
          
        }

        internal void FillOptions(string v, NSIndexPath indexPath,
            AccountViewController controller)
        {
            accountViewController = controller;

            LogoutButton.TouchUpInside -= OnSpeakButtonTapped;
            LogoutButton.TouchUpInside += OnSpeakButtonTapped;
        }

        void OnSpeakButtonTapped(object sender, EventArgs e)
        {
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            LoginViewController vcSearch = (LoginViewController)storyboard.InstantiateViewController("LoginViewController");
            accountViewController.NavigationController.PushViewController(vcSearch, true);
        }
    }
}