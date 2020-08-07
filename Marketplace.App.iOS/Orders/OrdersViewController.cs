using Foundation;
using Marketplace.App.iOS.Orders;
using System;
using System.Collections.Generic;
using UIKit;
using ObjCRuntime;
using Marketplace.App.Runtime;
using System.Linq;
using Marketplace.App.iOS.Common;
using System.Threading.Tasks;
using Marketplace.App.iOS.Helper;
using Marketplace.App.iOS.Utils;
using CoreFoundation;

namespace Marketplace.App.iOS
{
    public partial class OrdersViewController : UIViewController
    {
        IEnumerable<Schemas.Order.OrderModel> resultOrders;
        Schemas.Services.OrderRequest ordReq;

        private string OrderNumber = "";
        private string statusOrder = "";
        private string PeriodOrder = "";
        private DateTime InitDate = new DateTime(1900, 1, 1);
        private DateTime EndDate = new DateTime(1900, 1, 1);
        FilterOrderType TypeFilter = FilterOrderType.ByDistributor;

        UIRefreshControl RefreshControl;
        private SpinnerViewController spinner = new SpinnerViewController();

        public OrdersViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            NSUserDefaults.StandardUserDefaults.SetString("", "OrderStatus");
            NSUserDefaults.StandardUserDefaults.SetString("", "OrderPeriod");
            NSUserDefaults.StandardUserDefaults.SetString("", "InitDate");
            NSUserDefaults.StandardUserDefaults.SetString("", "EndDate");


            LoadOrders(TypeFilter);

            RefreshControl = new UIRefreshControl();
            RefreshControl.ValueChanged += RefreshControl_ValueChanged;
            OrdersCollectionView.AddSubview(RefreshControl);

            SearchTextField.AddTarget(ValueChanged, UIControlEvent.EditingChanged);

            this.NavigationItem.RightBarButtonItem = new UIBarButtonItem(title: "Mostrar", style: UIBarButtonItemStyle.Plain, target: this, action: new Selector("ShowSheetAlert:"));
            BorderNoOrdersView.Layer.BorderColor = UIColor.DarkGray.CGColor;
            BorderNoOrdersView.Layer.BorderWidth = 2;
            BorderNoOrdersView.Layer.CornerRadius = 8;
        }

        private void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            LoadOrders(TypeFilter);
            RefreshControl.EndRefreshing();
            BindOrders();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var checkStatus = NSUserDefaults.StandardUserDefaults.StringForKey("OrderStatus");

            if (checkStatus != null)
            {
                statusOrder = checkStatus;
            }

            var checkPeriod = NSUserDefaults.StandardUserDefaults.StringForKey("OrderPeriod");

            if (checkPeriod != null)
            {
                switch (checkPeriod)
                {
                    case "Últimos 10 días":
                        EndDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd" + " 23:59:59"));
                        InitDate = DateTime.Parse(EndDate.AddDays(-10).ToString("yyyy/MM/dd" + " 00:00:01"));
                        break;
                    case "Mes anterior":
                        int previusMonth = DateTime.Now.AddMonths(-1).Month;
                        int actualYear = DateTime.Now.Year;
                        int daysInMonth = DateTime.DaysInMonth(actualYear, previusMonth);

                        InitDate = new DateTime(actualYear, previusMonth, 1, 0, 0, 1);
                        EndDate = new DateTime(actualYear, previusMonth, daysInMonth, 23, 59, 59);
                        break;
                    case "Personalizado":
                        var fInitDate = NSUserDefaults.StandardUserDefaults.StringForKey("InitDate");
                        var fEndDate = NSUserDefaults.StandardUserDefaults.StringForKey("EndDate");

                        InitDate = DateTime.Parse(fInitDate + " 00:00:01");
                        EndDate = DateTime.Parse(fEndDate + " 23:59:59");
                        break;
                    default:
                        InitDate = new DateTime(1900, 1, 1);
                        EndDate = new DateTime(1900, 1, 1);
                        break;
                }
            }

