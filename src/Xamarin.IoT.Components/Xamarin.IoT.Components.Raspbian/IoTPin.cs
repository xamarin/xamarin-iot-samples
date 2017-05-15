using System;
using Raspberry.IO.GeneralPurpose;

namespace Xamarin.IoT.Components
{
	public class IoTPin : IIoTPin
	{
		readonly IGpioConnectionDriver driver;
		readonly ProcessorPin pin;

		public bool Value {
			get { return driver.Read (pin); }
			set {
				driver.Write (pin, value);
			}
		}

		public IoTPin (Connectors connector)
		{
			driver = GpioConnectionSettings.DefaultDriver;
			pin = connector.ToProcessor ();
		}

		public void SetDirection (IoTPinDirection direction)
		{
			switch (direction) {
			case IoTPinDirection.DirectionOutInitiallyLow:
			case IoTPinDirection.DirectionOutInitiallyHight:
				driver.Allocate (pin, PinDirection.Output);
				break;
			case IoTPinDirection.DirectionIn:
				driver.Allocate (pin, PinDirection.Input);
				break;
			}
		}

		public void SetActiveType (IoTActiveType activeType)
		{
			//pin.SetActiveType (activeType.ToNative ());
		}

		public void Close ()
		{
			driver.Release (pin);
		}

		public void Dispose ()
		{
			
		}
	}
}
