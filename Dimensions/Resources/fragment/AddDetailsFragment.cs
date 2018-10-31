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
using Dimensions.Database;
using Dimensions.Database.Tables;

namespace Dimensions.Resources.fragment
{
    public class AddDetailsFragment : Fragment
    {
        string barCode, Height, Width, Depth;
        SQLiteDB<BarcodeDetailsTbl> _sQLiteDB;
        BarcodeDetailsTbl _barcodeDetailsTbl;
       
        View view;
        Fragment mainMenu;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _sQLiteDB = new SQLiteDB<BarcodeDetailsTbl>();
            _barcodeDetailsTbl = new BarcodeDetailsTbl();
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.AddDeviceFragment, container, false);
            Button saveButton = view.FindViewById<Button>(Resource.Id.btnSave);
            saveButton.Click += SaveButton_Click;          
            return view;
        }
      
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                barCode = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtBarcode).Text);
                Height = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtHeight).Text);
                Width = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtWidth).Text);
                Depth = Convert.ToString(view.FindViewById<EditText>(Resource.Id.txtDepth).Text);
                if (string.IsNullOrEmpty(barCode))
                {
                    (Activity as MainActivity).textToast("Please enter valid barcode");
                }
                if (string.IsNullOrEmpty(Height) && string.IsNullOrEmpty(Width) && string.IsNullOrEmpty(Depth))
                {
                    (Activity as MainActivity).textToast("Please enter valid dimensions");

                }
                else
                {
                    _barcodeDetailsTbl.Barcode = barCode;
                    _barcodeDetailsTbl.Height = Height;
                    _barcodeDetailsTbl.Width = Width;
                    _barcodeDetailsTbl.Depth = Depth;
                    _barcodeDetailsTbl.Date = Convert.ToString(System.DateTime.Now.Date.ToString("mm-dd-yyyy"));
                    _sQLiteDB.insert(_barcodeDetailsTbl);
                    (Activity as MainActivity).textToast("Dimm (" + Height + "," + Width + "," + Depth + ")" + barCode + " saved");
                    Fragment mainMenuFragment = new MainMenuFragment();
                    FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                    fragmentTransaction.SetTransition(FragmentTransit.EnterMask);
                    fragmentTransaction.Replace(Resource.Id.fragment_container, mainMenuFragment);
                    fragmentTransaction.Commit();
                }

            }
            catch (Exception ex) { }
        }
    }
}