
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Marketplace.Schemas.Order;

namespace Marketplace.App.Android.OrderDetail
{
    public class CertificateActivity : Fragment
    {
        RecyclerView CertificatesRecyclerView;
        public OrderItemInfo detail { get; set; }
        MainActivity activity;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        [Obsolete]
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.certificates, container, false);
            var TitleTextView = view.FindViewById<TextView>(Resource.Id.TitleTextView);
            TitleTextView.Text = "CONTPAQI® 500 TIMBRES - PAQUETE(PDTIM500)";
            CertificatesRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.CertificatesRecyclerView);
            var closeImageView = view.FindViewById<ImageView>(Resource.Id.closeImageView);

            closeImageView.Click += delegate
            {
               // this.FragmentManager.BeginTransaction().Remove(this).Commit();
                activity.OnBackPressed();
            };

            

            detail = new OrderItemInfo();
            detail.ProductName = "";
            detail.Sku = "";
            detail.Quantity = 3;
            detail.UnitPrice = 0;
            detail.Total = 3333;

            var item = new OrderItemLicenseInfo();
            item.Serie = "29DC0B941FD0D173";
            item.Lote = "190313-01-0001";
            item.UrlCertificate = "Certificado";
            detail.Licenses.Add(item);

            GridLayoutManager manager = new GridLayoutManager(this.Context, 1);
            CertificatesRecyclerView.SetLayoutManager(manager);

            CertificateAdapter mAdapterCertificates = new CertificateAdapter(detail);
            mAdapterCertificates.ItemClick += MAdapter_ItemClick;
            CertificatesRecyclerView.SetAdapter(mAdapterCertificates);

            return view;
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (MainActivity)Activity;
            activitu.HideNavigation(true);
            activitu.SupportActionBar.Hide();
            activity = activitu;
            activitu.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.Activity.Window.SetSoftInputMode(SoftInput.AdjustNothing);
        }

        public override void OnPause()
        {
            base.OnPause();
            var activitu = (MainActivity)Activity;
            activitu.HideNavigation(false);
            activitu.SupportActionBar.Show();
        }
    }
}
