using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;


namespace Android_Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetupAppCenter();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }


        private void SetupAppCenter()
        {
            AppCenter.LogLevel = LogLevel.Verbose;

            Distribute.SetEnabledForDebuggableBuild(true);

            AppCenter.Start("43448a3c-1a36-493e-bdc0-4eefed484e19",
                   typeof(Analytics), typeof(Crashes), typeof(Distribute));

            //Distribute.SetEnabledAsync(true);
        }

        private void content_main_seting()
        {
            Button btnEventTest;
            Button btnHanledExceptionTest;
            Button btnUnhandledExceptionTest;

            btnEventTest = FindViewById<Button>(Resource.Id.btnEventTest);
            btnHanledExceptionTest = FindViewById<Button>(Resource.Id.btnHanledExceptionTest);
            btnUnhandledExceptionTest = FindViewById<Button>(Resource.Id.btnUnhandledExceptionTest);

            btnEventTest.Click += BtnEventTest_Click;
            btnHanledExceptionTest.Click += BtnHanledExceptionTest_Click;
            btnUnhandledExceptionTest.Click += BtnUnhandledExceptionTest_Click;
        }

        private void BtnUnhandledExceptionTest_Click(object sender, EventArgs e)
        {
            throw new Exception($"BtnUnhandledExceptionTest_Click at {DateTime.Now.ToLongTimeString()}");
        }

        private void BtnHanledExceptionTest_Click(object sender, EventArgs e)
        {
            try
            {   
                throw new Exception($"BtnHanledExceptionTest_Click at {DateTime.Now.ToLongTimeString()}");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        private void BtnEventTest_Click(object sender, EventArgs e)
        {
            Analytics.TrackEvent($"BtnEventTest_Click at {DateTime.Now.ToLongTimeString()}");
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

