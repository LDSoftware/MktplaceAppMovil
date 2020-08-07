
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

namespace Marketplace.App.Android.Basket
{
    [Activity(Label = "BasketActivity")]
    public class BasketActivity : Fragment
    {
        List<Schemas.Product.ProductInfo> rows { get; set; }
        BasketAdapter mAdapter;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.basket, container, false);
            var productsRecycleView = view.FindViewById<RecyclerView>(Resource.Id.ProductsRecyclerView);

            productsRecycleView.AddItemDecoration(new DividerItemDecoration(this.Context, DividerItemDecoration.Vertical));

            rows = new List<Schemas.Product.ProductInfo>();
            var product = new Schemas.Product.ProductInfo();
            product.Id = 1;
            product.Name = "CONTPAQI® XML EN LÍNEA +, MULTIEMPRESA, LICENCIA ANUAL 100 USUARIO(S) - PAQUETE(PLXLMUL)";
            rows.Add(product);
            var product1 = new Schemas.Product.ProductInfo();
            product1.Id = 2;
            product1.Name = "CONTPAQI® BANCOS, MULTIEMPRESA, LICENCIA ANUAL 3 USUARIO(S) - RENOVACIÓN(ALBANLA)";
            rows.Add(product1);

            GridLayoutManager manager = new GridLayoutManager(this.Context, 1);
            productsRecycleView.SetLayoutManager(manager);

            mAdapter = new BasketAdapter(rows);
            productsRecycleView.SetAdapter(mAdapter);
            HasOptionsMenu = false;
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Hide();
            activitu.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.Activity.Window.SetSoftInputMode(SoftInput.AdjustNothing);
        }
    }
}
