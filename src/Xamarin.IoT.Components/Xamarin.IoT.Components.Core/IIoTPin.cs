using System;

namespace Xamarin.IoT.Components
{
	public interface IIoTPin : IDisposable
	{
		bool Value { get; set; }

		void SetDirection (IoTPinDirection direction);
		void SetActiveType (IoTActiveType activeType);
		void Close ();
	}
}
