
namespace Xamarin.IoT.Components
{
	public class IoTBlind : IoTComponentContainer, IIoTBlind
	{
		public IIoTRelay Relay { get; set; }
		public int RelayPortUp { get; set; }
		public int RelayPortDown { get; set; }

		public IoTBlind (IIoTRelay contentRelay, int relayPortUp, int relayPortDown)
		{
			Relay = contentRelay;
			AddComponent (Relay);
			RelayPortUp = relayPortUp; RelayPortDown = relayPortDown;
		}

		public IoTBlind (Connectors gpioUp, Connectors gpioDown)
		{
			Relay = new IoTRelay (gpioUp, gpioDown);
			AddComponent (Relay);
			RelayPortUp = 0; RelayPortDown = 1;
		}

		public void Up ()
		{
			Relay.EnablePin (RelayPortDown, false);
			Relay.EnablePin (RelayPortUp, true);
		}

		public void Down ()
		{
			Relay.EnablePin (RelayPortUp, false);
			Relay.EnablePin (RelayPortDown, true);
		}

		public void Stop ()
		{
			Relay.EnablePin (RelayPortUp, false);
			Relay.EnablePin (RelayPortDown, false);
		}

		public override void Dispose ()
		{
			Relay.Dispose ();
			base.Dispose ();
		}
	}
}
