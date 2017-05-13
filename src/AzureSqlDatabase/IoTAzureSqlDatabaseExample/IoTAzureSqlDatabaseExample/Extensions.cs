using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IoTAzureSqlDatabaseExample
{
	static class Extensions
	{
		public static List<User> GetUsers (this SqlDataReader sender)
		{
			var users = new List<User> ();
			while (sender.Read ()) {
				users.Add (new User () { Id = sender.GetInt32 (0), Name = sender.GetString (1) });
			}
			return users;
		}

		public static int ExecuteNonQuery (this SqlCommand command, string query)
		{
			command.CommandText = query;
			return command.ExecuteNonQuery ();
		}

		public static void ExecuteNonQuery (this SqlCommand command, string[] queries)
		{
			foreach (var query in queries) {
				ExecuteNonQuery (command, query);
			}
		}

		public static List<User> GetUsers (this SqlCommand command)
		{
			command.CommandText = "SELECT * FROM dbo.Xamarin";
			using (var reader = command.ExecuteReader ()) {
				return reader.GetUsers ();
			}
		}

		public static void ConsoleOutput (this List<User> users)
		{
			foreach (var user in users) {
				Console.WriteLine (user);
			}
			Console.WriteLine ($"Total {users.Count} users.");
		}
	}
}
