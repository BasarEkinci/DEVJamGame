using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    
    public bool IsGameStarted { get; set; }
    public bool IsGameOver { get; set; }
    
    public float Score { get; set; }
    
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
}
