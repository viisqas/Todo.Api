using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Todo.Api.Entities
{
	public class Board
	{
		[ForeignKey("BoardId")]
		public int Id { get; set; }
		
		[Required]
		public string Name { get; set; }
		
		public string Description { get; set; }
		
		public virtual ICollection<Record> Records {get; set; }
		
		[ForeignKey("CreatorId")]
		public int CreatorId { get; set; }
	}
}