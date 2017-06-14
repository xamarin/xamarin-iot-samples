using System;
using System.ComponentModel.DataAnnotations;

namespace IoTAzureSqlDatabase.EntityFrameworkExample
{
	public class User
	{
		[Key]
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