            BindOrders();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            OrderNumber = SearchTextField.Text;
            BindOrders();
        }
            
        [Export("ShowSheetAlert:")]
        private void ShowSheetAlert(UIBarButtonItem sender)
        {
            var optionMenu = UIAlertController.Create(null, "Elegir Opción", UIAlertControllerStyle.ActionSheet);
            optionMenu.AddAction(UIAlertAction.Create("Solo mis órdenes", UIAlertActionStyle.Default,
                alert =>
                {
                    StartAnimation();
                    if (TypeFilter != FilterOrderType.ByDistributor)
                    {
                        TypeFilter = FilterOrderType.ByDistributor;
                        ClearFilters();

                        LoadOrders(TypeFilter);
                        BindOrders();
                        StopAnimation();
                    }
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Todas las órdenes", UIAlertActionStyle.Default,
                alert =>
                {
                    StartAnimation();
                    if (TypeFilter != FilterOrderType.ByCid)
                    {
                        TypeFilter = FilterOrderType.ByCid;
                        ClearFilters();

                        LoadOrders(TypeFilter);
                        BindOrders();
                        StopAnimation();
                    }
                }
            ));

            optionMenu.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel,
               alert =>
               {
                   Console.WriteLine("Todas las órdenes");
               }  
           ));

            PresentViewController(optionMenu, true, null);
        }

    

        void LoadOrders(FilterOrderType typeFilter)
        {
        
            ordReq = new Schemas.Services.OrderRequest();
            //Asignamos el token que tenemos en memoria
            ordReq.SessionInfo = new Schemas.Services.SessionInfoRequest()
            {
                TokenSession = AppSecurity.securityToken.SessionId
            };

            // Cargamos las ordenes con el Distribuidor ID
            if (typeFilter == FilterOrderType.ByDistributor)
            {
                ordReq.AllOrdersByCID = false;
            }
            else if (typeFilter == FilterOrderType.ByCid)
            {
                // Cargamos las ordenes con el CID
                ordReq.AllOrdersByCID = true;
            }

                var resultService = AppRuntime.MarketData.SearchOrders(ordReq, AppSecurity.securityToken.Token);

            AppSecurity.hasExpired(resultService.SessionInfoResponse,this);

                if (resultService.ServiceResponseStatus.IsSuccess)
                {
                    resultOrders = resultService.Orders;

                    if (resultOrders.ToList().Count == 0)
                    {
                        NoOrdersView.Hidden = false;
                    }
                    else
                    {
                        // *** LiteDB ***
                        // Insertamos las ordenes para que las consultas
                        // Mediante los filtros sean mas ágiles
                        var resultInsert = AppRuntime.MarketliteDB.InsertAllOrders(resultOrders.ToList());

                        if (resultInsert.IsSucess)
                        {
                            //BindOrders();
                            NoOrdersView.Hidden = true;
                        }
                    }
                }
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

        void BindOrders()
        {
           
                var resultList = AppRuntime.MarketliteDB.getOrders(OrderNumber, statusOrder, InitDate, EndDate);

                if (resultList.ToList().Count == 0)
                {
                    NoOrdersView.Hidden = false;
                }
                else
                {
                    NoOrdersView.Hidden = true;
                }

                OrdersCollectionViewSource ordersS = new OrdersCollectionViewSource(resultList, this);
                OrdersCollectionView.Source = ordersS;
                OrdersDelegateFlowLayout ordersDelegateFlowLayout = new OrdersDelegateFlowLayout(resultList, this);
                OrdersCollectionView.Delegate = ordersDelegateFlowLayout;
                OrdersCollectionView.ReloadData();

        }

        void ClearFilters()
        {
            OrderNumber = "";
            statusOrder = "";
            PeriodOrder = "";
            InitDate = new DateTime(1900, 1, 1);
            EndDate = new DateTime(1900, 1, 1);
        }
    }
}