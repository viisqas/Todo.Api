using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;

namespace Test.Todo.Api.Repositories
{
	public interface IBoardRepository
	{
		Task<ICollection<Board>> GetAllBoards(); // test

		Task<ICollection<Board>> GetUsersBoards(int userId);

		Task<Board> GetUsersBoardById(int userId, int boardId);

		Task<Board> AddBoard(Board board);

		Task<Board> UpdateBoard(Board board);
		
		Task DeleteBoard(int boardId, int userId);
	}
}