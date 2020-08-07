
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace Marketplace.App.Android.InfoDir
{
    public class InfoDirActivity : Fragment
    {

        private RecyclerView OneRecycleView;
        private RecyclerView TwoRecycleView;
        private InfoDirAdapter infoDirAdapter;
        private int v;

        public InfoDirActivity(int v)
        {
            this.v = v;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.info_dir, container, false);
            var OneTextView = view.FindViewById<TextView>(Resource.Id.OneTextView);
            OneRecycleView = view.FindViewById<RecyclerView>(Resource.Id.OneRecycleView);
            var TwoTextView = view.FindViewById<TextView>(Resource.Id.TwoTextView);
            TwoRecycleView = view.FindViewById<RecyclerView>(Resource.Id.TwoRecycleView);

            OneTextView.Text = "Usuario";
            TwoTextView.Text = "Empresa";

            if (this.v == 0)
            {
                
                FillDataInfoUser();
            }
            else
            {
                FillDataAdress();
            }

            return view;
        }


        private void FillDataInfoUser()
        {
            Dictionary<string, List<string>> oneData = new Dictionary<string, List<string>>();


            oneData.Add("oneTitle", new List<string>()
            {
                "Nombres(s)",
                "Apellido(s)",
                "E-mail"
            });

            oneData.Add("oneInfo", new List<string>()
            {
                "Sergio",
                "Zorrilla",
                "bodoquezorrilla@gmail.com"
            });

            Dictionary<string, List<string>> twoData = new Dictionary<string, List<string>>();

            twoData.Add("twoTitle", new List<string>()
            {
                "Empresa",
                "CID"
            });

            twoData.Add("twoInfo", new List<string>()
            {
                "Neodata",
                "929432sadfjle"
            });

            fillRecycleView(oneData, twoData);
        }

        private void FillDataAdress()
        {
            Dictionary<string, List<string>> oneData = new Dictionary<string, List<string>>();

            oneData.Add("oneTitle", new List<string>()
            {
                "E-mail",
                "Número de \nteléfono",
                "Dirección"
            });

            oneData.Add("oneInfo", new List<string>()
            {
                "correo@email.com1",
                "8183003087-3",
                "Alejandro de rodas 1937-3"
            });

            Dictionary<string, List<string>> twoData = new Dictionary<string, List<string>>();

            twoData.Add("twoTitle", new List<string>()
            {
                "E-mail",
                "Número de \nteléfono",
                "Dirección"
            });

            twoData.Add("twoInfo", new List<string>()
            {
               "correo@email.com",
                "8183003087",
                "Alejandro de rodas 1937"
            });

            fillRecycleView(oneData, twoData);
        }

        private void fillRecycleView(Dictionary<string, List<string>> oneData, Dictionary<string, List<string>> twoData)
        {
            GridLayoutManager managerOne = new GridLayoutManager(this.Context, 1);
            OneRecycleView.SetLayoutManager(managerOne);
            infoDirAdapter = new InfoDirAdapter(oneData, 0);
            OneRecycleView.SetAdapter(infoDirAdapter);
            GridLayoutManager managerTwo = new GridLayoutManager(this.Context, 1);
            TwoRecycleView.SetLayoutManager(managerTwo);
            infoDirAdapter = new InfoDirAdapter(twoData, 1);
            TwoRecycleView.SetAdapter(infoDirAdapter);
        }
    }
}
