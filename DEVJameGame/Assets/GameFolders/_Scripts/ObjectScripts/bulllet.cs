using System;
using UnityEngine;

public class bulllet : MonoBehaviour
{
    [SerializeField] ParticleSystem bloodEffect;
    
    private Rigidbody rigidbody;
    private float bulletSpeed = 20f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Destroy(gameObject,3f);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        VirusController virus = other.GetComponent<VirusController>();
        
        if (virus != null)
        {
            virus.TakeDamage(25f);
            Instantiate(bloodEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
