using System;
using System.Net;
using System.Net.Mqtt;
using System.Text;
using System.Threading;

namespace MqttTest.Client
{
	class Program
	{
		const int loopDelayTime = 250;
		const string topic = "test/chat/message";
		const string exitMessage = "exit";

		static void Main (string[] args)
		{
			bool isFinishing = false;
			var config = new MqttConfiguration { Port = 55555 };
			var client = MqttClient.CreateAsync ("10.67.1.69", config).Result;
			var clientId = "XamarinClient";
			var received = "";

			client.ConnectAsync (new MqttClientCredentials (clientId)).Wait ();
			client.SubscribeAsync (topic, MqttQualityOfService.AtLeastOnce).Wait ();
			client.MessageStream.Subscribe (message => {
				if (isFinishing)
					return;
				
				var data = Encoding.UTF8.GetString (message.Payload).Split (new string[] { ":" }, StringSplitOptions.None);
				Console.WriteLine ($"Message Received from {data[0]}:{data[1]}");
				PublishAsync (client, clientId, exitMessage);

				//Send exit to server
				received = data[1];

				if (received == exitMessage)
					isFinishing = true;
			});

			Console.WriteLine ($"Client connected successfully to {client.Id}:{config.Port}");
			Console.WriteLine ($"Awaiting messages...");

			PublishAsync (client, clientId, "Connected.");

			while (received != exitMessage) {
				Thread.Sleep (loopDelayTime);
			}
			Console.WriteLine ("Shutting down... Received exit command.");
		}

		static void PublishAsync (IMqttClient client, string clientId, string message)
		{
			Console.WriteLine ($"Sending message: {message}");
			client.PublishAsync (new MqttApplicationMessage (topic, Encoding.UTF8.GetBytes ($"{clientId}:{message}")), MqttQualityOfService.AtLeastOnce).Wait();
		}
	}
}
