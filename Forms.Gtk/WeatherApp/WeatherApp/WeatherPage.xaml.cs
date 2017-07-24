using System;
using Xamarin.Forms;

namespace WeatherApp
{
	public partial class WeatherPage : ContentPage
    {
		void Humidity_NeedsRefresh (object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread (() => {
				//humidity
				lblRealtime.Text = $"Temp={humidity.Temperature}  Humidity={humidity.Humidity}";
			});
		}

		IHumiditySensor humidity;
		public Weather WeatherContext {
			get { return (Weather)BindingContext; }
			set {
				BindingContext = value;
			}
		}
		public WeatherPage ()
		{
			InitializeComponent ();
			this.Title = "Sample Weather App";
		}

		public WeatherPage (IHumiditySensor humidity)
        {
			this.humidity = humidity;

            InitializeComponent();
            this.Title = "Sample Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;

            //Set the default binding to a default object for now
            WeatherContext = new Weather();


			humidity.NeedsRefresh += Humidity_NeedsRefresh;

			humidity.Start ();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                if (weather != null)
                {
                    WeatherContext = weather;
                    getWeatherBtn.Text = "Search Again";
                }
            }
        }
	}
}