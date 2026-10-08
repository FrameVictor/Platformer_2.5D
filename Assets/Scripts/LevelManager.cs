using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text coinsText, livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject panelGameOver;
    void Start()
    {
        UpdateCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void UpdateCoinsText()
	{
        print(GameManager.instance.gameData.totalCoins);

		coinsText.text = "x" + GameManager.instance.gameData.totalCoins;
	}

	public void UpdateLivesText()
    {
        if (GameManager.instance.gameData.totalLives >= 0)
		    livesText.text = "x" + GameManager.instance.gameData.totalLives;
		//coinsText.text = GameManager.instance;
	}
    public void MainMenuButton()
    {
    }
    public void ActivateGameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
