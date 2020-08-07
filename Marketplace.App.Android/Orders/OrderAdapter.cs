using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;


namespace Marketplace.App.Android.Orders
{
    public class OrderAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Dictionary<string, List<string>> Orders;
        private string[] keyOfDict;

        public OrderAdapter(Dictionary<string, List<string>> list)
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
            vh.statusTextView.Text = Orders[keyOfDict[position]][0];
            vh.dateTextView.Text = Orders[keyOfDict[position]][1];
            vh.totalTextView.Text = Orders[keyOfDict[position]][2];     
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.order_row, parent, false);
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
            public TextView statusTextView { get; set; }
            public TextView dateTextView { get; set; }
            public TextView totalTextView { get; set; }

            [Obsolete]
            public OrderViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                titleTextView = itemview.FindViewById<TextView>(Resource.Id.titleTextView);
                statusTextView = itemview.FindViewById<TextView>(Resource.Id.statusTextView);
                dateTextView = itemview.FindViewById<TextView>(Resource.Id.dateTextView);
                totalTextView = itemview.FindViewById<TextView>(Resource.Id.totalTextView);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}
