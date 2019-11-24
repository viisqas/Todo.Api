using System;
using System.Collections.Generic;
using Example.Todo.Api.Entities;
using Xunit;

namespace UnitTests.Todo.Api
{
	public class UnitTest1
	{
		[Fact]
		public void GetAllBoards_ShouldReturnsAllBoards()
		{
			var testBoards = GetTestBoards();
			
		}

		private List<Board> GetTestBoards()
		{
			var testBoards = new List<Board>();
			testBoards.Add(new Board {Id = 1, Name = "First Board", CreatorId = 1, Description = "My first board desc"});
			testBoards.Add(new Board {Id = 2, Name = "Second Board", CreatorId = 1, Description = "My second board desc"});
			testBoards.Add(new Board {Id = 3, Name = "Third Board", CreatorId = 1, Description = "My third board desc"});

			return testBoards;
		}
	}
}