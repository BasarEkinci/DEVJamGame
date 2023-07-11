using System.Collections;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;
    private float health = 100f;

    private void Update()
    {
        if(health <= 0f)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            HealthManager.Instance.IncreaseHealth(10f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("GameArea"))
        {
            HealthManager.Instance.TakeDamage(0.04f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }


}
