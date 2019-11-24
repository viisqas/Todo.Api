using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.Todo.Api.Entities;
using Test.Todo.Api.Repositories;

namespace Test.Todo.Api.Controllers
{
	[ApiController]
	[Route("api")]
	public class BoardController : Controller
	{
		private readonly IBoardRepository _boardRepository;
		
		public BoardController(IBoardRepository boardRepository)
		{
			_boardRepository = boardRepository;
		}

		/// <summary>
		/// Returns all existing boards in the database (test method)
		/// </summary>
		[HttpGet]
		public async Task<ActionResult> GetAllBoards()
		{
			var boards = await _boardRepository.GetAllBoards();

			if (boards == null)
				return NotFound();
			
			return Ok(boards);
		}

		/// <summary>
		/// Returns all boards belonging to a specific user
		/// </summary>
		[HttpGet("user={userId}/boards")]
		public async Task<ActionResult> GetUsersBoards(int userId)
		{
			var boards = await _boardRepository.GetUsersBoards(userId);

			if (boards == null)
				return NotFound();

			return Ok(boards);
		}

		/// <summary>
		/// Returns one specific board belonging to a specific user
		/// </summary>
		[HttpGet("user={userId}/boards/{boardId}")]
		public async Task<ActionResult> GetUsersBoardById(int userId, int boardId)
		{
			var board = await _boardRepository.GetUsersBoardById(userId, boardId);

			if (board == null)
				return NotFound();
			
			return Ok(board);
		}

		/// <summary>
		/// Create board
		/// </summary>
		[HttpPost("createBoard")]
		public async Task<ActionResult> CreateBoard([FromBody]Board board)
		{
			var newBoard = await _boardRepository.AddBoard(board);
			
			return Ok(newBoard);
		}

		/// <summary>
		/// Update specific board (description or name)
		/// </summary>
		[HttpPatch("updateBoard")]
		public async Task<ActionResult> UpdateBoard([FromBody]Board board) //only with userId
		{
			var newBoard = await _boardRepository.UpdateBoard(board);
			
			return Ok(newBoard);
		}

		/// <summary>
		/// Delete a specific board
		/// </summary>
		[HttpDelete("user={userId}/boards/{boardId}")]
		public async Task<ActionResult> DeleteBoard(int boardId, int userId)
		{
			await _boardRepository.DeleteBoard(boardId, userId);

			return Ok("board deleted successfully");
		}
	}
}