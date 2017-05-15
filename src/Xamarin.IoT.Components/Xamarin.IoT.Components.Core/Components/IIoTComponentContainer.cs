using System;
using System.Collections.Generic;

namespace Xamarin.IoT.Components
{
	public interface IIoTComponentContainer : IIoTComponent, IDisposable
	{
		List<IIoTComponent> Components { get; set; }
		void AddComponent (params IIoTComponent [] control);
	}
}
