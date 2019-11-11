using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Todo.Api.Database;
using Example.Todo.Api.Entities;

namespace Test.Todo.Api.Controllers
{
	[ApiController]
	[Route("boards")]
	public class BoardController : Controller
	{
		private readonly IBoardRepository _boardRepository;
		
		public BoardController(IBoardRepository boardRepository)
		{
			_boardRepository = boardRepository;
		}

		[HttpGet]
		public async Task<ICollection<Board>> GetAllBoards()
		{
			var boards = await _boardRepository.GetAllBoards();
			return boards;
		}

		// IT WORKS
		[HttpGet("users/{userId}")]
		public async Task<ICollection<Board>> GetUsersBoards(int userId)
		{
			var boards = await _boardRepository.GetUsersBoards(userId);
			return boards;
		}

		[HttpGet("users/{userId}/{boardId}")]
		public async Task<Board> GetUsersBoardById(int userId, int boardId)
		{
			var board = await _boardRepository.GetUsersBoardById(userId, boardId);
			return board;
		}
	}
}