using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Todo.Api.Database;
using Test.Todo.Api.Models;

namespace Test.Todo.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BoardController : Controller
	{
		private readonly IBoardRepository _boardRepository;
		
		public BoardController(IBoardRepository boardRepository)
		{
			_boardRepository = boardRepository;
		}
		
		[HttpGet]
		public Task<Board> GetBoard(int boardId)
		{
			var board = _boardRepository.GetBoardById(boardId);
			return board;
		}

		[HttpGet]
		public Task<ICollection<Board>> GetUsersBoards(int userId)
		{
			var boards = _boardRepository.GetUsersBoards(userId);
			return boards;
		}
	}
}