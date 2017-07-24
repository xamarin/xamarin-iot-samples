using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;
using WeatherApp;

namespace WeatherApp.GTK
{
    class Program
    {
        static void Main(string[] args)
        {
            Gtk.Application.Init();
            Forms.Init();

			var sensor = new FakeHumiditySensor ();
            var app = new App(sensor);
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("WeatherApp");
            window.Show();
            Gtk.Application.Run();
        }
    }
}