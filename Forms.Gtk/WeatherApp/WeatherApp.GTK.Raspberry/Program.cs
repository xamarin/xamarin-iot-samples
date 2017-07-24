using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace WeatherApp.GTK.Raspberry
{
	class Program
	{
		static void Main (string[] args)
		{
			//TODO: This is an example of reading a sensor using the output of a python script
			//the python code is available from https://github.com/adafruit/Adafruit_Python_DHT/blob/master/examples/AdafruitDHT.py 
			//you need to copy to the raspberry
			var script = "/home/pi/Adafruit_Python_DHT/examples/AdafruitDHT.py";
			var sensor = new HumiditySensorDHT22 (18, script);

			Gtk.Application.Init ();
			Forms.Init ();

			var app = new App (sensor);
			var window = new FormsWindow ();
			window.LoadApplication (app);
			window.SetApplicationTitle ("WeatherApp");
			window.Show ();
			Gtk.Application.Run ();
		}
	}
}
