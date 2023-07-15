using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform playButton;
    [SerializeField] Transform infoButton;
    [SerializeField] RectTransform startText;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject spawnManager;
    [SerializeField] VolumeProfile globalVOlume;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Vector3 playPos;

    
    private void Start()
    {
        if(spawnManager.activeSelf)
            spawnManager.SetActive(false);
        
        if(!startPanel.activeSelf)
            startPanel.SetActive(true);
        
        if(gamePanel.activeSelf)
            gamePanel.SetActive(false);
        
        globalVOlume.TryGet(out DepthOfField depthOfField);
        if (!depthOfField.mode.overrideState)
            depthOfField.mode.overrideState = true;
        
        if(gameOverPanel.activeSelf)
            gameOverPanel.SetActive(false);
    }
    
    private void Update()
    {
        if(GameManager.Instance.IsGameOver)
        {
            gameOverPanel.SetActive(true);
            scoreText.text = "Score\n" + GameManager.Instance.Score;
            SoundManager.Instance.StopSound(6);
            SoundManager.Instance.PlaySoundEffect(5);
            spawnManager.SetActive(false);
        }
    }

    public void PlayButton()
    {
        playButton.transform.DOMove(new Vector3(-550f, -15, 0), 1f);
        infoButton.transform.DOMove(new Vector3(-550f, -15f, 0), 1f);
        startText.DOScale(Vector3.zero, 1f);
        SoundManager.Instance.StopSound(7);
        SoundManager.Instance.PlaySound(6);
        StartCoroutine(StartGameActions());
    }

    public void RestartButton()
    {
        GameManager.Instance.IsGameOver = false;
        GameManager.Instance.IsGameStarted = false;
        gamePanel.SetActive(false);
        SceneManager.LoadScene(0);
        startPanel.SetActive(true);
    }
    
    public void SocialsButton()
    {
        Application.OpenURL("https://linktr.ee/basarekinci");
    }
    
    IEnumerator StartGameActions()
    {
        yield return new WaitForSecondsRealtime(1f);
        globalVOlume.TryGet(out DepthOfField depthOfField);
        depthOfField.mode.overrideState = false;
        mainCamera.transform.DOMove(playPos, 1f);
        mainCamera.transform.DORotate(Vector3.right*65f, 1f);
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        spawnManager.SetActive(true);
        GameManager.Instance.IsGameStarted = true;
    }
}
