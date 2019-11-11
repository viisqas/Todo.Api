using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;
using Example.Todo.Api.Entities;

namespace Example.Todo.Api.Database
{
	public interface IBoardRepository
	{
		Task<ICollection<Board>> GetAllBoards();

		Task<ICollection<Board>> GetUsersBoards(int userId);

		Task<Board> GetUsersBoardById(int userId, int boardId);
	}
}