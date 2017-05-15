using System;

namespace Xamarin.IoT.Components
{
	public interface IIoTSensor : IIoTComponent
	{
		event Action<bool> PresenceStatusChanged;
		bool HasPresence { get; }
	}
}
