using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData gameData;

    public int coins = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
            gameData = new GameData();
            int STUDFF = ~gameData;
        }
        else
        {
            Destroy(gameObject);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {

    }
}
