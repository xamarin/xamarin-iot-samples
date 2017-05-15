using System;
using System.Diagnostics;
using System.Threading;
using Raspberry.IO.GeneralPurpose;

namespace Xamarin.IoT.Components
{
	//public class IoTButton : IoTComponent, IIoTButton
	//{
	//	static readonly ITracer tracer = Tracer.Get<IoTButton> ();
	//	public event Action ButtonDown;
	//	public event Action ButtonUp;
	//	public event Action Clicked;
	//	public bool IsPressed { get; private set; }

	//	readonly ProcessorPin procPin;
	//	readonly IGpioConnectionDriver driver;

	//	public IoTButton (Connectors gpio)
	//	{
			
	//		procPin = gpio.ToProcessor ();
	//		driver = GpioConnectionSettings.DefaultDriver;
	//		driver.Allocate (procPin, PinDirection.Input);
	//		Thread.Sleep (DefaultInstructionDelayTime);
	//		IsPressed = !driver.Read (procPin);
	//		Thread.Sleep (DefaultInstructionDelayTime);
	//	}

	//	public override void Update ()
	//	{
	//		var value = !driver.Read (procPin);
	//		if (IsPressed == value)
	//			return;
	//		IsPressed = value;
	//		if (IsPressed)
	//			ButtonDown?.Invoke ();
	//		else
	//			ButtonUp?.Invoke ();
	//		Clicked?.Invoke ();
	//	}

	//	public override void Dispose ()
	//	{
	//		driver.Release (procPin);
	//	}
	//}
}
