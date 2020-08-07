using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Marketplace.App.Android.OrderDetail
{
    public class OrderDetailAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Dictionary<string, List<string>> Orders;
        private string[] keyOfDict;

        public OrderDetailAdapter(Dictionary<string, List<string>> list)
        {
            Orders = list;
            this.keyOfDict = list.Keys.ToArray();
        }

        public override int ItemCount
        {
            get { return Orders.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            OrderViewHolder vh = holder as OrderViewHolder;
            vh.titleTextView.Text = Orders.Keys.ElementAt(position);
            vh.productsTextView.Text = Orders[keyOfDict[position]][0];
            vh.usersTextView.Text = Orders[keyOfDict[position]][1];
            vh.totalTextView.Text = Orders[keyOfDict[position]][2];
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.order_detail_row, parent, false);
            OrderViewHolder vh = new OrderViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public class OrderViewHolder : RecyclerView.ViewHolder
        {
            public TextView titleTextView { get; set; }
            public TextView productsTextView { get; set; }
            public TextView usersTextView { get; set; }
            public TextView totalTextView { get; set; }

            [Obsolete]
            public OrderViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                titleTextView = itemview.FindViewById<TextView>(Resource.Id.titleTextView);
                productsTextView = itemview.FindViewById<TextView>(Resource.Id.productsTextView);
                usersTextView = itemview.FindViewById<TextView>(Resource.Id.usersTextView);
                totalTextView = itemview.FindViewById<TextView>(Resource.Id.totalTextView);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }

    }
}
