using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Katas.Bowling
{
	public class Game
	{
		private readonly List<int> _rolls = new List<int>();

		public void Roll(int pins)
		{
			_rolls.Add(pins);

		}

		public int Score
		{
			get
			{
				var score = 0;

				for (int i = 0; i < 10; i++)
				{
					var frameIndex = i*2;
					var frameScore = _rolls[frameIndex] + _rolls[frameIndex + 1];

					if (frameScore == 10)
					{
						frameScore += _rolls[frameIndex + 2];
					}

					score += frameScore;
				}

				return score;
			}
		}
	}


}
