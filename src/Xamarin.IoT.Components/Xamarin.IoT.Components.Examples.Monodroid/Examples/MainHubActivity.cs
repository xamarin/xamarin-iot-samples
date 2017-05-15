using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.IoT.Components.Monodroid.Components;
using Xamarin.IoT.Components;
using Xamarin.IoT.Components.Examples;

namespace ComponentsExample
{
	[Activity (Label = "Components Hub Example", Icon = "@mipmap/icon")]
	public class MainHubActivity : ActivityHub<ButtonHubTest>
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			var btnCount = FindViewById<Button> (Resource.Id.btnCount);
			var btnLight = FindViewById<Button> (Resource.Id.btnLight);
			var btnNext = FindViewById<Button> (Resource.Id.btnNext);

			IIoTButton iotButton = new IoTButton (Connectors.GPIO17);
			IIoTRelay iotRelay = new IoTRelay (Connectors.GPIO27);
			HubContext.Configure (iotRelay, iotButton);

			btnCount.Click += delegate {
				btnCount.Text = $"{count++} clicks!";
			};

			//Binds real IoT button with a Android.Button behaviour
			iotButton.Bind (btnCount);

			//Binds Android.Button automatically button with relay toggle action
			btnLight.Bind (iotRelay, 0);

			btnLight.Click += delegate {
				iotRelay.Toggle (0);
			};

			btnNext.Text = "Back";
			btnNext.Click += delegate {
				Finish ();
			};
		}
	}
}
