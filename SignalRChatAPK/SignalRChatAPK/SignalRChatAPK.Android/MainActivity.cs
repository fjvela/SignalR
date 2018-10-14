using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRChatAPK.Droid
{
    [Activity(Label = "SignalRChatAPK", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private IHubProxy chatHubProxy;
        private string user;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            SetContentView(Resource.Layout.Main);

            LoginInfo getInfo = new LoginInfo();
            getInfo.OnLoginInfoComplete += GetInfo_OnLoginInfoComplete; ;
            getInfo.Show(FragmentManager, "LoginInfo");
        }

        private async void GetInfo_OnLoginInfoComplete(object sender, LoginInfo.OnLoginCompletEventArgs e)
        {
            user = e.User;

            HubConnection hubConnection = new HubConnection("");
            hubConnection.StateChanged += HubConnection_StateChanged;
            chatHubProxy = hubConnection.CreateHubProxy("ChatHub");
            chatHubProxy.On<string>("newChatMsg", (message) =>
           {
               RunOnUiThread(() =>
               {
                   TextView txt = new TextView(this);
                   txt.Text = message;
                   txt.SetTextSize(Android.Util.ComplexUnitType.Sp, 20);
                   txt.SetPadding(10, 10, 10, 10);

                   txt.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
                   {
                       TopMargin = 10,
                       BottomMargin = 10,
                       LeftMargin = 10,
                       RightMargin = 10,
                       Gravity = GravityFlags.Right
                   };

                   FindViewById<LinearLayout>(Resource.Id.llChatMessages).AddView(txt);
               });
           });

            try
            {
                await hubConnection.Start();
            }
            catch (Exception)
            {
                //Catch handle Errors.   
            }

            FindViewById<Button>(Resource.Id.btnSend).Click += async (o, e2) =>
            {
                EditText editText = FindViewById<EditText>(Resource.Id.txtChat);
                var msg = editText.Text;
                await chatHubProxy.Invoke("Send", new object[] { user, msg });
                editText.Text = string.Empty;
            };
        }

        private async void HubConnection_StateChanged(StateChange obj)
        {
            switch (obj.NewState)
            {
                case ConnectionState.Connected:
                    await chatHubProxy.Invoke("SendNewUser", new object[] { user });
                    break;
            }

        }
    }
}