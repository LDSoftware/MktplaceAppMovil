
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Constraints;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace Marketplace.App.Android.OrderFilter
{
    public class OrderFilterActivity : Fragment
    {
        RecyclerView typeRecicleView, periodRecicleView;
        OrderFilterAdapter mAdpater;
        TextView startDate, endDate;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Title = "Filtro";
            activitu.SupportActionBar.SetDisplayShowHomeEnabled(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.order_filter, container, false);
            typeRecicleView = view.FindViewById<RecyclerView>(Resource.Id.recycleViewTipo);
            periodRecicleView = view.FindViewById<RecyclerView>(Resource.Id.recycleViewPeriodo);

            var constraintLayoutInicial = view.FindViewById<ConstraintLayout>(Resource.Id.constraintLayoutInicial);
            var constraintLayoutFinal = view.FindViewById<ConstraintLayout>(Resource.Id.constraintLayoutFinal);
            startDate = view.FindViewById<TextView>(Resource.Id.startDateTextView);
            endDate = view.FindViewById<TextView>(Resource.Id.endDateTextView); 

            constraintLayoutInicial.Click += delegate
            {
                DateTime today = DateTime.Today;
                DatePickerDialog dateDialog = new DatePickerDialog(this.Activity, Resource.Style.CustomDatePickerTheme, OnDateSet, today.Year, today.Month - 1, today.Day);
                
                dateDialog.Show();

            };

            constraintLayoutFinal.Click += delegate
            {
                DateTime today = DateTime.Today;
                DatePickerDialog dateDialog = new DatePickerDialog(this.Activity, Resource.Style.CustomDatePickerTheme, OnDateSet, today.Year, today.Month - 1, today.Day);
                
                dateDialog.Show();
            };


            var tipo = new List<string>()
            {
                "Generada",
                "Atendida",
                "Facturación en proceso",
                "Facturada"
            };

            var periodo = new List<string>()
            {
                "Últimos 10 días",
                "Mes anterior",
                "Personalizado"
            };

            GridLayoutManager manager = new GridLayoutManager(this.Context, 1);
            typeRecicleView.SetLayoutManager(manager);

            mAdpater = new OrderFilterAdapter(tipo, this);
            mAdpater.ItemClick += MAdapter_ItemClick;
            typeRecicleView.SetAdapter(mAdpater);

            GridLayoutManager manager1 = new GridLayoutManager(this.Context, 1);
            periodRecicleView.SetLayoutManager(manager1);

            var mAdpater1 = new OrderFilterAdapter(periodo, this);
            mAdpater1.ItemClick += MAdapter_ItemClick;
            periodRecicleView.SetAdapter(mAdpater1);
            return view;
        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            Console.WriteLine("date " + e.Date);
            // FindViewById<EditText>(Resource.Id.date_EditText).Text = new DateTime(year, month, dayOfMonth).ToShortDateString();
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            /*  int categorieSelected = e + 1;
              OrderDetailActivity fragment = new OrderDetailActivity();
              this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "orderDetail").AddToBackStack(null).Commit();*/
        }
    }
}
