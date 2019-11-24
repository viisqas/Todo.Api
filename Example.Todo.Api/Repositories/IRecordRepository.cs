using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Todo.Api.Entities;
using Test.Todo.Api.DTOs;

namespace Test.Todo.Api.Repositories
{
	public interface IRecordRepository
	{
		Task<ICollection<Record>> GetAllRecords(int boardId);

		
		Task<Record> GetRecordById(int boardId, int recordId);
		
		Task<Record> AddRecord(RecordDTO record, int boardId);

		Task<Record> UpdateRecord(RecordDTO recordDto, int boardId);

		Task DeleteRecord(int boardId, int recordId);
	}
}