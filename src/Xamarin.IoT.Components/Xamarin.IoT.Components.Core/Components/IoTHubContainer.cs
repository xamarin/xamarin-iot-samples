using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.IoT.Components
{
	public abstract class IoTHubContainer : IoTComponentContainer, IIoTComponentContainer 
	{
		const int DefaultLoopTime = 100;
		bool stopping;

		bool loop;
		public bool Loop {
			get { return loop; }
		}

		int delayTime;
		public int DelayTime {
			get { return delayTime; }
		}

		public virtual void Init ()
		{
			//Needs override
		}

		public void Start (int delayTime = DefaultLoopTime, bool loop = false)
		{
			stopping = false;
			this.loop = loop;
			this.delayTime = delayTime;

			while (!stopping) {
				Components.ForEach (s => s.Update ());
				Update ();
				Thread.Sleep (DefaultInstructionDelayTime);
			}
		}

		public async Task StartAsync (int delayTime = DefaultLoopTime, bool loop = false)
		{
			await Task.Run (() => {
				Start (delayTime, loop);
			});
		}

		public void SetDelayTime (int miliseconds) 
		{
			delayTime = miliseconds;
		}

		public void Stop ()
		{
			stopping = true;
		}
	}
}
