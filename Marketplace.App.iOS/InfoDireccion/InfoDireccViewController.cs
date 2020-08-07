using Foundation;
using Marketplace.App.iOS.InfoDireccion;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class InfoDireccViewController : UIViewController
    {
        internal string titleOne;
        internal string titleTwo;
        internal int option;
        public Schemas.Login.DistributorInfo distributor { get; set; }

        public InfoDireccViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TitleOne.Text = titleOne;
            TwoLabel.Text = titleTwo;
           
            SetupUI();
            if (option == 1)
            {
                FillDataInfoUser();
            }
            else
            {
                FillDataAdress();
            }
            

        }

        private void SetupUI()
        {
            
            OneTableView.Layer.CornerRadius = 8;
            TwoTableView.Layer.CornerRadius = 8;
        }

        private void FillDataInfoUser()
        {
            Dictionary<string, List<string>> oneData = new Dictionary<string, List<string>>();


            oneData.Add("oneTitle", new List<string>()
            {
                "Nombres(s)",
                "Apellido(s)",
                "E-mail"
            });

            oneData.Add("oneInfo", new List<string>()
            {
                distributor.FirstName,
                distributor.LastName,
                distributor.Email
            });

            Dictionary<string, List<string>> twoData = new Dictionary<string, List<string>>();

            twoData.Add("twoTitle", new List<string>()
            {
                "Empresa",
                "CID"
            });

            twoData.Add("twoInfo", new List<string>()
            {
                distributor.CompanyName,
                distributor.Cid
            });

            OneTableView.Source = new InfoDirSource(oneData, "OneInfoDirTableCell");
            TwoTableView.Source = new InfoDirSource(twoData, "TwoInfoDirTableCell");
            OneTableView.ReloadData();
            TableOneHeight.Constant = OneTableView.ContentSize.Height;
            TwoTableView.ReloadData();
            TableTwoHeight.Constant = TwoTableView.ContentSize.Height + 10;
        }

        private void FillDataAdress()
        {
            Dictionary<string, List<string>> oneData = new Dictionary<string, List<string>>();

            oneData.Add("oneTitle", new List<string>()
            {
                "E-mail",
                "Número de \nteléfono",
                "Dirección"
            });

            oneData.Add("oneInfo", new List<string>()
            {
                distributor.FiscalAddressInfo.Email,
                distributor.FiscalAddressInfo.PhoneNumber,
                distributor.FiscalAddressInfo.Address
            });

            Dictionary<string, List<string>> twoData = new Dictionary<string, List<string>>();

            twoData.Add("twoTitle", new List<string>()
            {
                "E-mail",
                "Número de \nteléfono",
                "Dirección"
            });

            twoData.Add("twoInfo", new List<string>()
            {
               distributor.ComercialAddressInfo.Email,
                distributor.ComercialAddressInfo.PhoneNumber,
                distributor.ComercialAddressInfo.Address
            });

            OneTableView.Source = new InfoDirSource(oneData, "OneInfoDirTableCell");
            TwoTableView.Source = new InfoDirSource(twoData, "TwoInfoDirTableCell");
            OneTableView.ReloadData();
            TableOneHeight.Constant = OneTableView.ContentSize.Height + 60;
            TwoTableView.ReloadData();
            TableTwoHeight.Constant = TwoTableView.ContentSize.Height + 60;

        }
    }
}