using System;
using System.Diagnostics;
using System.Threading;

namespace Xamarin.IoT.Components.Examples.Raspbian
{
	class Program
	{
		const int maxCount = 4;
		const int delayTime = 150;
		static readonly ITracer tracer = Tracer.Get<Program> ();
		static int count;

		static void Main (string [] args)
		{
			Console.WriteLine ("Welcome to Raspberry Extensions tests");

			//Push Switch or button connected to Gpio27
			IIoTButton button = new IoTButton (Connectors.GPIO27);
			button.ButtonDown += delegate {
				Console.WriteLine ($"DOWN!!!");
			};

			button.ButtonUp += delegate {
				Console.WriteLine ($"UP!!!");
			};

			button.Clicked += delegate {
				count++;
				Console.WriteLine ($"PRESSED THE BUTTON!!! {count}/{maxCount}");
			};

			while (count < maxCount) {
				button.Update ();
				Thread.Sleep (delayTime);
			}

			Console.WriteLine ("Finished execution.");
		}

		//TODO: Uncomment this code to test Hub behaviour

		//static void Main(string[] args)
		//{
		//	Console.WriteLine("Welcome to Raspberry Extensions tests");

		//	//Push Switch or button connected to Gpio27
		//	IIoTRelay relay = new IoTRelay (Connectors.GPIO17, Connectors.GPIO27);

		//	var hubContainer = new RelayHubTest ();
		//	hubContainer.Finished += delegate {
		//		Console.Write ("Finished execution.");
		//	};

		//	hubContainer.Configure (relay);
		//	try {
		//		hubContainer.Start (loop: true);
		//	} catch (Exception ex) {
		//		tracer.Error (ex);
		//	}

		//	hubContainer.Dispose ();
		//}
	}
}
