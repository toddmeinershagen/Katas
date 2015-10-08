using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace Katas.Bowling.UnitTests
{
	[TestFixture]
	public class GameTests
	{
		private Game _game;

		[SetUp]
		public void Setup()
		{
			_game = new Game();
		}


		[Test]
		public void given_a_gutter_game_when_getting_score_then_should_return_0()
		{
			
			Enumerable.Range(1, 20).ToList()
				.ForEach(index => _game.Roll(pins: 0));

			_game.Score.Should().Be(0);
		}

		[Test]
		public void given_roll_all_ones_when_getting_score_then_should_return_20()
		{

			Enumerable.Range(1, 20).ToList()
				.ForEach(index => _game.Roll(pins: 1));

			_game.Score.Should().Be(20);
		}
		[Test]
		public void One_Spare_Test()
		{

			_game.Roll(5);
			_game.Roll(5);
			_game.Roll(3);

			Enumerable.Range(1, 17).ToList()
			.ForEach(index => _game.Roll(pins: 0));
			

			_game.Score.Should().Be(16);

			RollMany(5,5,3,0);
		}

		private void RollMany(int numberOfRolls, int pins)
		{
			
		}

		private void RollMany(params int[] rolls)
		{
			
		}
	}
}
