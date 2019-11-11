using Microsoft.EntityFrameworkCore;
using Example.Todo.Api.Entities;

namespace Example.Todo.Api.Entities
{
	public class TodoAppContext : DbContext
	{
		public TodoAppContext(DbContextOptions options)
			:base(options)
		{ }
        
		public DbSet<User> Users { get; set; }
		public DbSet<Board> Boards { get; set; }
		public DbSet<Record> Records { get; set; }
	}
}