using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionEffect;

    private float explosionRadius = 15f;
    private float explosionForce = 200f;
    private float delay = 3f;
    
    private float countdown;
    private bool hasExploded;
    private void Awake()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
            Destroy(gameObject);
        }
    }
    
    private void Explode()
    {
        Instantiate(explosionEffect, transform.position + Vector3.one, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider nearbyObject in colliders)
        {
            VirusController virus = nearbyObject.GetComponent<VirusController>();
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && virus != null)
            {
                virus.TakeDamage(50f);
                rb.AddExplosionForce(explosionForce,transform.position,explosionRadius);
            }
        }
    }
}
