using System.Collections.Generic;

namespace Katas.Bowling
{
	public class Game : IGame
	{
		private readonly List<int> _rolls = new List<int>();


		public void Roll(int pins)
		{
			if (RolledAStrike(pins))
			{

				if (_rolls.Count < 20)
				{
					_rolls.Add(pins);
					_rolls.Add(0);
				}
				else
				{
					_rolls.Add(0);
				}
			}
			else
			{
				_rolls.Add(pins);
			}
		}

		private bool RolledAStrike(int pins)
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

				for (var i = 0; i < _rolls.Count/2; i++)
				{
					var frameIndex = i*2;
					var frameScore = _rolls[frameIndex] + _rolls[frameIndex + 1];
					
					if (IsStrike(frameIndex))
					{
						score += frameScore + GetStrikeBonus(frameIndex);
						if (frameIndex < 18 && IsStrike(frameIndex + 2))
						{
							score += GetStrikeBonus(frameIndex + 2);
						}
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
			if (frameIndex > 18) return 0;
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
