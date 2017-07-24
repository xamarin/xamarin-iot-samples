using System;

namespace WeatherApp
{
	public interface IHumiditySensor
	{
		event EventHandler NeedsRefresh;
		string Temperature { get; }
		string Humidity { get; }
		void Start ();
	}
}