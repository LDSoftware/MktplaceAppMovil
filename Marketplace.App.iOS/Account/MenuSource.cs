using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Essentials;

namespace Marketplace.App.iOS
{
    internal class MenuSource : UITableViewSource
    {
        string CellIdentifier = "OptionMenuCell";
        string CellIdLogint = "LoginCellView";
        string CellIdLogout = "LogoutCellView";
        private AccountViewController accountViewController;
        private Dictionary<string, List<string>> dic;
        private string[] tableSection;

        public Schemas.Login.DistributorInfo distributor { get; set; }


        public MenuSource(Dictionary<string, List<string>> dic, AccountViewController accountViewController)
        {
            this.dic = dic;
            this.accountViewController = accountViewController;
            this.tableSection = dic.Keys.ToArray();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "ConSesion")
            {
                var cell = (LoginCellView)tableView.DequeueReusableCell(CellIdLogint, indexPath);
                cell.FillOptions(distributor, indexPath, accountViewController);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }
            else if (dic[tableSection[indexPath.Section]][indexPath.Row] == "SinSesion")
            {
                var cell = (LogoutCellView)tableView.DequeueReusableCell(CellIdLogout, indexPath);
                cell.FillOptions(dic[tableSection[indexPath.Section]][indexPath.Row], indexPath,accountViewController);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }
            else
            {
                var cell = (OptionMenuCell)tableView.DequeueReusableCell(CellIdentifier, indexPath);
                cell.FillOptions(dic[tableSection[indexPath.Section]][indexPath.Row], indexPath);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }
            
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return tableSection.Length;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return dic[tableSection[section]].Count;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return tableSection[section];
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Direcciones")
            {
                InfoDireccViewController vcInstance = (InfoDireccViewController)storyboard.InstantiateViewController("InfoDireccViewController");
                vcInstance.distributor = distributor;
                vcInstance.option = 2;
                vcInstance.titleOne = "Domicilio Fiscal";
                vcInstance.titleTwo = "Domicilio Comercial";
                accountViewController.NavigationController.PushViewController(vcInstance, true);
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Aviso de Privacidad")
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.contpaqi.com/aviso-de-privacidad"));
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Nosotros")
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.contpaqi.com/nosotros"));
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Información del cliente")
            {
                InfoDireccViewController vcInstance = (InfoDireccViewController)storyboard.InstantiateViewController("InfoDireccViewController");
                vcInstance.distributor = distributor;
                vcInstance.option = 1;
                vcInstance.titleOne = "Datos personales";
                vcInstance.titleTwo = "Datos de la compañía";
                accountViewController.NavigationController.PushViewController(vcInstance, true);
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Contáctanos al 800 317 1111")
            {
                NSUrl url = new NSUrl("tel:8003171111");
                if (UIApplication.SharedApplication.CanOpenUrl(url))
                {
                    UIApplication.SharedApplication.OpenUrl(url);
                }
                else
                {
                    Console.WriteLine("Cannot open url: {0}", url.AbsoluteString);
                }
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Órdenes")
            {
                OrdersViewController vcInstance = (OrdersViewController)storyboard.InstantiateViewController("OrdersViewController");
                accountViewController.NavigationController.PushViewController(vcInstance, true);
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Productos Favoritos")
            {
                FavoritesViewController vcInstance = (FavoritesViewController)storyboard.InstantiateViewController("FavoritesViewController");
                accountViewController.NavigationController.PushViewController(vcInstance, true);
            }

            if (dic[tableSection[indexPath.Section]][indexPath.Row] == "Cerrar Sesión")
            {
                AppSecurity.IsLogged = false;
                AppSecurity.distributorLogged = null;
                accountViewController.CheckAuthentication();
            }
        }
    }
}