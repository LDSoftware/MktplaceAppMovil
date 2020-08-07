using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Marketplace.App.Runtime;
using UIKit;
using Xamarin.Essentials;
using ObjCRuntime;
using Foundation;
using Marketplace.App.iOS.Common;

namespace Marketplace.App.iOS.Categories
{
    public partial class CategoriasViewController : UIViewController, IUITextFieldDelegate
    {
        List<Schemas.Search.SearchProductModel> listSearch;

        public CategoriasViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = true;
            this.Title = "Categorias";
            hideSearch();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            HandleButtons();

            var current = Connectivity.NetworkAccess;

            //Connection to internet is available
            if (current == NetworkAccess.Internet)
            {
                //Call runtime
                var resultCat = AppRuntime.MarketData.getCategories();
                if (resultCat.ServiceResponseStatus.IsSuccess)
                {
                    var listCategories = resultCat.CategoryInfo.Where(e => e.Image != null).ToList();

                    Categories.CatetoriesCollectionViewSource CollectionViewSource = new Categories.CatetoriesCollectionViewSource(listCategories, this);
                    CategoriasCollectionView.AllowsSelection = true;
                    CategoriasCollectionView.DataSource = CollectionViewSource;
                    Categories.CategoriesDelegateFlowLayout categoriesDelegateFlowLayout = new Categories.CategoriesDelegateFlowLayout(listCategories, this);
                    CategoriasCollectionView.Delegate = categoriesDelegateFlowLayout;
                    CategoriasCollectionView.ReloadData();
                }

                // Obtenemos los productos del servicio de busqueda
                var resultSearch = AppRuntime.MarketData.SearchProducts();

                if (resultSearch.ServiceResponseStatus.IsSuccess)
                {
                    listSearch = resultSearch.SearchResult.ToList();
                }

            }
        }

        
        private void HandleButtons()
        {
            UserButton.TouchUpInside += (sender, e) => {
                UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                AccountViewController vcInstance = (AccountViewController)storyboard.InstantiateViewController("AccountViewController");
                this.NavigationController.PushViewController(vcInstance, true);
            };

            CancelButton.TouchUpInside += (sender, e) => {
                hideSearch();
            };

            SearchTextField.WeakDelegate = this;

            SearchTextField.AddTarget(ValueChanged, UIControlEvent.EditingChanged);
        }

        void hideSearch() {
            SearchTextField.ResignFirstResponder();
            CanvelView.Hidden = true;
            OptionsView.Hidden = false;
            SearchTableView.Hidden = true;
            SearchTextField.Text = "";
        }

        [Export("textFieldDidBeginEditing:")]
        public void EditingStarted(UITextField textField)
        {
            if (textField == SearchTextField)
            {
                CanvelView.Hidden = false;
                OptionsView.Hidden = true;
                SearchTableView.Hidden = false;

                BindTable(AppRuntime.MarketliteDB.getRecurringSearches());
            }
            
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            string searchValue = SearchTextField.Text.Trim();
            List<Schemas.Search.SearchProductModel> locallistSearch;

            if (!string.IsNullOrEmpty(searchValue))
            {
                locallistSearch = listSearch.Where(i =>
                (i.ProductNameSearch.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                i.ProductName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).ToList();
            }
            else
            {
                locallistSearch = new List<Schemas.Search.SearchProductModel>();
            }

            BindTable(locallistSearch);
        }

        void BindTable(List<Schemas.Search.SearchProductModel> locallistSearch)
        {
            SearchSource TableSource = new SearchSource(locallistSearch, this);

            SearchTableView.Source = TableSource;
            SearchTableView.ReloadData();
            SearchTableView.TableFooterView = new UIView();
        }

    }
}

