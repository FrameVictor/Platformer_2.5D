using UnityEngine;

public struct GameData
{
	private int _lives;
	public int totalLives
	{
		get => _lives;
		set
		{
			_lives = value;
			if (value < 0)
				GameManager.instance.OnDeath();
		}
	}

	public int totalCoins;


	public static int operator ~(GameData operand)
	{

		GameManager.instance.gameData.totalLives = 3;
		GameManager.instance.gameData.totalCoins = 0;

		return 1;
	}

}