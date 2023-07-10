using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] private Transform bombSpawnPos;

    private float throwForce = 600f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject grenade = Instantiate(bomb, bombSpawnPos.position, transform.rotation);
            Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
            grenadeRb.AddForce(transform.forward * (throwForce));
        }
    }
}
