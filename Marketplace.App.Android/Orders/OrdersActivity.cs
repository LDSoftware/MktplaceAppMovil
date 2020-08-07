
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
using Android.Util;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Fragment = Android.Support.V4.App.Fragment;
using Marketplace.App.Android.OrderFilter;
using Marketplace.App.Android.OrderDetail;

namespace Marketplace.App.Android.Orders
{
    public class OrdersActivity : Fragment
    {
        EditText searchEditText;
        RecyclerView ordersRecicleView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Title = "Ordenes";
            activitu.SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_show:
                    AlertDialog.Builder builder = new AlertDialog.Builder(Context, Resource.Style.CustomDialogTheme);
                    builder.SetTitle("Seleccione la opción");
                    builder.SetCancelable(true);

                    string[] values = { "Solo mis órdenes", "Todas las órdenes" };
                    int checkedItem = 0;
                    builder.SetSingleChoiceItems(values, checkedItem, (c, ev) =>
                    {
                        switch (c)
                        {
                            case 0:
                                Console.WriteLine("just mine");
                                break;
                            case 1:
                                Console.WriteLine("all");
                                break;
                        }
                    });
                    builder.SetPositiveButton("confirmar", (c, ev) =>
                    {
                    });

                    builder.SetNegativeButton("cancelar", (c, ev) =>
                    {
                    });
                    AlertDialog alert = builder.Create();
                    alert.Show();
            return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnPrepareOptionsMenu(IMenu menu)
        {
            IMenuItem itemShow = menu.FindItem(Resource.Id.action_show);
            if(itemShow != null)
            {
                itemShow.SetVisible(true);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.orders, container, false);
            searchEditText = view.FindViewById<EditText>(Resource.Id.searchEditText);
            ordersRecicleView = view.FindViewById<RecyclerView>(Resource.Id.recycleViewOrdenes);
            var filtrarTextView = view.FindViewById<TextView>(Resource.Id.textView);

            Dictionary<string, List<string>> orders = new Dictionary<string, List<string>>();
            orders.Add("No. de Orden: 4000684",
                new List<string>
                {
                    "Generada",
                    "23/03/2020",
                    "$57,564.33"
                });
            orders.Add("No. de Orden: 4000683",
                new List<string>
                {
                    "Facturada",
                    "04/10/2020",
                    "$4,564.33"
                });
            orders.Add("No. de Orden: 4000682",
                new List<string>
                {
                    "Generada",
                    "23/03/2020",
                    "$57,564.33"
                });
            orders.Add("No. de Orden: 4000681",
                new List<string>
                {
                    "Facturada",
                    "23/03/2020",
                    "$57,564.33"
                });

            GridLayoutManager manager = new GridLayoutManager(this.Context, 2);
            ordersRecicleView.SetLayoutManager(manager);

            OrderAdapter mAdapterOrders = new OrderAdapter(orders);
            mAdapterOrders.ItemClick += MAdapter_ItemClick;
            ordersRecicleView.SetAdapter(mAdapterOrders);


            filtrarTextView.Click += delegate
            {
                OrderFilterActivity fragment = new OrderFilterActivity();
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "filter").AddToBackStack(null).Commit();
            };

            return view;
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int orderSelected = e + 1;
            OrderDetailActivity fragment = new OrderDetailActivity();
            this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "orderDetail").AddToBackStack(null).Commit();
        }
    }
}
