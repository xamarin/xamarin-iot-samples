namespace IoTSharp.Components.Examples
{
	public class BlindHubTest : IoTHubContainer
	{
		public void Configure (IIoTBlind blind)
		{
			AddComponent (blind);
		}

		public override void Init ()
		{
			var blind = GetComponent<IIoTBlind> ();
			blind.Down ();
			blind.Up ();
			blind.Stop ();
		}
	}
}
