using System;
using Android.Things.Pio;

namespace Xamarin.IoT.Components
{
	public static class Extensions
	{
		public static string Pin (this Connectors gpio)
		{
			var number = gpio.ToString ().Substring ("GPIO".Length).PadLeft (2);
			return $"BCM{number}";
		}

		public static int ToNative (this IoTPinDirection pinDirection)
		{
			switch (pinDirection) {
			case IoTPinDirection.DirectionOutInitiallyHight:
				return Gpio.DirectionOutInitiallyHigh;
			case IoTPinDirection.DirectionOutInitiallyLow:
				return Gpio.DirectionOutInitiallyLow;
			case IoTPinDirection.DirectionIn:
				return Gpio.DirectionIn;
			default:
				throw new NotImplementedException ("Not implemented type");
			}
		}

		public static int ToNative (this IoTActiveType pinDirection)
		{
			switch (pinDirection) {
			case IoTActiveType.ActiveLow:
				return Gpio.ActiveLow;
			case IoTActiveType.ActiveHigh:
				return Gpio.ActiveHigh;
			default:
				throw new NotImplementedException ("Not implemented type");
			}
		}
	}
}
