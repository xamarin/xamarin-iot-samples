using System;

namespace Xamarin.IoT.Components
{
	public interface IIoTRelay : IIoTComponent
	{
		event EventHandler PinChanged;

		bool ContainsId (int id);
		void Toggle (int id);
		bool GetPinValue (int id);
		void EnablePin (int id, bool value);
	}
}
