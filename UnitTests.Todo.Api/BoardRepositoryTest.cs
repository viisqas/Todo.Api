using System;
using System.Collections.Generic;
using Example.Todo.Api.Entities;
using Moq;
using Test.Todo.Api.Repositories;
using Xunit;

namespace UnitTests.Todo.Api
{
	public class BoardRepositoryTest
	{
		private readonly Mock<IBoardRepository> _boardRepository;

		public BoardRepositoryTest()
		{
			_boardRepository = new Mock<IBoardRepository>();
		}

		[Fact]
		public void GetBoard_ShouldReturnBoard()
		{
			var board = new Board {Id = 1, Name = "First Board", CreatorId = 1, Description = "My first board desc"};
			_boardRepository.Setup(x => x.GetUsersBoardById(1, 1));
		}
		
		[Fact]
		public void AddBoard_ShouldAddBoardOnce()
		{
			var board = new Board {Id = 1, Name = "First Board", CreatorId = 1, Description = "My first board desc"};
			_boardRepository.Setup(x => x.AddBoard(board));

			_boardRepository.Object.AddBoard(board);
			
			_boardRepository.Verify(x => x.AddBoard(board), Times.Once());
		}

		private List<Board> GetTestBoards()
		{
			var testBoards = new List<Board>
			{
				new Board {Id = 1, Name = "First Board", CreatorId = 1, Description = "My first board desc"},
				new Board {Id = 2, Name = "Second Board", CreatorId = 1, Description = "My second board desc"},
				new Board {Id = 3, Name = "Third Board", CreatorId = 1, Description = "My third board desc"}
			};

			return testBoards;
		}
	}
}