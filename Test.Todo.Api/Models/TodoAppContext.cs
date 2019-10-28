using Microsoft.EntityFrameworkCore;
using Test.Todo.Api.Models;

namespace Test.Todo.Api.Models
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