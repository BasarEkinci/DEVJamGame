using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform playButton;
    [SerializeField] Transform infoButton;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject startPanel;
    [SerializeField] RectTransform startText;
    [SerializeField] GameObject gamePanel;
    [SerializeField] Vector3 playPos;
    [SerializeField] VolumeProfile globalVOlume;
    
    private void Start()
    {
        if(!startPanel.activeSelf)
            startPanel.SetActive(true);
        
        if(gamePanel.activeSelf)
            gamePanel.SetActive(false);
        
        globalVOlume.TryGet(out DepthOfField depthOfField);
        if (!depthOfField.mode.overrideState)
            depthOfField.mode.overrideState = true;
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
        globalVOlume.TryGet(out DepthOfField depthOfField);
        depthOfField.mode.overrideState = false;
        mainCamera.transform.DOMove(playPos, 1f);
        mainCamera.transform.DORotate(Vector3.right*65f, 1f);
        gamePanel.SetActive(true);
        GameManager.Instance.IsGameStarted = true;
    }
}
