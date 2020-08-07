
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace Marketplace.App.Android.Login
{
    public class LoginActivity : Fragment
    {
        Button loginButton;
        EditText usernameEditText;
        EditText pwdEditText;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        [Obsolete]
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.login, container, false);
            loginButton = view.FindViewById<Button>(Resource.Id.loginButton);
            usernameEditText = view.FindViewById<EditText>(Resource.Id.usernameEditText);
            pwdEditText = view.FindViewById<EditText>(Resource.Id.pwdEditText);
            loginButton.Click += delegate
            {
                if(usernameEditText.Text != "" && pwdEditText.Text != "")
                {
                    usernameEditText.SetBackgroundDrawable(this.Context.GetDrawable(Resource.Drawable.rounder_corner_login));
                    pwdEditText.SetBackgroundDrawable(this.Context.GetDrawable(Resource.Drawable.rounder_corner_login));
                }
                else
                {
                    usernameEditText.SetBackgroundDrawable(this.Context.GetDrawable(Resource.Drawable.rounder_corner_login_red));
                    pwdEditText.SetBackgroundDrawable(this.Context.GetDrawable(Resource.Drawable.rounder_corner_login_red));
                }

            };
            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
            var activitu = (AppCompatActivity)Activity;
            activitu.SupportActionBar.Title = "Login";
            activitu.SupportActionBar.SetDisplayShowHomeEnabled(true);
        }
    }
}
