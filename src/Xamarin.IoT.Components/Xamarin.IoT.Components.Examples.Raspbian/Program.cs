using System;
using System.Diagnostics;

namespace Xamarin.IoT.Components.Examples.Raspbian
{
	class Program
	{
		static readonly ITracer tracer = Tracer.Get<Program> ();

		static void Main (string [] args)
		{
			Console.WriteLine ("Welcome to Raspberry Extensions tests");
			IIoTRelay relay = new IoTRelay (Connectors.GPIO17, Connectors.GPIO27);

			var hubContainer = new RelayHubTest ();
			hubContainer.Step += (sender, step) => {
				Console.Write ($"Step {step}");
			};
			hubContainer.Finished += delegate {
				Console.Write ($"Finished");
			};

			hubContainer.Configure (relay);
			try {
				hubContainer.Start (loop: true);
			} catch (Exception ex) {
				tracer.Error (ex);
			}

			hubContainer.Dispose ();
		}
	}
}
