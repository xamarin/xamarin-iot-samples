using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IoTAzureSqlDatabase.EntityFrameworkExample
{
	class Program
	{
		static void Main ()
		{
			var builder = new SqlConnectionStringBuilder {
				["Server"] = "yourserverhere.database.windows.net",
				["User ID"] = "youruserhere",
				["Password"] = "yourpasswordhere",
				["Database"] = "yourdatabasehere"
			};

			try {
				//Create a SqlConnection from the provided connection string
				using (var connection = new SqlConnection (builder.ToString ())) {
					//Begin to formulate the command
					var command = new SqlCommand () {
						Connection = connection,
						CommandTimeout = 10,
						CommandType = System.Data.CommandType.Text
					};

					//Open connection to database
					connection.Open ();

					command.GetUsers ().ConsoleOutput ();

					var queries = new string [] {
						"DELETE FROM dbo.Xamarin",
						"INSERT INTO dbo.Xamarin (Id, Name) VALUES (1, 'Miguel')",
						"INSERT INTO dbo.Xamarin (Id, Name) VALUES (2, 'Nat')",
						"INSERT INTO dbo.Xamarin (Id, Name) VALUES (3, 'Mikayla')"
					};
					command.ExecuteNonQuery (queries);
					command.GetUsers ().ConsoleOutput ();

					command.ExecuteNonQuery ("DELETE FROM dbo.Xamarin");

					Console.WriteLine ("\nPress any key to continue");
					Console.ReadLine ();
				}
			} catch (Exception ex) {
				Console.WriteLine ("An error occured: " + ex.Message);
			}
		}
	}
}
