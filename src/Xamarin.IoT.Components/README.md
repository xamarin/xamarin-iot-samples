# IoT.Components

This library allows user to interact easily with Components connected to GPIO of a device. The library is in a early stage, and right now it only covers Raspberry components, but in a future, the code will be refactored to have a expecific backend for platform (something similar like Xwt or Xamarin.Forms does). 

Also, every component encapsulates the complex logic and makes the code maintainable and easy to read like a normal desktop application. 

## Class structure
- IoTComponent
  - IoTButton
  - IoTSensor
  - IoTComponentContainer
  	- IoTHubContainer**
  	- IoTRelay
    	- IoTBlind

## Components

These are the same as describe, your modules, boards, accessories.. it hiddens all complex logic inside it, because a normal user only needs to know the thing he expects:

A) In what IO pin is connected

B) Handling action, set data or check properties

Every other thing like dispose objects, error management, etc... must be managed automatically by the toolkit

### Button

Or push switch.. it allows you detect realworld clicks. It works really same like a Form button, raising actions Down/Up/Clicked and current state button (IsPressed)

![Button](https://www.boxelectronica.com/334-large_default/push-button-12x12x8mm.jpg) 

### Sensor

It's detects a presence in the range of the cell. It raises PresenceStatusChanged event and you can get the actual value with HasPresence property

![Proximity Sensor](https://s-media-cache-ak0.pinimg.com/236x/20/c4/3a/20c43a67d0d3a794f99a1601fe16fbec.jpg)

### Relay

![Relay](http://josehervas.es/sensorizados/wp-content/uploads/2013/11/bannerpng.png)
** Description.. **

### Blind

** Description.. **

### Hub

- Ok, now I know what is a component.. but then what is a Hub? -
Have you ever programmed a videogame like #CocosSharp? If yes, you'll surelly you know what is a scene. This is something similat to Hub concept.

A Hub is a logical collection of functionality in your application. These means in essence a place where you can drop Components and generate some logic begin the time.

### How works:
A Hub manages code in 2 states: Initialization and Update methods if you need to do something is here where you have to do it to avoid unwanted NRE and possible bad statements.

- Initialization method

Overriding this method your code will execute 1 time, this perfect to instanciate objects, etc... 

- Update method

Executes the code into a infinite loop every X miliseconds (this could be changed with a parameter calling Start function).

## Code example:
All components inherits from IoTComponent and some of them from IoTComponentContainer. 

This is an example of a simple CustomHub

```csharp
	class SensorHub : IoTHub
	{
		public override void Init ()
		{
			var presence = new IoTSensor (Connectors.GPIO18);
			presence.PresenceStatusChanged += (s) => {
				Console.WriteLine ($"PresenceStatusChanged {s}");
			};
			AddComponent (presence, relay);
		}
	}
```

* THAT'S IT! *

To be continue...

