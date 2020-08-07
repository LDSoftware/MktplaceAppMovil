using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Marketplace.App.Android.Busqueda
{
    public class RecentSearchAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<string> Productos;

        public override int ItemCount
        {
            get { return Productos.Count; }
        }

        public RecentSearchAdapter(List<string> list)
        {
            Productos = list;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecentSearchViewHolder vh = holder as RecentSearchViewHolder;
            vh.nameProduct.Text = Productos[position];
            vh.imageProduct.SetImageResource(Resource.Drawable.Isotipo_Bancos);
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.busqueda_row, parent, false);
            RecentSearchViewHolder vh = new RecentSearchViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }


        public class RecentSearchViewHolder : RecyclerView.ViewHolder
        {
            public ImageView imageProduct { get; set; }
            public TextView nameProduct { get; set; }

            [Obsolete]
            public RecentSearchViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                imageProduct = itemview.FindViewById<ImageView>(Resource.Id.ImageProduct);
                nameProduct = itemview.FindViewById<TextView>(Resource.Id.NameProduct);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}
