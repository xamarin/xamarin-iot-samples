using System;
using System.Threading;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace AMQ
{
	class MainClass
	{
		static void Main (string[] args)
		{
			string address = "amqp://guest:guest@10.67.1.69:5672";
			if (args.Length > 0) {
				address = args[0];
			}
			Console.WriteLine ("Running request client...");
			new Client (address).Run ();
		}

		class Client
		{
			readonly string address;
			string replyTo;
			Connection connection;
			Session session;
			ReceiverLink receiver;
			SenderLink sender;
			int offset;

			public Client (string address)
			{
				this.address = address;
				this.replyTo = "client-" + Guid.NewGuid ().ToString ();
			}

			public void Run ()
			{
				while (true) {
					try {
						this.Cleanup ();
						this.Setup ();

						this.RunOnce ();

						this.Cleanup ();
						break;
					}
					catch (Exception exception) {
						Console.WriteLine ("Reconnect on exception: " + exception.Message);

						Thread.Sleep (5000);
					}
				}
			}

			void Setup ()
			{
				this.connection = new Connection (new Address (address));
				this.session = new Session (connection);

				Attach recvAttach = new Attach () {
					Source = new Source () { Address = "request_processor" },
					Target = new Target () { Address = this.replyTo }
				};

				this.receiver = new ReceiverLink (session, "request-client-receiver", recvAttach, null);
				this.receiver.Start (300);
				this.sender = new SenderLink (session, "request-client-sender", "request_processor");
			}

			void Cleanup ()
			{
				var temp = Interlocked.Exchange (ref this.connection, null);
				if (temp != null) {
					temp.Close ();
				}
			}

			void RunOnce ()
			{
				Message request = new Message ("Raspberry are you listen me? " + this.offset);
				request.Properties = new Properties () { MessageId = "command-request", ReplyTo = this.replyTo };
				request.ApplicationProperties = new ApplicationProperties ();
				request.ApplicationProperties["offset"] = this.offset;
				sender.Send (request, null, null);

				Console.WriteLine ($"Sending request to Raspberry...{Environment.NewLine}{Environment.NewLine}Properties:{Environment.NewLine}{request.Properties}{Environment.NewLine}{Environment.NewLine}Body Message:{Environment.NewLine}{request.Body}{Environment.NewLine}{Environment.NewLine}");

				while (true) {
					Message response = receiver.Receive ();
					receiver.Accept (response);
					Console.WriteLine ("Received response: {0} body {1}", response.Properties, response.Body);

					if (string.Equals ("done", response.Body)) {
						break;
					}

					this.offset = (int)response.ApplicationProperties["offset"];
				}
			}
		}
	}
}
