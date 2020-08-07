using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Marketplace.App.Android.InfoDir
{
    public class InfoDirAdapter : RecyclerView.Adapter  
    {
        private Dictionary<string, List<string>> oneData;
        private int v;
        public event EventHandler<int> ItemClick;

        public InfoDirAdapter(Dictionary<string, List<string>> oneData, int v)
        {
            this.oneData = oneData;
            this.v = v;
        }

        public override int ItemCount
        {
            get {
                if (v == 0)
                {
                    return oneData["oneTitle"].Count;
                }
                else
                {
                    return oneData["twoTitle"].Count;
                }
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            InfoDirViewHolder h = (InfoDirViewHolder)holder;
            foreach (var item in oneData)
            {
                if (item.Key == "oneTitle")
                {
                    h.titleTextView.Text = item.Value[position];
                }
                if (item.Key == "oneInfo")
                {
                    h.infoTextView.Text = item.Value[position];
                }

                if (item.Key == "twoTitle")
                {
                    h.titleTextView.Text = item.Value[position];
                }

                if (item.Key == "twoInfo")
                {
                    h.infoTextView.Text = item.Value[position];
                }
            }
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.info_dir_row, parent, false);
            InfoDirViewHolder vh = new InfoDirViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public class InfoDirViewHolder : RecyclerView.ViewHolder
        {
            public TextView titleTextView { get; set; }
            public TextView infoTextView { get; set; }
            [Obsolete]
            public InfoDirViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                titleTextView = itemview.FindViewById<TextView>(Resource.Id.titleTextView);
                infoTextView = itemview.FindViewById<TextView>(Resource.Id.infoTextView);
            }
        }
    }
}
