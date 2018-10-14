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

namespace SignalRChatAPK.Droid
{
    public class LoginInfo : DialogFragment
    {
        public class OnLoginCompletEventArgs : EventArgs
        {
            public string User { get; set; }
        }

        public event EventHandler<OnLoginCompletEventArgs> OnLoginInfoComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Login, container, false);

            EditText txtUser = view.FindViewById<EditText>(Resource.Id.txtUser);
            Button btnOkay = view.FindViewById<Button>(Resource.Id.btnLogin);

            btnOkay.Click += (o, e) =>
            {
                var args = new OnLoginCompletEventArgs { User = txtUser.Text.Trim() };
                OnLoginInfoComplete.Invoke(this, args);
                Dismiss();
            };

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
    }
}