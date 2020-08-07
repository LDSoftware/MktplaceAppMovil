using System;
using Android.Support.V7.Widget;
using Android.Views;
using Marketplace.Schemas.Order;
using System.Collections.Generic;
using System.Linq;
using Android.Widget;

namespace Marketplace.App.Android.OrderDetail
{
    public class CertificateAdapter : RecyclerView.Adapter
    {
        private OrderItemInfo detail;
        public event EventHandler<int> ItemClick;

        public CertificateAdapter(OrderItemInfo detail)
        {
            this.detail = detail;
        }

        public override int ItemCount
        {
            get { return detail.Licenses.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CertificateViewHolder vh = holder as CertificateViewHolder;
            vh.SerieTextView.Text = detail.Licenses[position].Serie;
            vh.LoteTextView.Text = detail.Licenses[position].Lote;
            vh.CertificateTextView.Text = detail.Licenses[position].UrlCertificate;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.certificate_row, parent, false);
            CertificateViewHolder vh = new CertificateViewHolder(itemView, OnClick);
            return vh;
        }

        public class CertificateViewHolder : RecyclerView.ViewHolder
        {
            public TextView SerieTextView { get; set; }
            public TextView LoteTextView { get; set; }
            public TextView CertificateTextView { get; set; }

            [Obsolete]
            public CertificateViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                SerieTextView = itemview.FindViewById<TextView>(Resource.Id.SerieTextView);
                LoteTextView = itemview.FindViewById<TextView>(Resource.Id.LoteTextView);
                CertificateTextView = itemview.FindViewById<TextView>(Resource.Id.CertificateTextView);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}
