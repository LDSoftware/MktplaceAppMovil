using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using Marketplace.App.Runtime;
using System.Linq;
using Marketplace.App.iOS.Common;

namespace Marketplace.App.iOS
{
    public partial class SearchViewController : UIViewController
    {
        public List<Schemas.Search.SearchProductModel> listSearch { get; set; }
        public ComesFrom comesFrom { get; set; }

        public SearchViewController (IntPtr handle) : base (handle)
        {
           
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = true;
            txtFindProduct.BecomeFirstResponder();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnclosesearch.TouchUpInside += (sender, e) => {
                this.NavigationController.PopViewController(true);
            };

            txtFindProduct.AddTarget(ValueChanged, UIControlEvent.EditingChanged);
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            string searchValue = txtFindProduct.Text.Trim();
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

        void BindTable(List<Schemas.Search.SearchProductModel> locallistSearch) {
            SearchSource TableSource = new SearchSource(locallistSearch, this);

            ResultsSearchTableView.Source = TableSource;
            ResultsSearchTableView.ReloadData();
            ResultsSearchTableView.TableFooterView = new UIView();
        }
    }
}