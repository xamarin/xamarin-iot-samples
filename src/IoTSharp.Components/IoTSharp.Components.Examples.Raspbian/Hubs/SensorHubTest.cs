using System;

namespace IoTSharp.Components.Examples
{
	class SensorHubTest : IoTHubContainer
	{
		public void Configure (IIoTSensor presence, IIoTRelay relay)
		{
			AddComponent (presence, relay);
		}

		public override void Init ()
		{
			GetComponent<IIoTSensor> ()
				.PresenceStatusChanged += PresenceStatusChanged;
		}

		public void PresenceStatusChanged (bool active) {
			Console.WriteLine ($"PresenceStatusChanged {active}");
			GetComponent<IIoTRelay> ().EnablePin (0, active);
		}

		public override void Dispose ()
		{
			GetComponent<IIoTSensor> ()
				.PresenceStatusChanged -= PresenceStatusChanged;
			base.Dispose ();
		}
	}
}
