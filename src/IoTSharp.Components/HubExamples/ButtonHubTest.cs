using System;

namespace IoTSharp.Components.Examples
{
	public class ButtonHubTest : IoTHubContainer
	{
		IIoTButton button;

		public void Configure (IIoTRelay relay, IIoTButton button) 
		{
			this.button = button;
			AddComponent (relay, button);

			button.ButtonDown += Button_ButtonDown;
		}

		public void Button_ButtonDown ()
		{
			GetComponent<IIoTRelay> ().Toggle (0);
		}

		public override void Dispose ()
		{
			button.ButtonDown -= Button_ButtonDown;
			base.Dispose ();
		}
	}
}
