using Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class AccountViewController : UIViewController
    {
        List<string> cuenta = new List<string>();
        Dictionary<string, List<String>> dic = new Dictionary<string, List<String>>();

        public AccountViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = false;
            CheckAuthentication();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public void CheckAuthentication()
        {
            dic.Clear();
            cuenta.Clear();

            var acerca = new List<string>()
            {
                "Versión 1.0",
                "Aviso de Privacidad",
                "Nosotros",
                "Contáctanos al 800 317 1111"
            };

            if (AppSecurity.IsLogged)
            {
                cuenta.AddRange(new List<string>()
            {
                "ConSesion",
                "Productos Favoritos",
                "Información del cliente",
                "Direcciones",
                "Órdenes",
                "Cerrar Sesión"
            });
            }
            else
            {
                cuenta.Add("SinSesion");
            }

            dic.Add("Cuenta", cuenta);
            dic.Add("Acerca de", acerca);

            MenuSource menuSource = new MenuSource(dic, this);
            menuSource.distributor = AppSecurity.distributorLogged;
            MenuTableView.Source = menuSource;
            MenuTableView.ReloadData();
            MenuTableView.TableFooterView = new UIView();

        }
    }
}