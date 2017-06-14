using System;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using IoTSharp.Components;

namespace HomeAutomation.Blind.Server
{
	public class IoTServiceController : ApiController
	{
		[Route ("blind/{up}")]
		public HttpResponseMessage GetActionBlind (string up)
		{
			Console.WriteLine($"Received: '{up}'");
			var blindInstance = IoTFactory.Get<IoTBlind> ();
			switch (up) {
			case "0":
				blindInstance.Stop ();
				return new HttpResponseMessage (HttpStatusCode.OK);
			case "1":
				blindInstance.Up ();
				return new HttpResponseMessage (HttpStatusCode.OK);
			case "2":
				blindInstance.Down ();
				return new HttpResponseMessage (HttpStatusCode.OK);
			default:
				return new HttpResponseMessage (HttpStatusCode.ExpectationFailed);
			}
		}

		[Route ("relay/{number}/{value}")]
		public HttpResponseMessage GetActionRelay (string number, string value)
		{
			Console.WriteLine ($"received number:'{value}' -> value: {value}");
			if ((number != "0" && number != "1") || (value != "0" && value != "1")) {
				Console.WriteLine ($"Error received values =>  number:{value}, value: {value}");
				return new HttpResponseMessage (HttpStatusCode.ExpectationFailed);
			}

			IoTFactory.Get<IoTRelay> ()
							.EnablePin (int.Parse (number), value == "1");
			return new HttpResponseMessage (HttpStatusCode.OK);
		}
	}
}
