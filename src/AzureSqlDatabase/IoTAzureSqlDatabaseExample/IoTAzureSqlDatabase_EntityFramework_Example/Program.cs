using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IoTAzureSqlDatabase.EntityFrameworkExample
{
	class Program
	{
		static void Main()
		{
			var context = new UsersContext();

			Console.WriteLine("Creating table if not created...");
			context.Database.CreateIfNotExists();

			Console.WriteLine("Removing posible users...");
			context.Database.ExecuteSqlCommand("TRUNCATE TABLE XamarinDB.dbo.Users");
			context.SaveChanges();

			Console.WriteLine($"Database has {context.Users.Local.Count} users.");

			Console.WriteLine("Adding users...");
			context.Users.Add(new User { Id = 1, Name = "Miguel" });
			context.Users.Add(new User { Id = 2, Name = "Nat" });
			context.Users.Add(new User { Id = 3, Name = "Mikayla" });
			context.SaveChanges();

			Console.WriteLine($"Database has {context.Users.Local.Count} users:");
			foreach (var employee in context.Users)
				Console.WriteLine($"{employee.Id} = {employee.Name}" );

			Console.WriteLine("Finished.");
		}
	}
}
