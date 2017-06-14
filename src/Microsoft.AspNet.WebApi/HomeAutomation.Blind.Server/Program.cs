using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web.Http;
using System.Web.Http.SelfHost;
using IoTSharp.Components;

namespace HomeAutomation.Blind.Server
{
	class Program
	{
		public static int delayTime = 1000;
		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}
			throw new Exception("Local IP Address Not Found!");
		}

		public static void Main(string[] args)
		{
			var port = "8085";
			var actualIp = GetLocalIPAddress();
			var config = new HttpSelfHostConfiguration($"http://{actualIp}:{port}");
			config.MapHttpAttributeRoutes();

			IoTFactory.CreateBlind (false, Connectors.GPIO27, Connectors.GPIO17);

			using (HttpSelfHostServer server = new HttpSelfHostServer(config))
			{
				Thread.Sleep(delayTime);
				server.OpenAsync().Wait();
				Console.WriteLine($"Started host server: {actualIp}:{port}");
				while (true)
				{
					Thread.Sleep(delayTime);
				}
			}
		}
	}
}
