using UnityEngine;
using Random = UnityEngine.Random;

public class VirusController : MonoBehaviour
{
    private float health = 100f;

    private Rigidbody virusRb;

    private void Awake()
    {
        virusRb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //virusRb.velocity = new Vector3(Random.Range(5, 15), 0, Random.Range(5, 15));
    }

    private void Update()
    {
        if(health <= 0f)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
