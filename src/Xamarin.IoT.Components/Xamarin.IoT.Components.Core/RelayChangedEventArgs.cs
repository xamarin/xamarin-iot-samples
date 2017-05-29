using System;

namespace Xamarin.IoT.Components
{
	public class RelayChangedEventArgs : EventArgs
	{
		public int Index { get; private set; }
		public bool Value { get; private set; }

		public RelayChangedEventArgs (int index, bool value)
		{
			Index = index;
			Value = value;
		}
	}
}