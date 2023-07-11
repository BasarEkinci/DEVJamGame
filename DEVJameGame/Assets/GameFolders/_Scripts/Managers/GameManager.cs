using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score { get; set; }
    public int HighScore = 0;
    public bool IsGameStarted { get; set; }
    public bool IsGameOver { get; set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        IsGameOver = false;
        IsGameStarted = false;
    }

    private void Update()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("High Score",HighScore);
            PlayerPrefs.Save();
        }
    }
}
