using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
		
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "42c0e77ad3018dc3c35da3da97274faf";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + "&appid=" + key;
			//02116
			try {
				var results = await DataService.getDataFromService (queryString).ConfigureAwait (false);

				Weather weather = new Weather {
					Title = (string)results["name"],
					Temperature = (string)results["main"]["temp"] + " F",
					Wind = (string)results["wind"]["speed"] + " mph",
					Humidity = (string)results["main"]["humidity"] + " %",
					Visibility = (string)results["weather"][0]["main"]
				};
				DateTime time = new System.DateTime (1970, 1, 1, 0, 0, 0, 0);
				DateTime sunrise = time.AddSeconds ((double)results["sys"]["sunrise"]);
				DateTime sunset = time.AddSeconds ((double)results["sys"]["sunset"]);
				weather.Sunrise = sunrise.ToString () + " UTC";
				weather.Sunset = sunset.ToString () + " UTC";
				return weather;
			}
			catch (Exception ex) {
				
			}
			return new Weather () {
				Title = "Postal Code not found"
			};
        }
    }
}