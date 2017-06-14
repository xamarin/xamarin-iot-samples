using System;
using System.Diagnostics;
using System.Threading;

namespace IoTSharp.Components.Examples.Raspbian
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
			var button = new IoTButton (Connectors.GPIO27);
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
	}
}
