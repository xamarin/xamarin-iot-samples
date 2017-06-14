using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using Amqp.Listener;
using Amqp.Types;

namespace AMQPServerIoTExample
{
	class MainClass
	{
		static void Main (string [] args)
		{
			string address = "amqp://guest:guest@10.67.1.82:5672";
			if (args.Length > 0) {
				address = args [0];
			}

			Uri addressUri = new Uri (address);
			ContainerHost host = new ContainerHost (new Uri [] { addressUri }, null, addressUri.UserInfo);
			host.Open ();
			Console.WriteLine ("Raspberry Pi host is listening on {0}:{1}", addressUri.Host, addressUri.Port);

			string requestProcessor = "request_processor";
			host.RegisterRequestProcessor (requestProcessor, new RequestProcessor ());
			Console.WriteLine ("Request processor is registered on {0}", requestProcessor);

			Console.WriteLine ("Press enter key to exit...");
			Console.ReadLine ();

			host.Close ();
		}

		class RequestProcessor : IRequestProcessor
		{
			int offset;

			void IRequestProcessor.Process (RequestContext requestContext)
			{
				Console.WriteLine ("Received a request: " + requestContext.Message.Body);
				var task = this.ReplyAsync (requestContext);
			}

			async Task ReplyAsync (RequestContext requestContext)
			{
				if (this.offset == 0) {
					this.offset = (int)requestContext.Message.ApplicationProperties ["offset"];
				}

				var board = Raspberry.Board.Current;
				var subject = $"Model: {board.Model.ToString ()};ProcessorName:{board.ProcessorName};SerialNumber:{board.SerialNumber}";

				while (this.offset < 1000) {
					try {
						Message response = new Message ("Yes I am listening you!!!! " + this.offset);
						response.ApplicationProperties = new ApplicationProperties ();
						response.ApplicationProperties ["offset"] = this.offset;
						response.Properties = new Properties () {
							Subject = subject
						};
						requestContext.ResponseLink.SendMessage (response);
						this.offset++;
					} catch (Exception exception) {
						Console.WriteLine ("Exception: " + exception.Message);
						if (requestContext.State == ContextState.Aborted) {
							Console.WriteLine ("Request is aborted. Last offset: " + this.offset);
							return;
						}
					}

					await Task.Delay (1000);
				}

				requestContext.Complete (new Message ("done"));
			}
		}
	}
}
