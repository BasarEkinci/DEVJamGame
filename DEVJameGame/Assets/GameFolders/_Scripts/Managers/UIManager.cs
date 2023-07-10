using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform playButton;
    [SerializeField] Transform infoButton;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject startPanel;
    [SerializeField] RectTransform startText;
    [SerializeField] GameObject gamePanel;
    [SerializeField] Vector3 playPos;

    private void Start()
    {
        if(!startPanel.activeSelf)
            startPanel.SetActive(true);
        
        if(gamePanel.activeSelf)
            gamePanel.SetActive(false);
    }

    public void PlayButton()
    {
        playButton.transform.DOMove(new Vector3(-550f, -15, 0), 1f);
        infoButton.transform.DOMove(new Vector3(-550f, -15f, 0), 1f);
        startText.DOScale(Vector3.zero, 1f);
        StartCoroutine(StartGameActions());
    }

    IEnumerator StartGameActions()
    {
        yield return new WaitForSecondsRealtime(1f);
        mainCamera.transform.DOMove(playPos, 1f);
        mainCamera.transform.DORotate(Vector3.right*65f, 1f);
        gamePanel.SetActive(true);
        GameManager.Instance.IsGameStarted = true;
    }
}
