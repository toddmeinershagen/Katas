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
			RollMultipleSameNumberPins(0, 20);

			_game.Score.Should().Be(0);
		}

		[Test]
		public void given_roll_all_ones_when_getting_score_then_should_return_20()
		{

			RollMultipleSameNumberPins(1, 20);

			_game.Score.Should().Be(20);
		}

		[Test]
		public void One_Spare_Test()
		{

			Roll(5,5,3);
			RollMultipleSameNumberPins(0, 17);	

			_game.Score.Should().Be(16);

		}

		[Test]
		public void roll_one_strike_and_two_random_rolls_and_all_other_gutter_balls_should_be_10()
		{
			Roll(10);
			Roll(5,3);
			RollMultipleSameNumberPins(0,17);
			_game.Score.Should().Be(26);
		}

		private void RollMultipleSameNumberPins(int pins, int times)
		{

			for (var i = 0; i < times; i++)
			{
				Roll(pins);
			}
		}

		private void Roll(params int[] pins)
		{
			foreach (var pin in pins)
			{
				_game.Roll(pin);
			}
			
		}
		
	}
}


