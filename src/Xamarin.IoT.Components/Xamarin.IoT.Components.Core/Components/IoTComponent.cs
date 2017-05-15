using System;
namespace Xamarin.IoT.Components
{
	public abstract class IoTComponent : IIoTComponent, IDisposable
	{
		public int DefaultInstructionDelayTime { get; set; } = 300;

		public virtual void Update () 
		{
			//all components can handle a update logic
		}

		public virtual void Dispose ()
		{
			
		}
	}
}
