using System;
using Marketplace.App.iOS.Utils;
using UIKit;

namespace Marketplace.App.iOS
{
    public static class AppSecurity
    {
        public static bool IsLogged { get; set; }
        public static Schemas.Login.DistributorInfo distributorLogged { get; set; }
        public static Schemas.Services.SecurityInfo securityToken { get; set; }
        private static UIViewController accountViewController;

        public static void hasExpired(Marketplace.Schemas.Services.SessionInfoResponse session, UIViewController controller) {
            accountViewController = controller;
            if (session.MultiSessionDetect) {
                AppSecurity.IsLogged = false;
                accountViewController.NavigationController.PopToRootViewController(true);
                MarketUtils.AlertView(controller, "Seguridad", "Se ha detectado otro inicio de sesión con el mismo usuario, se ha cerrado esta sesión.");
                return;
            }
        }
    }
}
