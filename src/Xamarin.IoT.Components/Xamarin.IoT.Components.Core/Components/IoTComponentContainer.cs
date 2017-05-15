using System;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.IoT.Components
{
	public abstract class IoTComponentContainer : IoTComponent, IIoTComponentContainer, IDisposable
	{
		public List<IIoTComponent> Components { get; set; } = new List<IIoTComponent> ();

		public override void Dispose ()
		{
			Components.ForEach (c => c.Dispose ());
		}

		public void AddComponent (params IIoTComponent [] control)
		{
			foreach (var item in control) {
				if (!Components.Exists (s => s == item)) {
					Components.Add (item);
				}
			}
		}

		public void RemoveComponent (params IIoTComponent [] control)
		{
			var toRemove = new List<IIoTComponent> ();
			foreach (var item in control) {
				if (!Components.Exists (s => s == item)) {
					toRemove.Add (item);
				}
			}

			foreach (var item in toRemove) {
				Components.Remove (item);
			}
		}
	
		#region Component Locator

		public IEnumerable<T> GetComponents<T> ()
		{
			try {
				return Components.Where (s => typeof (T).IsAssignableFrom (s.GetType ())).Select (s => (T)s);
			} catch (Exception) {
				throw new Exception ($"there is no type implementing '{typeof (T).ToString ()}' in instances array");
			}
		}

		public T GetComponent<T> ()
		{
			return GetComponents<T> ().FirstOrDefault ();
		}

		#endregion
	}
}
