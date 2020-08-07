
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace Marketplace.App.Android.OrderDetail
{
    public class OrderDetailActivity : Fragment
    {
        TextView KeyOneTextView, KeyTwoTextView, KeyThreeTextView;
        TextView ValueOneTextView, ValueTwoTextView, ValueThreeTextView;
        RecyclerView OrderDetailRecyclerView;
        TextView SubTotalTextView, TaxesTextView, TotalTextView;
        ConstraintLayout InvoiceContraintLayout, PdfContraintLayout;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.order_detail, container, false);
            var tabLayout = view.FindViewById<TabLayout>(Resource.Id.tabLayout);
            KeyOneTextView = view.FindViewById<TextView>(Resource.Id.KeyOneTextView);
            KeyTwoTextView = view.FindViewById<TextView>(Resource.Id.KeyTwoTextView);
            KeyThreeTextView = view.FindViewById<TextView>(Resource.Id.KeyThreeTextView);
            ValueOneTextView = view.FindViewById<TextView>(Resource.Id.ValueOneTextView);
            ValueTwoTextView = view.FindViewById<TextView>(Resource.Id.ValueTwoTextView);
            ValueThreeTextView = view.FindViewById<TextView>(Resource.Id.ValueThreeTextView);
            OrderDetailRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.OrderDetailRecyclerView);

            SubTotalTextView = view.FindViewById<TextView>(Resource.Id.SubTotalTextView);
            TaxesTextView = view.FindViewById<TextView>(Resource.Id.TaxesTextView);
            TotalTextView = view.FindViewById<TextView>(Resource.Id.TotalTextView);

            InvoiceContraintLayout = view.FindViewById<ConstraintLayout>(Resource.Id.InvoiceContraintLayout);
            PdfContraintLayout = view.FindViewById<ConstraintLayout>(Resource.Id.PdfContraintLayout);


            loadFirstSegment();
            SubTotalTextView.Text = "$45,251.37";
            TaxesTextView.Text = "$8,619.30";
            TotalTextView.Text = "$53,870.67";

            fillOrders();
            tabLayout.TabSelected += (object sender, TabLayout.TabSelectedEventArgs e) =>
            {
                var tab = e.Tab;
                switch (tab.Position)
                {
                    case 0:
                        loadFirstSegment();
                        break;
                    case 1:
                        KeyOneTextView.Text = "Cliente";
                        KeyTwoTextView.Text = "Correo electrónico";
                        KeyThreeTextView.Text = "Teléfono";
                        ValueOneTextView.Text = "Sergio Zorrilla";
                        ValueTwoTextView.Text = "email@email.com";
                        ValueThreeTextView.Text = "8183003087";
                        break;
                    case 2:
                        KeyOneTextView.Text = "RFC";
                        KeyTwoTextView.Text = "Cliente";
                        KeyThreeTextView.Text = "Dirección";
                        ValueOneTextView.Text = "ZOAS9010224j42";
                        ValueTwoTextView.Text = "Neodata";
                        ValueThreeTextView.Text = "Av Felix bañuelos 9384-17";
                        break;
                    case 3:
                        KeyOneTextView.Text = "Método de pago";
                        KeyTwoTextView.Text = "Estado de pago";
                        KeyThreeTextView.Text = "";
                        ValueOneTextView.Text = "Tarjeta";
                        ValueTwoTextView.Text = "En transito";
                        ValueThreeTextView.Text = "";
                        break;
                }
            };
            return view;
        }

        private void loadFirstSegment()
        {
            KeyOneTextView.Text = "Estado de la orden";
            KeyTwoTextView.Text = "Fecha";
            KeyThreeTextView.Text = "Total";
            ValueOneTextView.Text = "Procesada";
            ValueTwoTextView.Text = "26/10/2020";
            ValueThreeTextView.Text = "$53,870.67";
        }

        private void fillOrders()
        {
            Dictionary<string, List<string>> orders = new Dictionary<string, List<string>>();
            orders.Add("CompaQi Bancos",
                new List<string>
                {
                    "1",
                    "5",
                    "$57,564.33"
                });
            orders.Add("Comercial Premium",
                new List<string>
                {
                    "1",
                    "2",
                    "$4,564.33"
                });

            GridLayoutManager manager = new GridLayoutManager(this.Context, 2);
            OrderDetailRecyclerView.SetLayoutManager(manager);

            OrderDetailAdapter mAdapterOrders = new OrderDetailAdapter(orders);
            mAdapterOrders.ItemClick += MAdapter_ItemClick;
            OrderDetailRecyclerView.SetAdapter(mAdapterOrders);

        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int orderSelected = e + 1;
            CertificateActivity fragment = new CertificateActivity();
            this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "order_certificates").AddToBackStack(null).Commit();
            
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (MainActivity)Activity;
            activitu.Title = "Orden 333";
            activitu.HideNavigation(true);
        }

        public override void OnPause()
        {
            base.OnPause();
            var activitu = (MainActivity)Activity;
            activitu.HideNavigation(false);
        }
    }
}
