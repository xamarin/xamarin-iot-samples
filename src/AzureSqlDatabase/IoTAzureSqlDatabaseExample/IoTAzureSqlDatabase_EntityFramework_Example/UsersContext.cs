using System.Data.Entity;

namespace IoTAzureSqlDatabase.EntityFrameworkExample
{
	public class UsersContext : DbContext
	{
		public UsersContext() : base("name=XamarinDBConnectionString")
		{
		}
		public DbSet<User> Users { get; set; }
	}
}
