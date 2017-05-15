using Raspberry.IO.GeneralPurpose;

namespace Xamarin.IoT.Components
{
	public static class Extensions
	{
		public static OutputPinConfiguration Output (this Connectors gpio)
		{
			return gpio.Pin ().Output ();
		}

		public static ProcessorPin ToProcessor (this Connectors gpio)
		{
			return gpio.Pin ().ToProcessor ();
		}

		public static ConnectorPin Pin (this Connectors gpio)
		{
			switch (gpio) {
			case Connectors.GPIO2:
				return ConnectorPin.P1Pin03;
			case Connectors.GPIO3:
				return ConnectorPin.P1Pin05;
			case Connectors.GPIO4:
				return ConnectorPin.P1Pin07;
			case Connectors.GPIO5:
				return ConnectorPin.P1Pin29;
			case Connectors.GPIO6:
				return ConnectorPin.P1Pin31;
			case Connectors.GPIO7:
				return ConnectorPin.P1Pin26;
			case Connectors.GPIO8:
				return ConnectorPin.P1Pin24;
			case Connectors.GPIO9:
				return ConnectorPin.P1Pin21;
			case Connectors.GPIO10:
				return ConnectorPin.P1Pin19;
			case Connectors.GPIO11:
				return ConnectorPin.P1Pin23;
			case Connectors.GPIO12:
				return ConnectorPin.P1Pin32;
			case Connectors.GPIO13:
				return ConnectorPin.P1Pin33;
			case Connectors.GPIO14:
				return ConnectorPin.P1Pin08;
			case Connectors.GPIO15:
				return ConnectorPin.P1Pin10;
			case Connectors.GPIO16:
				return ConnectorPin.P1Pin36;
			case Connectors.GPIO17:
				return ConnectorPin.P1Pin11;
			case Connectors.GPIO18:
				return ConnectorPin.P1Pin12;
			case Connectors.GPIO19:
				return ConnectorPin.P1Pin35;
			case Connectors.GPIO20:
				return ConnectorPin.P1Pin38;
			case Connectors.GPIO21:
				return ConnectorPin.P1Pin40;
			case Connectors.GPIO22:
				return ConnectorPin.P1Pin15;
			case Connectors.GPIO23:
				return ConnectorPin.P1Pin16;
			case Connectors.GPIO24:
				return ConnectorPin.P1Pin18;
			case Connectors.GPIO25:
				return ConnectorPin.P1Pin22;
			case Connectors.GPIO26:
				return ConnectorPin.P1Pin37;
			case Connectors.GPIO27:
				return ConnectorPin.P1Pin13;

			default:
				//ConnectorGpio.GPIO24
				return ConnectorPin.P1Pin18;
			}
		}
	
	}
}
