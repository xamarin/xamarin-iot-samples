using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherApp
{
	public abstract class BaseHumiditySensor : IHumiditySensor
	{
		public event EventHandler NeedsRefresh;
		readonly CancellationTokenSource source;

		public string Temperature {
			get;
			protected set;
		}

		public string Humidity {
			get;
			protected set;
		}

		protected BaseHumiditySensor () 
		{
			source = new CancellationTokenSource ();
		}

		public override string ToString ()
		{
			return string.Format ("[HumiditySensor: Temperature={0}, Humidity={1}]", Temperature, Humidity);
		}

		public virtual void Stop ()
		{
			source.Cancel ();
		}

		public virtual void Start ()
		{
			Task.Run (() => {
				while (!source.IsCancellationRequested) {
					Refresh ();
					Task.Delay (3000).Wait ();
				}

			}, source.Token);
		}

		void Refresh ()
		{
			OnRefresh ();
			NeedsRefresh?.Invoke (this, EventArgs.Empty);
		}

		public abstract void OnRefresh ();
	}
}
