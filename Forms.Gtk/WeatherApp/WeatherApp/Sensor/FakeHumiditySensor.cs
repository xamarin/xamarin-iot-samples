using System;

namespace WeatherApp
{
	public class FakeHumiditySensor : BaseHumiditySensor
	{
		readonly Random rand;

		public FakeHumiditySensor ()
		{
			rand = new Random (DateTime.Now.Millisecond);
		}

		public override void OnRefresh ()
		{
			Temperature = string.Format ("{0}ºC", rand.Next (30, 90));
			Humidity = string.Format ("{0}%", rand.Next (30, 130));
		}
	}
}
