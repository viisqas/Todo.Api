using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Test.Todo.Api.DTOs;
using Test.Todo.Api.Repositories;

namespace Test.Todo.Api.Controllers
{
	[ApiController]
	[Route("api/boards/")]
	public class RecordController : Controller
	{
		private readonly IRecordRepository _recordRepository;
		
		public RecordController(IRecordRepository recordRepository)
		{
			_recordRepository = recordRepository;
		}

		[HttpGet("{boardId}")]
		public async Task<ActionResult> GetAllBoardRecords(int boardId)
		{
			var boards = await _recordRepository.GetAllRecords(boardId);

			if (boards == null)
				return NotFound();
			
			return Ok(boards);
		}

		[HttpGet("{boardId}/records/{recordId}")]
		public async Task<ActionResult> GetRecordById(int boardId, int recordId)
		{
			var board = await _recordRepository.GetRecordById(boardId, recordId);

			if (board == null)
				return NotFound();

			return Ok(board);
		}

		[HttpPost("{boardId}/createRecord")]
		public async Task<ActionResult> CreateRecord([FromBody]RecordDTO record, int boardId)
		{
			var newBoard = await _recordRepository.AddRecord(record, boardId);

			if (newBoard == null)
				return Conflict();
			
			return Ok(newBoard);
		}

		[HttpPatch("{boardId}/updateRecord")]
		public async Task<ActionResult> UpdateRecord([FromBody] RecordDTO recordDto, int boardId)
		{
			var updatedBoard = await _recordRepository.UpdateRecord(recordDto, boardId);
			
			return Ok(updatedBoard);
		}

		[HttpDelete("{boardId}/records/{recordId}")]
		public async Task<ActionResult> DeleteRecord(int boardId, int recordId)
		{
			await _recordRepository.DeleteRecord(boardId, recordId);

			return Ok("record deleted successfully");
		}
	}
}