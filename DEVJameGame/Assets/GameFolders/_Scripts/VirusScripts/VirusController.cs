using UnityEngine;

public class VirusController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;
    private float health = 100f;

    private void Update()
    {
        if(health <= 0f && !GameManager.Instance.IsGameOver)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            SoundManager.Instance.PlaySoundEffect(2);
            GameManager.Instance.Score += 10;
            HealthManager.Instance.IncreaseHealth(10f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("GameArea"))
        {
            HealthManager.Instance.TakeDamage(0.05f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }


}
