using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AudioToolbox;
using Foundation;
using UIKit;

namespace HomeAutomation.Blind.IOS
{
	public partial class ViewController : UIViewController
	{
		const int DefaultPort = 8085;
		string host;
		int port;
		string apiURL => $"http://{host}:{port}/blind/";

		enum BlindAction
		{
			Stop, Up, Down
		}

		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ParseSettings (out host, out port);
		}

		partial void BtnUp_TouchDownInside (UIButton sender)
		{
			btnUp.BackgroundColor = UIColor.Black;
			SystemSound.Vibrate.PlaySystemSound ();
		}

		partial void BtnDtop_TouchDownInside (UIButton sender)
		{
			btnStop.BackgroundColor = UIColor.Black;
			SystemSound.Vibrate.PlaySystemSound ();
		}

		partial void BtnDown_TouchDownInside (UIButton sender)
		{
			btnDown.BackgroundColor = UIColor.Black;
			SystemSound.Vibrate.PlaySystemSound ();
		}

		partial void BtnUp_TouchUpInside (UIButton sender)
		{
			btnUp.BackgroundColor = null;
			ExecuteBlindAction (BlindAction.Up);
		}

		partial void BtnStop_TouchUpInside (UIButton sender)
		{
			btnStop.BackgroundColor = null;
			ExecuteBlindAction (BlindAction.Stop);
		}

		partial void BtnDown_TouchUpInside (UIButton sender)
		{
			btnDown.BackgroundColor = null;
			ExecuteBlindAction (BlindAction.Down);
		}

		async void ExecuteBlindAction (BlindAction action)
		{
			var url = apiURL + (int)action;
			await FetchUrl (url);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		// Gets weather data from the passed URL.
		async Task FetchUrl (string url)
		{
			try {
				// Create an HTTP web request using the URL:
				var request = (HttpWebRequest)WebRequest.Create (new Uri (url));
				request.ContentType = "application/json";
				request.Method = "GET";

				// Send the request to the server and wait for the response:
				using (WebResponse response = await request.GetResponseAsync ()) {
					// Get a stream representation of the HTTP web response:
					using (Stream stream = response.GetResponseStream ()) {
						// Use this stream to build a JSON document object:
					}
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine (ex.Message);
			}
		}

		public void ParseSettings (out string host, out int port)
		{
			host = ""; port = 0;
			var settingsDict = new NSDictionary (NSBundle.MainBundle.PathForResource ("Settings.bundle/Root.plist", null));
			var prefSpecifierArray = settingsDict ["PreferenceSpecifiers"] as NSArray;
			foreach (var prefItem in NSArray.FromArray<NSDictionary> (prefSpecifierArray)) {
				var key = (NSString)prefItem ["Key"];
				if (key == null)
					continue;

				var val = prefItem ["DefaultValue"]?.ToString ();
				switch (key.ToString ()) {
				case "ipaddress":
					host = val;
					break;
				case "port":
					if (!int.TryParse (val, out port)) {
						port = DefaultPort;
					}
					break;
				}
			};
		}
	}
}
