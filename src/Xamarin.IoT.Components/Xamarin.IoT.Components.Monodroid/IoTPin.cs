using System;
using Android.Things.Pio;

namespace Xamarin.IoT.Components
{
	public class IoTPin : IIoTPin
	{
		readonly PeripheralManagerService service;
		readonly Gpio pin;

		public bool Value {
			get { return pin.Value; }
			set {
				pin.Value = value;
			}
		}

		public IoTPin (Connectors connector)
		{
			service = ComponentsManager.Current;
			pin = service.OpenGpio (connector.Pin ());
		}

		public void SetDirection (IoTPinDirection direction)
		{
			pin.SetDirection (direction.ToNative ());
		}

		public void SetActiveType (IoTActiveType activeType)
		{
			pin.SetActiveType (activeType.ToNative ());
		}

		public void Close ()
		{
			pin.Close ();
		}

		public void Dispose ()
		{
			pin.Dispose ();
		}
	}
}
