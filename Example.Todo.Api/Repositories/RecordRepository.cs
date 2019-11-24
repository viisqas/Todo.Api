using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Test.Todo.Api.DTOs;

namespace Test.Todo.Api.Repositories
{
	public class RecordRepository : IRecordRepository
	{
		private readonly TodoAppContext _db;

		public RecordRepository(TodoAppContext db)
		{
			_db = db;
		}
		
		public async Task<ICollection<Record>> GetAllRecords(int boardId)
		{
			return await _db.Records
				.Where(x => x.BoardId == boardId)
				.ToListAsync();
		}

		public async Task<Record> GetRecordById(int boardId, int recordId)
		{
			var board = await _db.Records
				.Where(r => r.BoardId == boardId && r.Id == recordId)
				.FirstOrDefaultAsync();

			return board;
		}

		public async Task<Record> AddRecord(RecordDTO record, int boardId)
		{
			var newRecord = new Record
			{
				Name = record.Name,
				Description = record.Description,
				BoardId = boardId,
				CreationDate = DateTimeOffset.Now,
				EndDate = record.EndDate, // "0001-01-01T00:00:00+00:00" returns
				CreatorId = 1 // fix to current user id
			};

			_db.Add(newRecord);
			
			await _db.SaveChangesAsync();

			return newRecord;
		}

		public async Task<Record> UpdateRecord(RecordDTO recordDto, int boardId)
		{
			var srcBoard = await _db.Records
				.Where(r => r.Id == recordDto.RecordId && r.BoardId == boardId)
				.FirstOrDefaultAsync();

			if(recordDto.Name != null)
				srcBoard.Name = recordDto.Name;
			
			if(recordDto.Description != null)
				srcBoard.Description = recordDto.Description;
			
			srcBoard.EndDate = srcBoard.EndDate;

			await _db.SaveChangesAsync();

			return srcBoard;
		}

		public async Task DeleteRecord(int boardId,int recordId)
		{
			var board = await _db.Records
				.Where(r => r.Id == recordId && r.BoardId == boardId)
				.FirstOrDefaultAsync();
			
			if (board != null)
				_db.Remove(board);

			await _db.SaveChangesAsync();
		}
	}
}