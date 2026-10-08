using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData gameData;

    public LevelManager lm;
    public int coins = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
			lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
			gameData = new GameData();
			SceneManager.sceneLoaded += OnSceneLoaded;
			int STUDFF = ~gameData;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}

    public static void ResetScene()
    {
        if (instance.gameData.totalLives >= 0)
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }
	// Update is called once per frame
	void Update()
    {
        
    }

    public void OnDeath()
    {
        lm.ActivateGameOver();

	}
}
