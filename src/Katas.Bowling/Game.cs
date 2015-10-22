using System.Collections.Generic;

namespace Katas.Bowling
{
	public class Game
	{
		private readonly List<int> _rolls = new List<int>();


		public void Roll(int pins)
		{
			if (IsRollAStrike(pins))
			{
				_rolls.Add(pins);
				_rolls.Add(0);
			}
			else
			{
				_rolls.Add(pins);
			}
		}

		private bool IsRollAStrike(int pins)
		{
			return (pins == 10) && (IsFirstRollOfTheFrame());
		}

		private bool IsFirstRollOfTheFrame()
		{
			return _rolls.Count%2 == 0;
		}

		public int Score
		{
			get
			{
				var score = 0;

				for (var i = 0; i < 10; i++)
				{
					var frameIndex = i*2;
					var frameScore = _rolls[frameIndex] + _rolls[frameIndex + 1];
					
					if (IsStrike(frameIndex))
					{
						score += frameScore + GetStrikeBonus(frameIndex);
					}
					else if (IsSpare(frameIndex))
					{
						score += frameScore + (GetSpareBonus(frameIndex));
					}
					else
					{
						score += frameScore;
					}
				}

				return score;
			}
		}

		private int GetSpareBonus(int frameIndex)
		{
			return _rolls[frameIndex + 2];
		}

		private int GetStrikeBonus(int frameIndex)
		{
			return _rolls[frameIndex + 2] + _rolls[frameIndex + 3];
		}

		private bool IsSpare(int frameIndex)
		{
			return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
		}

		private bool IsStrike(int frameIndex)
		{
			return _rolls[frameIndex] == 10;
		}
	}


}
