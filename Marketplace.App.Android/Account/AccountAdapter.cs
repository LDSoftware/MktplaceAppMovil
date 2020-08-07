using System;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Marketplace.App.Android.Login;

namespace Marketplace.App.Android.Account
{
    public class AccountAdapter : RecyclerView.Adapter
    {
        private List<SectionOrRow> mData;
        private AccountActivity accountActivity;

        public event EventHandler<int> ItemClick;

        public AccountAdapter(List<SectionOrRow> data)
        {
            mData = data;
        }

        public AccountAdapter(List<SectionOrRow> data, AccountActivity accountActivity) : this(data)
        {
            this.accountActivity = accountActivity;
        }

        public override int ItemCount
        {
            get { return mData.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SectionOrRow item = mData[position];
            if (item.IsRow())
            {
                if(item.IsLogin() && item.IsRow())
                {
                    RowLoginViewHolder h = (RowLoginViewHolder)holder;
                    h.usernameTextView.Text = item.getUserData()[0];
                    h.emailTextView.Text = item.getUserData()[1];
                    h.creditTextView.Text = item.getUserData()[2];
                    h.pendingTextView.Text = item.getUserData()[3];
                    h.balanceTextView.Text = item.getUserData()[4];
                }
                else if (item.IsLogout() && item.IsRow())
                {
                    RowLogoutViewHolder h = (RowLogoutViewHolder)holder;
                    h.loginButton.Click += delegate
                    {
                        LoginActivity fragment = new LoginActivity();
                        accountActivity.FragmentManager.BeginTransaction().Replace(Resource.Id.main_container, fragment, "login").AddToBackStack(null).Commit();
                    };
                }
                else
                {
                    RowViewHolder h = (RowViewHolder)holder;
                    h.textView.Text = item.getRow();
                }
                
            }
            else
            {
                SectionViewHolder h = (SectionViewHolder)holder;
                h.textView.Text = item.getSection();
            }
        }

        [Obsolete]
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == 0)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.account_section_row, parent, false);
                SectionViewHolder vh = new SectionViewHolder(itemView, OnClick);
                return vh;
            }
            else if (viewType == 1)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.account_section_about_row, parent, false);
                RowViewHolder vh = new RowViewHolder(itemView, OnClick);
                return vh;
            }
            else if (viewType == 2)
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.account_login_row, parent, false);
                RowLoginViewHolder vh = new RowLoginViewHolder(itemView, OnClick);
                return vh;
            }
            else
            {
                View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.account_logout_row, parent, false);
                RowLogoutViewHolder vh = new RowLogoutViewHolder(itemView, OnClick);
                return vh;
            }
        }

        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }

        public class SectionViewHolder : RecyclerView.ViewHolder
        {
            public TextView textView;

            [Obsolete]
            public SectionViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                textView = itemview.FindViewById<TextView>(Resource.Id.SectionTitleTextView);
            }
        }

        public class RowViewHolder : RecyclerView.ViewHolder
        {
            public TextView textView;

            [Obsolete]
            public RowViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                textView = itemview.FindViewById<TextView>(Resource.Id.OptionTextView);
                itemview.Click += (sender, e) => listener(base.Position);
            }
        }

        public class RowLoginViewHolder : RecyclerView.ViewHolder
        {
            public TextView usernameTextView;
            public TextView emailTextView;
            public TextView creditTextView;
            public TextView pendingTextView;
            public TextView balanceTextView;

            [Obsolete]
            public RowLoginViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                usernameTextView = itemview.FindViewById<TextView>(Resource.Id.usernameTextView);
                emailTextView = itemview.FindViewById<TextView>(Resource.Id.emailTextView);
                creditTextView = itemview.FindViewById<TextView>(Resource.Id.creditTextView);
                pendingTextView = itemview.FindViewById<TextView>(Resource.Id.pendingTextView);
                balanceTextView = itemview.FindViewById<TextView>(Resource.Id.balanceTextView);
            }
        }

        public class RowLogoutViewHolder : RecyclerView.ViewHolder
        {
            public Button loginButton;

            [Obsolete]
            public RowLogoutViewHolder(View itemview, Action<int> listener) : base(itemview)
            {
                loginButton = itemview.FindViewById<Button>(Resource.Id.loginButton);
            }
        }

        public override int GetItemViewType(int position)
        {
            base.GetItemViewType(position);
            SectionOrRow item = mData[position];
            if (!item.IsRow())
            {
                return 0;
            }
            else
            {
                if (item.IsLogin() && item.IsRow())
                {
                    return 2;
                }
                else if (item.IsLogout() && item.IsRow())
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
                
            }
            
        }
    }
}
