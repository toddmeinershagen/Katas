using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace Katas.Bowling.UnitTests
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void given_a_gutter_game_when_getting_score_then_should_return_0()
		{
			var game = new Game();
			
			Enumerable.Range(1, 20).ToList()
				.ForEach(index => game.Roll(0));

			game.Score.Should().Be(0);
		}
	}
}
