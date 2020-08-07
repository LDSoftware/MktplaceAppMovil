using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;


namespace Marketplace.App.Android.Busqueda
{
    public class BusquedaAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<string> Productos;

        public BusquedaAdapter(List<string> list)
        {
            Productos = list;
        }

        public override int ItemCount
        {
            get { return Productos.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductViewHolder vh = holder as ProductViewHolder;
            vh.nameProductTextView.Text = Productos[position];
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.search_row, parent, false);
            ProductViewHolder vh = new ProductViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public void filterList(List<string> filteredList)
        {
            Productos = filteredList;
            NotifyDataSetChanged();
        }

        public class ProductViewHolder : RecyclerView.ViewHolder
        {
            public TextView nameProductTextView { get; set; }

            [Obsolete]
            public ProductViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                nameProductTextView = itemview.FindViewById<TextView>(Resource.Id.nameProductTextView);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}
