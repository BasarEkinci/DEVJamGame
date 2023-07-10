using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public bool IsGameStarted { get; set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        IsGameStarted = false;
    }

    private void Update()
    {
        Debug.Log(IsGameStarted);
    }
}
