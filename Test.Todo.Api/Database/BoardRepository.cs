using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Todo.Api.Models;

namespace Test.Todo.Api.Database
{
	public class BoardRepository : IBoardRepository
	{
		private readonly TodoAppContext _db;

		public BoardRepository(TodoAppContext db)
		{
			_db = db;
		}
		
		public async Task<Board> GetBoardById(int boardId)
		{
			var board = await _db.Boards.FindAsync(boardId);
			return board;
		}

		public async Task<ICollection<Board>> GetUsersBoards(int userId)
		{
			var boards = await _db.Boards.Where(b => b.Creator.Id == userId).ToListAsync();
			return boards;
		}

	}
}