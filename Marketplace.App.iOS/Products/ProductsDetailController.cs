using Foundation;
using Marketplace.App.iOS.Helper;
using Marketplace.App.Runtime;
using System;
using System.Collections.Generic;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class ProductsDetailController : UIViewController
    {
        public int ProductID { get; set; }
        private Schemas.Product.ProductInfo Product;
        private Schemas.Product.CompaniesNumberType companyType;

        private Schemas.Services.ProductQuotationServiceRequest quotationReq;

        public ProductsDetailController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = false;
            NoLicenceViewLayoutConstraint.Constant = 0;
            NoLicenceView.Hidden = true;
            HaveLicenseTrueView.Hidden = true;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnBeneficios.TouchUpInside += (sender, e) => {
                AlertView("Beneficios y caracteristicas", Product.BenefitsCharacteristics);
            };

            HaveLicenceButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            HaveLicenceButton.Layer.BorderWidth = 2.0f;
            HaveLicenceButton.Layer.CornerRadius = 8;

            NoHaveLicenceButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            NoHaveLicenceButton.Layer.BorderWidth = 2.0f;
            NoHaveLicenceButton.Layer.CornerRadius = 8;

            VerifyButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            VerifyButton.Layer.BorderWidth = 2.0f;
            VerifyButton.Layer.CornerRadius = 8;

            AddToCarButton.Layer.CornerRadius = 8;
            CotizarButton.Layer.CornerRadius = 8;

            NumberUsersTextField.Text = "1";
            NumberProductsTextField.Text = "1";

            NumberUsersTextField.AddTarget(ValueNoUserChanged, UIControlEvent.EditingChanged);
            NumberProductsTextField.AddTarget(ValueNoProductsChanged, UIControlEvent.EditingChanged);

            btnProductInfo.TouchUpInside += (sender, e) => {
                UIApplication.SharedApplication.OpenUrl(new NSUrl(Product.ProductInfoUrl));
            };

            // Cuando se hace click en el corazon
            // Guardamos localmente el producto en liteDB
            btnFavorite.Clicked += (sender, e) => {
                // Verificamos si el producto existe
                var favoriteProduct = AppRuntime.MarketliteDB.ExistFavoriteProduct(Product);

                if (favoriteProduct == null)
                {
                    // Insertamos en liteDB los resultados
                    var resultInsert = AppRuntime.MarketliteDB.FavoriteProduct(Product);
                    if (resultInsert.IsSucess)
                    {
                        btnFavorite.TintColor = UIColor.Red;
                        string AlertMessage = string.Format("Se ha agregado el producto {0} a tus favoritos.", Product.Name);
                        AlertView("Favoritos", AlertMessage);
                    }
                }
                else
                {
                    // Insertamos en liteDB los resultados
                    var resultDelete = AppRuntime.MarketliteDB.DeleteFavoriteProduct(Product);
                    if (resultDelete.IsSucess)
                    {
                        btnFavorite.TintColor = null;
                        string AlertMessage = string.Format("Se ha eliminado el producto {0} de tus favoritos.", Product.Name);
                        AlertView("Favoritos", AlertMessage);
                    }
                }
               
            };


            var result = AppRuntime.MarketData.getProdyctById(ProductID);

            if (result.ServiceResponseStatus.IsSuccess)
            {
                Product = result.Product;

                imgProductDetail.Image = MarketHelper.FromUrl(Product.Image);
                lblProductNameDetail.Text = Product.Name;
                lblProductDescription.Text = Product.FullDescription;

                // Revisamos si esta marcado como favorito
                // y lo pintamos de rojo
                // Verificamos si el producto existe
                var favoriteProduct = AppRuntime.MarketliteDB.ExistFavoriteProduct(Product);
                if (favoriteProduct==null)
                {
                    btnFavorite.TintColor = null;
                }
                else
                {
                    btnFavorite.TintColor = UIColor.Red;
                }

                // Cargamos la informacion para poder realizar la cotizacion
                LoadQuotation(result.Product.ProductQuotation);
            }


            CotizarButton.TouchUpInside += (sender, e) => {
                calculateQuotation();
                   };
         
        }

        public void AlertView(string tittle, string message)
        {
           
            //Create Alert
            var okAlertController = UIAlertController.Create(tittle, message, UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }

        partial void NoHaveLicenceAction(UIButton sender)
        {
            NoHaveLicenceButton.Layer.BorderColor = UIColor.FromRGB(0, 114, 188).CGColor;
            HaveLicenceButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            NoLicenceViewLayoutConstraint.Constant = 255;
            NoLicenceView.Hidden = false;
            HaveLicenseTrueView.Hidden = true;
            CotizarButton.Hidden = false;
        }

        partial void HaveLicenceAction(UIButton sender)
        {
            HaveLicenceButton.Layer.BorderColor = UIColor.FromRGB(0, 114, 188).CGColor;
            NoHaveLicenceButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            NoLicenceViewLayoutConstraint.Constant = 255;
            NoLicenceView.Hidden = false;
            HaveLicenseTrueView.Hidden = false;
        }

        private void ChooseType()
        {
            var optionMenu = UIAlertController.Create(null, "Elegir Opción", UIAlertControllerStyle.ActionSheet);
            optionMenu.AddAction(UIAlertAction.Create("Paquete", UIAlertActionStyle.Default,
                alert =>
                {
                    TypeNameButton.SetTitle("Paquete", UIControlState.Normal);
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Paquete 2", UIAlertActionStyle.Default,
                alert =>
                {
                    TypeNameButton.SetTitle("Paquete 2", UIControlState.Normal);
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel,
               alert =>
               {

               }
           ));

            PresentViewController(optionMenu, true, null);
        }

        partial void TypeOperationDidTouch(UIButton sender)
        {
           
            //ChooseType();
        }

        partial void TypeOperationDidTouch2(UIButton sender)
        {
            //ChooseType();
        }

        private void ChooseEnterprises()
        {
            var optionMenu = UIAlertController.Create(null, "Elegir Opción", UIAlertControllerStyle.ActionSheet);

            for (int i = 0; i < Product.ProductQuotation.CompaniesNumberTypes.Count; i++)
            {
                var companyTypeSelect = Product.ProductQuotation.CompaniesNumberTypes[i];

                optionMenu.AddAction(UIAlertAction.Create(companyTypeSelect.Name, UIAlertActionStyle.Default,
                               alert =>
                               {
                                   companyType = companyTypeSelect;
                                   EnterpriseNameButton.SetTitle(companyTypeSelect.Name, UIControlState.Normal);
                               }
                           ));
            }
            optionMenu.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel,
               alert =>
               {

               }
           ));

            PresentViewController(optionMenu, true, null);
        }

        partial void EnterprisesDidTouch(UIButton sender)
        {
            ChooseEnterprises();
        }

        partial void EnterprisesDidTouch2(UIButton sender)
        {
            ChooseEnterprises();
        }

        void LoadQuotation(Schemas.Product.ProductQuotationInfo quotationInfo) {
            var companiesNumber = quotationInfo.CompaniesNumberTypes.Count;
            EnterpriseNameButton.SetTitle(quotationInfo.CompaniesNumberTypes[0].Name, UIControlState.Normal);

            if (companiesNumber > 0)
            {
                companyType = quotationInfo.CompaniesNumberTypes[0];
                if (companiesNumber==1) {
                    EnterpriseNameButton2.Hidden = true;
                    EmpresasView.Hidden = true;
                    TypeNameButton.RemoveTarget((sender, e) => TypeOperationDidTouch((UIButton)TypeNameButton), UIControlEvent.TouchUpInside);
                }
                else
                {
                    EnterpriseNameButton2.Hidden = false;
                    EmpresasView.Hidden = false;
                }
            }
        }

        void calculateQuotation()
        {
            quotationReq = new Schemas.Services.ProductQuotationServiceRequest();
            //Asignamos el token que tenemos en memoria
            quotationReq.SessionInfo = new Schemas.Services.SessionInfoRequest()
            {
                TokenSession = ""
            };

            quotationReq.QuotationParameter = new Schemas.Quotation.ProductQuotationParameter()
            {
                CompaniesNumberTypeId = companyType.Id,
                UserId = 0,
                LicenseIdentifier = null,
                LotNumber = null,
                ExtraParameters = null,
                ProductId = Product.Id,
                LicenseTypeId = Product.ProductQuotation.LicenseTypeId,
                ProductQuantity = int.Parse(NumberProductsTextField.Text),
                PurchaseTypeId = Product.ProductQuotation.PurchaseTypeId,
                UserQuantity = int.Parse(NumberUsersTextField.Text)
            };

            var result = AppRuntime.MarketData.getQuotation(quotationReq, "");

            if (result.ServiceResponseStatus.IsSuccess)
            {
                var quotationResult = result.ProductQuotationInfo;

                lblTotalQuotation.Hidden = false;
                AddToCarButton.Hidden = false;
                lblTotalQuotation.Text = quotationResult.UnitPrice.ToString("C");
            }
        }

        private void ValueNoUserChanged(object sender, EventArgs e)
        {
            var searchValue = int.Parse(NumberUsersTextField.Text.Trim() == "" ? "0": NumberUsersTextField.Text.Trim()) ;
            NumberUsersTextField.Text = searchValue.ToString();

            lblTotalQuotation.Hidden = true;
            AddToCarButton.Hidden = true;
        }

        private void ValueNoProductsChanged(object sender, EventArgs e)
        {
            var searchValue = int.Parse(NumberProductsTextField.Text.Trim()==""?"0": NumberProductsTextField.Text.Trim());
            NumberUsersTextField.Text = searchValue.ToString();

            lblTotalQuotation.Hidden = true;
            AddToCarButton.Hidden = true;
        }

        partial void VerifySeriesDidTouch(UIButton sender)
        {
            AlertView("Nº Serie / Nº Lote", "El Nº de serie/lote no es válido, verifique.");
        }

        partial void ShowLicenseDidTouch(UIButton sender)
        {
            
        }

        partial void OperationTypeDidTouch(UIButton sender)
        {
            ChooseOperationType();
        }

        partial void OperationTypeDidTouch2(UIButton sender)
        {
            ChooseOperationType();
        }

        private void ChooseOperationType()
        {

            var optionMenu = UIAlertController.Create(null, "Elegir Opción", UIAlertControllerStyle.ActionSheet);
            optionMenu.AddAction(UIAlertAction.Create("Renovación", UIAlertActionStyle.Default,
                alert =>
                {
                    OperationTypeLabel.SetTitle("Renovación", UIControlState.Normal);
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Nueva", UIAlertActionStyle.Default,
                alert =>
                {
                    OperationTypeLabel.SetTitle("Nueva", UIControlState.Normal);
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel,
               alert =>
               {

               }
           ));

            PresentViewController(optionMenu, true, null);
        }
    }
}