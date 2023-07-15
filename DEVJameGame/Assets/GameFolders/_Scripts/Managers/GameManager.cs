using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameStarted { get; set; }
    public bool IsGameOver { get; set; }

    private float highScore;
    private float score = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        IsGameOver = false;
        IsGameStarted = false;
        SoundManager.Instance.PlaySound(7);
    }

    private void Update()
    {
        if(!IsGameOver && IsGameStarted)
            score += (Time.time / 10f) * Time.deltaTime;
        
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString("0");
            PlayerPrefs.SetFloat("High Score",highScore);
            PlayerPrefs.Save();
        }
        scoreText.text ="Score: " + score.ToString("0");
    }
}
