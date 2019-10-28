using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Todo.Api.Models
{
	public class User
	{
		[ForeignKey("CreatorId")]
		public int Id { get; set; }
		public string Username { get; set; }
		public virtual ICollection<Board> UserBoards { get; set; }
	}
}