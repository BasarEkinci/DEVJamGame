using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Transform bombSpawnPos;

    public int bombNumber = 5;

    private float throwForce = 600f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && bombNumber >= 0)
        {
            GameObject grenade = Instantiate(bomb, bombSpawnPos.position, transform.rotation);
            bombNumber--;
            Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
            grenadeRb.AddForce(transform.forward * (throwForce));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectableBomb") && bombNumber < 5)
        {
            bombNumber++;
        }
    }
}
