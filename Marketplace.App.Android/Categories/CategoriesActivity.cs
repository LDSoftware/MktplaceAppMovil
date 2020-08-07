
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Runtime;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.Widget;
using Marketplace.App.Android.Products;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Content;
using Marketplace.App.Android.Busqueda;
using Fragment = Android.Support.V4.App.Fragment;
using Marketplace.App.Android.Login;
using Marketplace.App.Android.Account;
using Marketplace.App.Android.Basket;

namespace Marketplace.App.Android.Categories
{
    [Activity(Label = "CategoriesActivity")]
    [Obsolete]
    public class CategoriesActivity : Fragment
    {

        CategorieAdapter mAdapterCategories;
        BusquedaAdapter mAdapterBusqueda;
        EditText searchEditText;
        RecyclerView categoriesRecicleView;
        RecyclerView listSearchRecycleView;
        List<string> searchList;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.categories, container, false);
            InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
            categoriesRecicleView = view.FindViewById<RecyclerView>(Resource.Id.categoriesRecicleView);
            searchEditText = view.FindViewById<EditText>(Resource.Id.searchEditText);
            var cancelButton = view.FindViewById<Button>(Resource.Id.cancelButton);
            var accountButton = view.FindViewById<ImageButton>(Resource.Id.accountButton);
            listSearchRecycleView = view.FindViewById<RecyclerView>(Resource.Id.listSearchRecycleView);
            var basketButton = view.FindViewById<ImageButton>(Resource.Id.imageButton);
            fillCategories();
            fillSearch();

            searchEditText.SetFocusable(ViewFocusability.NotFocusable);

            searchEditText.AfterTextChanged += (sender, args) =>
            {
                if(!args.Equals(""))
                {
                   filter(args.ToString());
                }
            };

            searchEditText.Click += delegate
             {
                 searchEditText.SetFocusable(ViewFocusability.Focusable);
                 cancelButton.Visibility = ViewStates.Visible;
                 listSearchRecycleView.Visibility = ViewStates.Visible;
                 imm.ToggleSoftInput(InputMethodManager.ShowForced, 0);
             };
            cancelButton.Click += delegate
            {
                searchEditText.SetFocusable(ViewFocusability.Focusable);
                cancelButton.Visibility = ViewStates.Invisible;
                searchEditText.Text = "";
                view.ClearFocus();
                imm.HideSoftInputFromWindow(searchEditText.WindowToken, 0);
                listSearchRecycleView.Visibility = ViewStates.Invisible;
               
            };

            accountButton.Click += delegate
            {
                AccountActivity fragment = new AccountActivity();
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "account").AddToBackStack(null).Commit();
                listSearchRecycleView.Visibility = ViewStates.Invisible;
            };

            basketButton.Click += delegate
            {
                BasketActivity fragment = new BasketActivity();
                this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "basket").AddToBackStack(null).Commit();
                listSearchRecycleView.Visibility = ViewStates.Invisible;
            };


            return view;
        }

        private void fillCategories()
        {
            var list = new List<string>();

            list.Add("CONTABLES");
            list.Add("COMERCIALES");
            list.Add("PRODUCTIVIDAD");
            list.Add("NUBE");
            GridLayoutManager manager = new GridLayoutManager(this.Context, 2);
            categoriesRecicleView.SetLayoutManager(manager);

            mAdapterCategories = new CategorieAdapter(list);
            mAdapterCategories.ItemClick += MAdapter_ItemClick;
            categoriesRecicleView.SetAdapter(mAdapterCategories);
        }

        private void fillSearch()
        {
            searchList = new List<string>();
            searchList.Add("Producto 1");
            searchList.Add("Producto 2");
            searchList.Add("Producto 3");

            GridLayoutManager managerB = new GridLayoutManager(this.Context, 1);
            listSearchRecycleView.SetLayoutManager(managerB);
            mAdapterBusqueda = new BusquedaAdapter(searchList);
            listSearchRecycleView.SetAdapter(mAdapterBusqueda);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int categorieSelected = e + 1;
            ProductsActivity fragment = new ProductsActivity();
            this.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "products").AddToBackStack(null).Commit();
            listSearchRecycleView.Visibility = ViewStates.Invisible;
        }

        private void filter(String text)
        {
            List<string> filteredList = new List<string>();
            foreach (var item in searchList)
            {
                filteredList.Add(item);
            }
            mAdapterBusqueda.filterList(filteredList);
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Hide();
            activitu.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            this.Activity.Window.SetSoftInputMode(SoftInput.AdjustNothing);
        }

        public override void OnPause()
        {
            base.OnPause();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Show();
        }
    }
}
