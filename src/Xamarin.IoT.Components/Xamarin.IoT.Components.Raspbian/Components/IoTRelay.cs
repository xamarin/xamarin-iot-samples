using System;
using System.Diagnostics;
using System.Threading;
using Raspberry.IO.GeneralPurpose;

namespace Xamarin.IoT.Components
{
	//public class IoTRelay : IoTComponent, IIoTRelay
	//{
	//	static readonly ITracer tracer = Tracer.Get<IoTButton> ();

	//	readonly ProcessorPin [] pins;
	//	readonly IGpioConnectionDriver driver;
	//	readonly bool inverted;

	//	public event EventHandler PinChanged;
	//	public event EventHandler Toggled;

	//	public bool IsInverted {
	//		get { return inverted; }
	//	}

	//	public IoTRelay (bool inverted, params Connectors [] gpio)
	//	{
	//		this.inverted = inverted;
	//		driver = GpioConnectionSettings.DefaultDriver;
	//		pins = new ProcessorPin [gpio.Length];

	//		for (int i = 0; i < gpio.Length; i++) {
	//			pins [i] = gpio [i].ToProcessor ();
	//			driver.Allocate (pins [i], PinDirection.Output);
	//			EnablePin (i, false);
	//		}
	//	}

	//	public IoTRelay (params Connectors [] gpio) : this (true, gpio)
	//	{
			
	//	}

	//	public bool ContainsId (int id)
	//	{
	//		return id >= 0 && id < pins.Length;
	//	}

	//	public void Toggle (int id)
	//	{
	//		if (!ContainsId (id))
	//			throw new ArgumentException ("GetPinValue id parameter is not in range");
	//		var selectedPin = pins[id];
	//		driver.Write (selectedPin, !inverted && driver.Read (selectedPin));
	//		Thread.Sleep (DefaultInstructionDelayTime);
	//		PinChanged?.Invoke (this, EventArgs.Empty);
	//		Toggled?.Invoke (this, EventArgs.Empty);
	//	}

	//	public bool GetPinValue (int id)
	//	{
	//		if (!ContainsId (id))
	//			throw new ArgumentException ("GetPinValue id parameter is not in range");
	//		//we want the inverted value
	//		return !inverted && driver.Read (pins [id]);
	//	}

	//	public void EnablePin (int id, bool value)
	//	{
	//		if (!ContainsId (id))
	//			throw new ArgumentException ("GetPinValue id parameter is not in range");
			
	//		var selectedPin = pins [id];
	//		var actualValue = GetPinValue (id);

	//		Console.WriteLine ($"EnablePin: {id} > Actual={actualValue} -> To={value}");
	//		if (actualValue == value)
	//			return;

	//		driver.Write (selectedPin, !inverted && value);
	//		Thread.Sleep (DefaultInstructionDelayTime);
	//		PinChanged?.Invoke (this, EventArgs.Empty);
	//	}

	//	public override void Dispose ()
	//	{
	//		foreach (var pin in pins) {
	//			driver.Release (pin);
	//		}
	//	}
	//}
}
