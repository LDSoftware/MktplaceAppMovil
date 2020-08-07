using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Marketplace.App.Android.Products
{
    public class ProductAdapter : RecyclerView.Adapter
    {

        public event EventHandler<int> ItemClick;
        public List<string> Productos;

        public ProductAdapter(List<string> list)
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
            vh.NameProduct.Text = Productos[position];
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.product_row, parent, false);
            ProductViewHolder vh = new ProductViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public class ProductViewHolder : RecyclerView.ViewHolder
        {
            public TextView NameProduct { get; set; }

            [Obsolete]
            public ProductViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                NameProduct = itemview.FindViewById<TextView>(Resource.Id.NameProduct);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}
