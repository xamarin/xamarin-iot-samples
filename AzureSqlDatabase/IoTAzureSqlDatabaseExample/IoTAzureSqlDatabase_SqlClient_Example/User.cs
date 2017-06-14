using System;
namespace IoTAzureSqlDatabase.EntityFrameworkExample
{
	class User
	{
		public int Id {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[User: Id={0}, Name={1}]", Id, Name);
		}
	}
}
