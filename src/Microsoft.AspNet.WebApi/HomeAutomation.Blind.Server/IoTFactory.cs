using System;
using System.Collections.Generic;
using System.Linq;
using IoTSharp.Components;

namespace HomeAutomation.Blind.Server
{
	public static class IoTFactory
	{
		static readonly List<object> components = new List<object>();

		public static T Get<T> ()
		{
			var type = typeof (T);
			return (T)components.FirstOrDefault (c => c.GetType () == type);
		}

		public static void CreateBlind (bool inverted, Connectors gpioUp, Connectors gpioDown)
		{
			var relay = new IoTRelay (new [] { gpioUp, gpioDown });
			components.Add (relay);
			components.Add (new IoTBlind (relay, 0, 1));
		}
				
		public static void CreateRelay (bool inverted, params Connectors [] connectors)
		{
			components.Add (new IoTRelay (connectors));
		}

		public static void CreateButton (Connectors gpio)
		{
			components.Add (new IoTButton (gpio));
		}

		public static void Clear ()
		{
			components.Clear ();
		}
	} 
}
