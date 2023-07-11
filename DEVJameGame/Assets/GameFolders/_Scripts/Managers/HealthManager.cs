using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    
    [SerializeField] Slider healthSlider;
    [SerializeField] Image handle;
    [SerializeField] List<Sprite> healthSprites;
    private float mainHealth = 100f;
    private float currentHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        currentHealth = mainHealth;
    }

    public void OnSliderChanged(float health)
    {
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        healthSlider.value = currentHealth;
        SetImage();

        if (currentHealth <= 0)
        {
            GameManager.Instance.IsGameOver = true;
            GameManager.Instance.IsGameStarted = false;
        }
    }

    private void SetImage()
    {
        if (currentHealth >= 85f)
            handle.sprite = healthSprites[0];
        else if (currentHealth < 85f && currentHealth >= 70f)
            handle.sprite = healthSprites[1];
        else if (currentHealth < 70f && currentHealth >= 60f)
            handle.sprite = healthSprites[2];
        else if (currentHealth < 60f && currentHealth >= 40f)
            handle.sprite = healthSprites[3];
        else
            handle.sprite = healthSprites[4];
    }

    public void TakeDamage(float damage)
    {
        if(GameManager.Instance.IsGameStarted)
        {
            currentHealth -= damage;
            float newHealth = Mathf.Clamp(currentHealth, 0f, 100f);
            currentHealth = newHealth;
        }
    }
    
    public void IncreaseHealth(float incHealt)
    {
        currentHealth += incHealt;
        float newHealth = Mathf.Clamp(currentHealth, 0f, 100f);
        currentHealth = newHealth;
    }
}
