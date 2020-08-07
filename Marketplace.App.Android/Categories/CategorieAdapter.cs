using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Marketplace.App.Android.Categories
{
    public class CategorieAdapter: RecyclerView.Adapter  
    {

        public event EventHandler<int> ItemClick;
        public List<string> Categories;

        public CategorieAdapter(List<string> list)
        {
            Categories = list;
        }

        public override int ItemCount
        {
            get { return Categories.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CategorieViewHolder vh = holder as CategorieViewHolder;
            vh.NameCategorie.Text = Categories[position];
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.categorie_row, parent, false);
            CategorieViewHolder vh = new CategorieViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public class CategorieViewHolder : RecyclerView.ViewHolder
        {
            public ImageView ImageCategorie { get; set; }
            public TextView NameCategorie { get; set; }

            [Obsolete]
            public CategorieViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                ImageCategorie = itemview.FindViewById<ImageView>(Resource.Id.ImageCategorie);
                NameCategorie = itemview.FindViewById<TextView>(Resource.Id.NameCategorie);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }


    }
}
