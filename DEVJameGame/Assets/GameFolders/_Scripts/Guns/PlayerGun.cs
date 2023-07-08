using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnTransform;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, spawnTransform.position, transform.rotation);
        }       
    }
}
