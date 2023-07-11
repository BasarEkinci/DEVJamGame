using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
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
        Debug.Log(IsGameStarted);
    }
}
