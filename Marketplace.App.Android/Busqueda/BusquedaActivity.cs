
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Marketplace.App.Android.ProductDetail;

namespace Marketplace.App.Android.Busqueda
{
    [Activity(Label = "BusquedaActivity")]
    [Obsolete]
    public class BusquedaActivity : Fragment
    {
        RecentSearchAdapter recentSearchAdapte;
        RecyclerView recentSearchRV;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.busqueda, container, false);
            recentSearchRV = view.FindViewById<RecyclerView>(Resource.Id.recentSearchRV);
            FillProducts();
            //
            return view;
        }

        private void FillProducts()
        {
            var list = new List<string>();

            list.Add("CONTPAQI® EVALÚA035");
            list.Add("CONTPAQI® CFDi Facturación En Línea +");
            list.Add("CONTPAQI® XML En Línea + ");
            list.Add("CONTPAQI® EVALÚA035");
            list.Add("CONTPAQI® CFDi Facturación En Línea +");
            list.Add("CONTPAQI® XML En Línea + ");
            GridLayoutManager manager = new GridLayoutManager(this.Context, 3);
            recentSearchRV.SetLayoutManager(manager);

            recentSearchAdapte = new RecentSearchAdapter(list);
            recentSearchAdapte.ItemClick += MAdapter_ItemClick;
            recentSearchRV.SetAdapter(recentSearchAdapte);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int categorieSelected = e + 1;
            ProductDetailActivity fragment = new ProductDetailActivity();
            this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "products_detail").AddToBackStack(null).Commit();
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Hide();
            activitu.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

        }

        public override void OnPause()
        {
            base.OnPause();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Show();
        }
    }
}
