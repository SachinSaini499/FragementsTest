using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace Dimensions.Resources.fragment
{
    public class MainMenuFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.MainMenuFragment, container, false);
            Button addDimensionButton = view.FindViewById<Button>(Resource.Id.addDimensionBtn);
            addDimensionButton.Click += AddDimensionBtnClicked;
            Button showDimensionButton = view.FindViewById<Button>(Resource.Id.showDimensionBtn);
            showDimensionButton.Click += ShowDimensionBtnClicked;
            return view;
        }

        private void AddDimensionBtnClicked(object sender, EventArgs e)
        {
            Fragment addDetails = new AddDetailsFragment();
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.SetTransition(FragmentTransit.EnterMask);
            fragmentTransaction.Replace(Resource.Id.fragment_container, addDetails);
            fragmentTransaction.Commit();
        }

        private void ShowDimensionBtnClicked(object sender, EventArgs e)
        {
            Fragment packageDetails = new PackageDetailsFragment();
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.SetTransition(FragmentTransit.EnterMask);
            fragmentTransaction.Replace(Resource.Id.fragment_container, packageDetails );
            fragmentTransaction.Commit();

        }
    }
}