using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;

namespace Xamarin.IoT.Components.Monodroid.Components
{
	public class ActivityHub<T> : Activity where T : IoTHubContainer
	{
		protected T HubContext { get; private set; }

		protected ActivityHub ()
		{
			try {
				HubContext = Activator.CreateInstance<T> ();
			} catch (Exception ex) {
				throw ex;
			}
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		protected ActivityHub (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		protected override void Dispose (bool disposing)
		{
			HubContext?.Dispose ();
			base.Dispose (disposing);
		}
	}
}
