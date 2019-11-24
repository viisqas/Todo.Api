using System;

namespace Test.Todo.Api.DTOs
{
	public class RecordDTO
	{
		public int RecordId { get; set; }
		
		public string Name { get; set; }
		
		public string Description { get; set; }
		
		public DateTimeOffset EndDate { get; set; }
	}
}