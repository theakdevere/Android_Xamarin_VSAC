using System;
using System.Collections.Generic;
using System.Text;
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
using Microsoft.AppCenter.Auth;
using System.Threading.Tasks;

namespace AndroidXamarin
{
    [Activity(Label = "AndroidXamarin", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Dictionary<string, string> ErrorProperties = new Dictionary<string, string>();
        string ID = Guid.NewGuid().ToString();

        Button btnEventTest;
        Button btnHanledExceptionTest;
        Button btnUnhandledExceptionTest;
        Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ErrorProperties.Add("OnCreate Called", ID);
            SetupAppCenter();
            ErrorProperties.Add("SetupAppCenter Completed", ID);
            Analytics.TrackEvent($"Sending ErrorProps", ErrorProperties);

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            content_main_seting();

          
        }


        private void SetupAppCenter()
        {
            ErrorProperties.Add("SetupAppCenter Start ErrorProperties", ID);
            Crashes.SendingErrorReport += Crashes_SendingErrorReport;
            Crashes.SentErrorReport += Crashes_SentErrorReport;
            Crashes.FailedToSendErrorReport += Crashes_FailedToSendErrorReport;

            AppCenter.LogLevel = LogLevel.Verbose;
            
            Distribute.SetEnabledForDebuggableBuild(true);
            Auth.SetEnabledAsync(true);

            AppCenter.Start("43448a3c-1a36-493e-bdc0-4eefed484e19",
                   typeof(Analytics), typeof(Crashes), typeof(Distribute), typeof(Auth));

            

            ErrorProperties.Add("AppCenter.Start", ID);

            


            Analytics.TrackEvent($"AppCenter.Started at {DateTime.Now.ToLongTimeString()}");
            Analytics.TrackEvent($"Distribute.IsEnabledAsync is {Distribute.IsEnabledAsync().Result}");

            Crashes.GetErrorAttachments = (ErrorReport report) =>
            {
                // Your code goes here.
                return new ErrorAttachmentLog[]
                {
                    ErrorAttachmentLog.AttachmentWithText($"Crash Report Sent at {DateTime.Now.ToLongTimeString()}", $"Crash_{DateTime.Now.ToLongTimeString()}"),
                    ErrorAttachmentLog.AttachmentWithBinary(Encoding.UTF8.GetBytes("Fake image"), $"fake_image_Ticks {DateTime.Now.Ticks.ToString()}.jpeg", "image/jpeg")
                };
            };
        }

        private async Task SignInAsync()
        {
            try
            {
                IsAuthEnabled();
                
                // Sign-in succeeded.
                UserInformation userInfo = await Auth.SignInAsync();
                string accountId = userInfo.AccountId;

                Analytics.TrackEvent($"User {userInfo.AccountId} SignedIn at {DateTime.Now.ToLongTimeString()}");
            }
            catch (Exception ex)
            {
                Analytics.TrackEvent($"SignInAsync Failed at {DateTime.Now.ToLongTimeString()} Message: {ex.Message}");
                Crashes.TrackError(ex);
            }
        }

        private async void IsAuthEnabled()
        {
            bool enabled = await Auth.IsEnabledAsync();
            Analytics.TrackEvent("Auth is Enabled" + enabled.ToString());
        }

        private void Crashes_FailedToSendErrorReport(object sender, FailedToSendErrorReportEventArgs e)
        {
            Analytics.TrackEvent($"Crashes_FailedToSendErrorReport at {DateTime.Now.ToLongTimeString()}");
        }

        private void Crashes_SentErrorReport(object sender, SentErrorReportEventArgs e)
        {
            Analytics.TrackEvent($"Crashes_SentErrorReport at {DateTime.Now.ToLongTimeString()}");
        }

        private void Crashes_SendingErrorReport(object sender, SendingErrorReportEventArgs e)
        {
            Analytics.TrackEvent($"Crashes_SendingErrorReport at {DateTime.Now.ToLongTimeString()}");
        }

        private void content_main_seting()
        {

            btnEventTest = FindViewById<Button>(Resource.Id.btnEventTest);
            btnHanledExceptionTest = FindViewById<Button>(Resource.Id.btnHanledExceptionTest);
            btnUnhandledExceptionTest = FindViewById<Button>(Resource.Id.btnUnhandledExceptionTest);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogon);

            btnEventTest.Click += BtnEventTest_Click;
            btnHanledExceptionTest.Click += BtnHanledExceptionTest_Click;
            btnUnhandledExceptionTest.Click += BtnUnhandledExceptionTest_Click;
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Analytics.TrackEvent($"BtnLogin_Click at {DateTime.Now.ToLongTimeString()}");
            //Sign In
            var signInResults = SignInAsync();
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

