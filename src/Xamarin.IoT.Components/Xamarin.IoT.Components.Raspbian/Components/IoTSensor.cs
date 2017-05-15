using System;
using Raspberry.IO.GeneralPurpose;

namespace Xamarin.IoT.Components
{
	//public class IoTSensor : IoTComponent, IIoTSensor
	//{
	//	public event Action<bool> PresenceStatusChanged;
	//	public bool HasPresence { get; private set; }
	//	public bool HasError { get; private set; }
	//	public string LastError { get; private set; }
	//	public bool IsInvered { 
	//		get { return inverted; } 
	//	}

	//	readonly ProcessorPin procPin;
	//	readonly IGpioConnectionDriver driver;
	//	bool inverted;

	//	public IoTSensor (Connectors gpio, bool inverted = false)
	//	{
	//		this.inverted = inverted;
	//		procPin = gpio.ToProcessor ();
	//		driver = GpioConnectionSettings.DefaultDriver;
	//		try {
	//			driver.Allocate (procPin, PinDirection.Input);
	//			HasPresence = !inverted && driver.Read (procPin);
	//			Console.WriteLine ("Initial value: "+HasPresence);
	//		} catch (Exception ex) {
	//			HasError = true;
	//			LastError = ex.Message;
	//			Console.WriteLine (ex);
	//		}
	//	}

	//	public override void Update ()
	//	{
	//		try {
	//			var presence = !inverted && driver.Read (procPin);
	//			if (presence == HasPresence)
	//				return;
	//			HasPresence = presence;
	//			PresenceStatusChanged?.Invoke (presence);
	//		} catch (Exception ex) {
	//			HasError = true;
	//			LastError = ex.Message;
	//			Console.WriteLine (ex);
	//		}
	//	}

	//	public override void Dispose ()
	//	{
	//		driver.Release (procPin);
	//	}
	//}
}
