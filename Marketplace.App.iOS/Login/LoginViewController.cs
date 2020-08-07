using System;
using System.Drawing;
using Foundation;
using Marketplace.App.iOS.Utils;
using Marketplace.App.Runtime;
using UIKit;
using Xamarin.Essentials;

namespace Marketplace.App.iOS
{
    public partial class LoginViewController : UIViewController
    {
        private AccountViewController ctr;

        private SpinnerViewController spinner = new SpinnerViewController();
        public LoginViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            SetupUI();
            HandleButtons();
            this.NavigationController.NavigationBarHidden = false;
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // TEST ENVIRONMENT ONLY 
            EmailTextField.Text = "masterpruebas@yahoo.com";
            PasswordTextField.Text = "Admin1234$";
        }

        private void SetupUI() {
            spinner = new SpinnerViewController();
            EmailTextField.Layer.BorderWidth = 1;
            EmailTextField.Layer.CornerRadius = 8;
            PasswordTextField.Layer.BorderWidth = 1;
            PasswordTextField.Layer.CornerRadius = 8;
            LoginButton.Layer.CornerRadius = 8;
        }

        private void StartAnimation()
        {
             AddChildViewController(spinner);
             spinner.View.Frame = this.View.Frame;
             this.View.AddSubview(spinner.View);
             spinner.DidMoveToParentViewController(this);
        }

        private void StopAnimation()
        {
            spinner.RemoveView();
        }

        private void HandleButtons()
        {
            LoginButton.TouchUpInside += (sender, e) => {
                LoginAction();
            };
        }


        private void LoginAction(){
            StartAnimation();

            if (EmailTextField.Text == "")
            {
                BadLoginLabel.Hidden = false;
                EmailTextField.Layer.BorderColor = UIColor.Red.CGColor;
                PasswordTextField.Layer.BorderColor = UIColor.Red.CGColor;
                var timer = NSTimer.CreateScheduledTimer(1, false, (t) =>
                {
                    StopAnimation();
                });
            }
            else
            {
                // Valida usuario
                var timer = NSTimer.CreateScheduledTimer(3, false, (t) =>
                {
                    
                    var loginResult = AppRuntime.MarketData.LoginDistributor(new Schemas.Login.LoginModel
                    {
                        Email = EmailTextField.Text,
                        Password = PasswordTextField.Text
                    });

                    // Si no responde nulo el servicio
                    // Asignamos datos y cambiamos de controlador
                    if (loginResult.DistributorInfoResult != null)
                    {
                        BadLoginLabel.Hidden = true;
                        EmailTextField.Layer.BorderColor = UIColor.Black.CGColor;
                        PasswordTextField.Layer.BorderColor = UIColor.Black.CGColor;

                        AppSecurity.IsLogged = true;
                        AppSecurity.distributorLogged = loginResult.DistributorInfoResult;
                        AppSecurity.securityToken = loginResult.SecurityInfo;

                        StopAnimation();
                        this.NavigationController.PopViewController(true);
                    }
                    else
                    {
                        BadLoginLabel.Hidden = false;
                        EmailTextField.Layer.BorderColor = UIColor.Red.CGColor;
                        PasswordTextField.Layer.BorderColor = UIColor.Red.CGColor;
                        StopAnimation();
                    }
                });
               
              
            }

        }
    }
}