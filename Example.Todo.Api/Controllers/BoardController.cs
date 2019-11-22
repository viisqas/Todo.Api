using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Todo.Api.Database;
using Example.Todo.Api.Entities;
using Newtonsoft.Json;

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

		// test method
		[HttpGet]
		public async Task<ICollection<Board>> GetAllBoards()
		{
			var boards = await _boardRepository.GetAllBoards();
			return boards;
		}

		[HttpGet("user={userId}")]
		public async Task<ICollection<Board>> GetUsersBoards(int userId)
		{
			var boards = await _boardRepository.GetUsersBoards(userId);
			return boards;
		}

		[HttpGet("user={userId}/board={boardId}")]
		public async Task<Board> GetUsersBoardById(int userId, int boardId)
		{
			var board = await _boardRepository.GetUsersBoardById(userId, boardId);
			return board;
		}

		[HttpPost("addBoard")]
		public async Task<Board> CreateBoard([FromBody]Board board)
		{
			var newBoard = await _boardRepository.AddBoard(board);
			return newBoard;
		}

		[HttpPatch("update")]
		public async Task<Board> UpdateBoard2([FromBody]Board board)
		{
			var newBoard = await _boardRepository.UpdateBoard(board);
			return newBoard;
		}

		[HttpDelete("user={userId}/board={boardId}")]
		public async Task<ActionResult> DeleteBoard(int boardId, int userId)
		{
			await _boardRepository.DeleteBoard(boardId, userId);

			return Ok();
		}
	}
}