
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace Marketplace.App.Android.ProductDetail
{
    [Activity(Label = "ProductDetail")]
    [Obsolete]
    public class ProductDetailActivity : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.product_detail, container, false);
            Console.WriteLine("inside");
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            HasOptionsMenu = true;
        }

        public override void OnPrepareOptionsMenu(IMenu menu)
        {
            IMenuItem itemShare = menu.FindItem(Resource.Id.action_share);
            if (itemShare != null)
            {
                itemShare.SetVisible(true);
            }
            IMenuItem itemFav = menu.FindItem(Resource.Id.action_favorite);
            if (itemFav != null)
            {
                itemFav.SetVisible(true);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_share:
                    Console.WriteLine("share ");
                    return true;
                case Resource.Id.action_favorite:
                    Console.WriteLine("favorite");
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Title = "Bancos";
            activitu.SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

    }
}
