using System;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Marketplace.App.Android.OrderFilter
{
    public class OrderFilterAdapter : RecyclerView.Adapter
    {
        private List<string> mData;
        public event EventHandler<int> ItemClick;
        private OrderFilterActivity orderFilterActivity;

        public OrderFilterAdapter(List<string> data)
        {
            mData = data;
        }

        public OrderFilterAdapter(List<string> data, OrderFilterActivity orderFilterActivity) : this(data)
        {
            this.orderFilterActivity = orderFilterActivity;
        }

        public override int ItemCount
        {
            get { return mData.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            OptionsViewHolder vh = holder as OptionsViewHolder;
            RadioButton rb = new RadioButton(orderFilterActivity.Context);
            rb.SetText(mData[position], null);
            vh.optionsGroup.AddView(rb);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.order_filter_type, parent, false);
            OptionsViewHolder vh = new OptionsViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public class OptionsViewHolder : RecyclerView.ViewHolder
        {
            public RadioGroup optionsGroup;

            [Obsolete]
            public OptionsViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                optionsGroup = itemview.FindViewById<RadioGroup>(Resource.Id.optionsRadioGroup);
            }
        }
    }
}
