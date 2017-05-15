using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.IoT.Components;
using System;
using Android.Things.Pio;
using System.Threading;
using System.Diagnostics;
using Xamarin.IoT.Components.Examples;

namespace ComponentsExample
{
	[Activity (Label = "Components Basic Example", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		static readonly ITracer tracer = Tracer.Get<MainActivity> ();
		RelayHubTest hubContainer;

		protected async override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.SimpleMain);

			//UI Logic
			ConfigureUI ();

			Console.WriteLine ("Welcome to Raspberry Extensions tests");
			var relay = new IoTRelay (Connectors.GPIO17, Connectors.GPIO27);

			hubContainer = new RelayHubTest ();
			hubContainer.Step += (sender, step) => {
				RunOnUiThread (() => lblLog.Text = $"Step {step}");
			};
			hubContainer.Finished += delegate {
				RunOnUiThread (() => lblLog.Text = $"Finished");
			};

			hubContainer.Configure (relay);
			try {
				await hubContainer.StartAsync (loop: true);
			} catch (Exception ex) {
				tracer.Error (ex);
			}
		}

		#region UI controls

		Button btnNext;
		TextView lblLog;
		public void ConfigureUI ()
		{
			lblLog = FindViewById<TextView> (Resource.Id.lblLog);
			btnNext = FindViewById<Button> (Resource.Id.btnNext);
			btnNext.Click += delegate {
				hubContainer.Stop ();
				StartActivity (typeof (MainSimpleActivity));
			};
		}

		#endregion

		protected override void Dispose (bool disposing)
		{
			hubContainer.Dispose ();
			base.Dispose (disposing);
		}
	}
}
