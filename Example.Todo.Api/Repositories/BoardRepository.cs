using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Test.Todo.Api.Repositories
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
			var boards = await _db.Boards
				.Where(b => b.CreatorId == userId)
				.ToListAsync();
			
			return boards;
		}

		public async Task<Board> GetUsersBoardById(int userId, int boardId)
		{
			var board = await _db.Boards
				.FirstOrDefaultAsync(b => b.CreatorId == userId && b.Id == boardId);
			return board;
		}
		
		public async Task<Board> AddBoard(Board board)
		{
			var newBoard = new Board
			{
				Name = board.Name,
				Description = board.Description,
				CreatorId = board.CreatorId
			};

			_db.Add(newBoard);

			await _db.SaveChangesAsync();

			return newBoard;
		}
		
		public async Task<Board> UpdateBoard(Board board)
		{
			var srcBoard = await _db.Boards
				.Where(b => b.Id == board.Id && b.CreatorId == board.CreatorId)
				.FirstOrDefaultAsync();
			
			if(board.Name != null)
				srcBoard.Name = board.Name;
			if (board.Description != null)
				srcBoard.Description = board.Description;

			await _db.SaveChangesAsync();
			
			return srcBoard;
		}

		public async Task DeleteBoard(int boardId, int userId)
		{
			var board = await _db.Boards
				.Where(b => b.Id == boardId && b.CreatorId == userId)
				.FirstOrDefaultAsync();
			
			if (board != null)
				_db.Remove(board);

			await _db.SaveChangesAsync();
		}
	}
}