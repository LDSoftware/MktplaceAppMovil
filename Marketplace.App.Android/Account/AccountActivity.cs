
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Marketplace.App.Android.InfoDir;
using Marketplace.App.Android.Orders;

namespace Marketplace.App.Android.Account
{
    public class AccountActivity : Fragment
    {
        RecyclerView accountRecycleView;
        private List<SectionOrRow> mData;
        AccountAdapter mAdapterAccount;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Title = "Cuenta";
            activitu.SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.account, container, false);
            accountRecycleView = view.FindViewById<RecyclerView>(Resource.Id.AccountRecycleView);

            var list = new List<SectionOrRow>();
            list.Add(SectionOrRow.createSection("Cuenta"));
            list.Add(SectionOrRow.createSection("Logout"));
            list.Add(SectionOrRow.createRowLogout(""));
            list.Add(SectionOrRow.createSection("Login"));
            var userList = new List<string>();
            userList.Add("Distribuidor 12345");
            userList.Add("correodistribuidor@email.com");
            userList.Add("$3,333,333.00");
            userList.Add("$3,333,331.00");
            userList.Add("$3,333,332.00");
            list.Add(SectionOrRow.createRowLogin(userList));
            list.Add(SectionOrRow.createRow("Producto Favoritos"));
            list.Add(SectionOrRow.createRow("Información del cliente"));
            list.Add(SectionOrRow.createRow("Direcciones"));
            list.Add(SectionOrRow.createRow("Órdenes"));
            list.Add(SectionOrRow.createRow("Cerrar sesión"));
            list.Add(SectionOrRow.createSection("Acerca de"));
            list.Add(SectionOrRow.createRow("Versión 1.0"));
            list.Add(SectionOrRow.createRow("Aviso de privacidad"));
            list.Add(SectionOrRow.createRow("Nosotros"));
            list.Add(SectionOrRow.createRow("Contáctanos al 800 317 1111"));

            GridLayoutManager manager = new GridLayoutManager(this.Context, 1);
            accountRecycleView.SetLayoutManager(manager);
            mAdapterAccount = new AccountAdapter(list, this);
            mAdapterAccount.ItemClick += MAdapter_ItemClick;
            accountRecycleView.SetAdapter(mAdapterAccount);

            return view;
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int optionSelected = e + 1;
            Console.WriteLine("some important thing -> " + optionSelected);
            if (optionSelected == 7)
            {
                InfoDirActivity fragment = new InfoDirActivity(0);
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "infoDir").AddToBackStack(null).Commit();
            }

            if (optionSelected == 8)
            {
                InfoDirActivity fragment = new InfoDirActivity(1);
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "infoDir").AddToBackStack(null).Commit();
            }

            if (optionSelected == 9)
            {
                OrdersActivity fragment = new OrdersActivity();
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "orders").AddToBackStack(null).Commit();
            }

        }
    }
}
