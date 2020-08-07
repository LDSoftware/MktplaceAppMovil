
using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Marketplace.App.Android.ProductDetail;

namespace Marketplace.App.Android.Products
{
    [Activity(Label = "ProductsActivity")]
    [Obsolete]
    public class ProductsActivity : Fragment
    {
        ProductAdapter mAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.products, container, false);
            var productsRecycleView = view.FindViewById<RecyclerView>(Resource.Id.ProductsRecycleView);

            productsRecycleView.AddItemDecoration(new DividerItemDecoration(this.Context, DividerItemDecoration.Vertical));

            var list = new List<string>();

            list.Add("CONTABLES");
            list.Add("COMERCIALES");
            list.Add("PRODUCTIVIDAD");
            list.Add("NUBE");

            GridLayoutManager manager = new GridLayoutManager(this.Context, 1);
            productsRecycleView.SetLayoutManager(manager);

            mAdapter = new ProductAdapter(list);
            mAdapter.ItemClick += MAdapter_ItemClick;
            productsRecycleView.SetAdapter(mAdapter);
            HasOptionsMenu = false;
            return view;
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int categorieSelected = e + 1;
            ProductDetailActivity fragment = new ProductDetailActivity();
            this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "productDetail").AddToBackStack(null).Commit();
            
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Title = "Contables";
            activitu.SupportActionBar.SetDisplayShowHomeEnabled(true);
        }


    }
}
