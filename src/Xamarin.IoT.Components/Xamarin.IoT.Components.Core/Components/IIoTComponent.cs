using System;
namespace Xamarin.IoT.Components
{
	public interface IIoTComponent : IDisposable
	{
		int DefaultInstructionDelayTime { get; set; }
		void Update ();
	}
}
