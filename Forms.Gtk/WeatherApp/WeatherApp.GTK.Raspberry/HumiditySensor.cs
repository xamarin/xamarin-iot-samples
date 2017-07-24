// This sensor gets the current values of a python script from Adafruit for a 
// Humidy Sensor model DHT22, the model can be changed 
// ScriptFile: AdafruitDHT.py
// /home/pi/Adafruit_Python_DHT/examples/AdafruitDHT.py

using System;
using System.Diagnostics;

namespace WeatherApp
{
	public class HumiditySensorDHT22 : BaseHumiditySensor
	{
		readonly public static string DHT22 = "22";

		readonly int pin;
		string adafruitDhtExecutablePath;

		public HumiditySensorDHT22 (int pin, string adafruitDhtExecutablePath)
		{
			this.pin = pin;
			this.adafruitDhtExecutablePath = adafruitDhtExecutablePath;
		}

		string ReadActualValue ()
		{
			string dev = "";

			var order = $"{adafruitDhtExecutablePath} {DHT22} {pin}";
			var arguments = string.Format ("-c \"sudo {0}\"", order);

			using (var proc = new Process {
				StartInfo = new ProcessStartInfo {
					FileName = "/bin/bash",
					Arguments = arguments,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}
			}) {
				proc.Start ();
				proc.WaitForExit ();
				dev = proc.StandardOutput.ReadToEnd ().Trim ();
			};
			return dev;
		}

		public override void OnRefresh ()
		{
			var value = ReadActualValue ();
			var elements = value.Split (new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
			if (elements.Length == 2) {
				foreach (var element in elements) {
					var elementValues = element.Split ('=');
					if (elementValues[0] == "Temp") {
						Temperature = elementValues[1];
					}
					else if (elementValues[0] == "Humidity") {
						Humidity = elementValues[1];
					}
				}
			}
		}
	}
}
