namespace Katas.Bowling
{
	public interface IGame
	{
		void Roll(int pins);
		int Score { get; }
	}
}