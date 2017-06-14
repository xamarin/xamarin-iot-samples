using System;
using System.Threading;

namespace IoTSharp.Components.Examples
{
	public class RelayHubTest : IoTHubContainer
	{
		public event EventHandler<int> Step;
		public event EventHandler Finished;
		int count;

		public void Configure (IIoTRelay relay) 
		{
			AddComponent (relay);
			SetDelayTime (250);
		}

		public override void Update ()
		{
			IIoTRelay relayComponent = GetComponent<IIoTRelay> ();
			relayComponent.Toggle (0);
			Thread.Sleep (DelayTime);
			relayComponent.Toggle (1);

			if (count == 10) {
				Stop ();
				Finished?.Invoke (this, EventArgs.Empty);
			} else {
				count++;
				Step?.Invoke (this, count);
			}
		}
	}
}
