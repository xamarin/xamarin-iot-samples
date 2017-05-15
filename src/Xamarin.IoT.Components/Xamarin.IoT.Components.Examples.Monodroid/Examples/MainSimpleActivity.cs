using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.IoT.Components;

namespace ComponentsExample
{
	[Activity (Label = "Components Basic Example", Icon = "@mipmap/icon")]
	public class MainSimpleActivity : Activity
	{
		int count = 1;
		IIoTButton iotButton;
		IIoTRelay iotRelay;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			var btnCount = FindViewById<Button> (Resource.Id.btnCount);
			var btnLight = FindViewById<Button> (Resource.Id.btnLight);
			var btnNext = FindViewById<Button> (Resource.Id.btnNext);

			iotButton = new IoTButton (Connectors.GPIO12);
			iotRelay = new IoTRelay (Connectors.GPIO17, Connectors.GPIO27);

			iotButton.Clicked += delegate {
				//Real-life click!
				btnCount.Text = $"{count++} clicks!";
			};

			btnCount.Click += delegate {
				//Virtual click!
				Toast.MakeText (this, "Push the real button", ToastLength.Long);
			};

			btnLight.Click += delegate {
				//Toggles the relay on/off
				iotRelay.Toggle (0);
			};

			btnNext.Click += delegate {
				StartActivity (typeof (MainHubActivity));
			};

			iotRelay.Toggle (0);
			iotRelay.Toggle (0);
			iotRelay.Toggle (0);
			iotRelay.Toggle (0);
			iotRelay.Toggle (1);
			iotRelay.Toggle (1);
			iotRelay.Toggle (1);
			iotRelay.Toggle (1);
		}

		protected override void Dispose (bool disposing)
		{
			iotButton.Dispose ();
			iotRelay.Dispose ();
			base.Dispose (disposing);
		}
	}
}
