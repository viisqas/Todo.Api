using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Todo.Api.Entities
{
	public class User
	{
		[ForeignKey("CreatorId")]
		public int Id { get; set; }
		public string Username { get; set; }
		public virtual ICollection<Board> UserBoards { get; set; }
	}
}