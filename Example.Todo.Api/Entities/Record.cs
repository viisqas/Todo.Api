using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Todo.Api.Entities
{
	public class Record
	{
		public int Id { get; set; }
       
		[Required]
		public string Name { get; set; }
       
		public string Description { get; set; }
       
		[Required]
		public virtual User Creator { get; set; }
       
		[ForeignKey("CreatorId")]
		public int CreatorId { get; set; }
       
		[Required]
		public DateTimeOffset CreationDate { get; set; }
       
		public DateTimeOffset EndDate { get; set; }
	}
}