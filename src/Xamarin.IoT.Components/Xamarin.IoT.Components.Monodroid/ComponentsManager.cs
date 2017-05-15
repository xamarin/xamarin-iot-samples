using System;
using Android.OS;
using Android.Things.Pio;

namespace Xamarin.IoT.Components
{
	public static class ComponentsManager
	{
		const string DEVICE_EDISON_ARDUINO = "edison_arduino";
		const string DEVICE_EDISON = "edison";
		const string DEVICE_RPI3 = "rpi3";
		const string DEVICE_NXP = "imx6ul";
		static string BoardVariant = "";

		public static PeripheralManagerService Current;

		static ComponentsManager ()
		{
			try {
				string pinName = GetGpioForLed ();
				Current = new PeripheralManagerService ();

			} catch (Exception ex) {
				Console.Write (ex);
			}
		}

		public static string GetGpioForLed ()
		{
			switch (GetBoardVariant ()) {
			case DEVICE_EDISON_ARDUINO:
				return "IO13";
			case DEVICE_EDISON:
				return "GP45";
			case DEVICE_RPI3:
				return "BCM6";
			case DEVICE_NXP:
				return "GPIO4_IO20";
			default:
				throw new ArgumentException ("Unknown Build.DEVICE " + Build.Device);
			}
		}

		public static string GetBoardVariant ()
		{
			if (!string.IsNullOrEmpty (BoardVariant)) {
				return BoardVariant;
			}
			BoardVariant = Build.Device;

			if (BoardVariant.Equals (DEVICE_EDISON)) {
				var pioService = new PeripheralManagerService ();
				var gpioList = pioService.GpioList;
				if (gpioList.Count != 0) {
					string pin = gpioList [0];
					if (pin.StartsWith ("IO", StringComparison.Ordinal))
						BoardVariant = DEVICE_EDISON_ARDUINO;
				}
			}
			return BoardVariant;
		}
	}
}
