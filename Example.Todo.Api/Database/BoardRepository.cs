using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Example.Todo.Api.Entities;

namespace Example.Todo.Api.Database
{
	public class BoardRepository : IBoardRepository
	{
		private readonly TodoAppContext _db;

		public BoardRepository(TodoAppContext db)
		{
			_db = db;
		}

		public async Task<ICollection<Board>> GetAllBoards()
		{
			var boards = await _db.Boards.ToListAsync();
			return boards;
		}

		public async Task<ICollection<Board>> GetUsersBoards(int userId)
		{
			var boards = await _db.Boards.Where(b => b.Creator.Id == userId).ToListAsync();
			return boards;
		}

		public async Task<Board> GetUsersBoardById(int userId, int boardId)
		{
			var board = await _db.Boards.FirstOrDefaultAsync(b => b.CreatorId == userId && b.Id == boardId);
			return board;
		}
	}
}