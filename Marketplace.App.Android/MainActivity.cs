using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Views;
using Marketplace.App.Android.Categories;
using Marketplace.App.Android.Busqueda;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.Widget;

namespace Marketplace.App.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/NoBarTitleTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        public Toolbar myToolbar;
        BottomNavigationView navigation;
        [System.Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.menu_container);
            navigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            /*navController.addOnDestinationChangedListener { _, destination, _ ->
   if(destination.id == R.id.full_screen_destination) {
      toolbar.visibility = View.GONE
      bottomNavigationView.visibility = View.GONE
   } else {
      toolbar.visibility = View.VISIBLE
      bottomNavigationView.visibility = View.VISIBLE
   }
}*/

            loadFragment(new CategoriesActivity());
            myToolbar = FindViewById<Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_bar_menu, menu);
            IMenuItem menuItem = menu.FindItem(Resource.Id.action_favorite);
            menuItem.SetVisible(false);
            return base.OnPrepareOptionsMenu(menu);
        }

        public void HideNavigation(bool hide)
        {
            if (hide)
            {
                navigation.Visibility = ViewStates.Gone;
            }
            else
            {
                navigation.Visibility = ViewStates.Visible;
            }
        }


        [System.Obsolete]
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            Fragment fragment = null;
            switch (item.ItemId)
            {
                case Resource.Id.action_productos:
                    fragment = new CategoriesActivity();
                    break;
                case Resource.Id.action_buscar:
                    fragment = new BusquedaActivity();
                    break;
                case Resource.Id.action_promociones:
                    break;
            }
            return loadFragment(fragment);
        }

        private bool loadFragment(Fragment fragment)
        {
            if (fragment != null)
            {
                SupportFragmentManager
                        .BeginTransaction()
                        .Replace(Resource.Id.main_container, fragment)
                        .Commit();
                return true;
            }
            return false;
        }

    }
}