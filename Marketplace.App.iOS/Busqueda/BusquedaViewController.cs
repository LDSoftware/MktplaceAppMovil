using Foundation;
using Marketplace.App.iOS.Common;
using Marketplace.App.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace Marketplace.App.iOS
{
    public partial class BusquedaViewController : UIViewController
    {
        List<Schemas.Search.SearchProductModel> listSearch;

        public BusquedaViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = true;
            ShowRecurringSearch();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Obtenemos los productos del servicio de busqueda
            var resultSearch = AppRuntime.MarketData.SearchProducts();

            if (resultSearch.ServiceResponseStatus.IsSuccess)
            {
                listSearch = resultSearch.SearchResult.ToList();
            }

            btnClearSearch.TouchUpInside -= ClickButtonDeleteSearch;
            btnClearSearch.TouchUpInside += ClickButtonDeleteSearch;

            SearchTextField.AddTarget(OpenSearchView, UIControlEvent.TouchDown);
        }

        public void ShowRecurringSearch()
        {
            // Obtenemos las busquedas recurrentes
            var result = AppRuntime.MarketliteDB.getRecurringSearches();

            BusquedaCollectionView.Source = new BusquedaSource(result);
            Busqueda.BusquedaDelegateFlowLayout DelegateFlowLayout = new Busqueda.BusquedaDelegateFlowLayout(result, this);
            BusquedaCollectionView.Delegate = DelegateFlowLayout;
            BusquedaCollectionView.ReloadData();
        }

        private void OpenSearchView(object sender, EventArgs e) {

            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            SearchViewController vcSearch = (SearchViewController)storyboard.InstantiateViewController("SearchViewController");
            vcSearch.listSearch = listSearch;
            vcSearch.comesFrom = ComesFrom.BySearch;
            this.NavigationController.PushViewController(vcSearch, true);
        }

        void ClickButtonDeleteSearch(object sender, EventArgs e)
        {
            var okCancelAlertController = UIAlertController.Create("Eliminar", "¿Deseas eliminar tu historial de búsqueda?", UIAlertControllerStyle.Alert);

            okCancelAlertController.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default,
                alert => {
                    AppRuntime.MarketliteDB.DeleteRecurringSearches();
                    ShowRecurringSearch();
                }
               ));
            okCancelAlertController.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel, null));

            PresentViewController(okCancelAlertController, true, null);
        }
    }
}