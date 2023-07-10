using UnityEngine;
using Random = UnityEngine.Random;

public class VirusController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;
    private float health = 100f;

    private void Update()
    {
        if(health <= 0f)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
