using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Dimensions.CustomControl;
using Dimensions.Database;
using Dimensions.Database.Tables;

namespace Dimensions.Resources.fragment
{
    public class PackageDetailsFragment : Fragment
    {
        View view;
        SQLiteDB<BarcodeDetailsTbl> sQLiteDB;
        List<BarcodeDetailsTbl> lstBarcodeDetails;
        private ListView pckgListView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            sQLiteDB = new SQLiteDB<BarcodeDetailsTbl>();
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            try
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                view = inflater.Inflate(Resource.Layout.PackageDetailsFragment, container, false);
                lstBarcodeDetails = sQLiteDB.GetData().ToList<BarcodeDetailsTbl>();
                var todayData = lstBarcodeDetails.Where(d => d.Date == Convert.ToString(System.DateTime.Now.Date.ToString("mm-dd-yyyy")));
                if (lstBarcodeDetails != null)
                {
                    pckgListView = view.FindViewById<ListView>(Resource.Id.lstViewPackageDetail);
                    pckgListView.Adapter = new CusotmListAdapter(this.Activity, lstBarcodeDetails);
                }
                else
                {
                    (Activity as MainActivity).textToast("No package found!");
                }
            }
            catch(Exception ex) { }
            return view;
        }
    }
}