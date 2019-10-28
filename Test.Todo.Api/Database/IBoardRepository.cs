using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Todo.Api.Models;

namespace Test.Todo.Api.Database
{
	public interface IBoardRepository
	{
		Task<Board> GetBoardById(int boardId);

		Task<ICollection<Board>> GetUsersBoards(int userId);
	}
}