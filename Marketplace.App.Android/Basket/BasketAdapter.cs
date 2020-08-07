using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Marketplace.Schemas.Product;

namespace Marketplace.App.Android.Basket
{
    public class BasketAdapter : RecyclerView.Adapter
    {
        private List<ProductInfo> rows;
        public BasketAdapter()
        {
        }

        public BasketAdapter(List<ProductInfo> rows)
        {
            this.rows = rows;
        }

        public override int ItemCount
        {
            get { return rows.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductBasketViewHolder vh = holder as ProductBasketViewHolder;
            var Product = rows[position];
            vh.ProductDescriptionTextView.Text = Product.Name;
            vh.TotalProductTextView.Text = "$3333.33";
            vh.QuantityTextView.Text = "1";
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.basket_row, parent, false);
            ProductBasketViewHolder vh = new ProductBasketViewHolder(itemView);//, OnClick);
            return vh;
        }

        public class ProductBasketViewHolder : RecyclerView.ViewHolder
        {
            public ImageView ProductImageView { get; set; }
            public TextView ProductDescriptionTextView { get; set; }
            public TextView QuantityTextView { get; set; }
            public TextView TotalProductTextView { get; set; }

            [Obsolete]
            public ProductBasketViewHolder(View itemview) : base(itemview) //, Action<int> listener
            {
                ProductImageView = itemview.FindViewById<ImageView>(Resource.Id.ProductImageView);
                ProductDescriptionTextView = itemview.FindViewById<TextView>(Resource.Id.ProductDescriptionTextView);
                QuantityTextView = itemview.FindViewById<TextView>(Resource.Id.QuantityTextView);
                TotalProductTextView = itemview.FindViewById<TextView>(Resource.Id.TotalProductTextView);
                //itemview.Click += (sender, e) => listener(base.Position);
            }
        }
    }
}
