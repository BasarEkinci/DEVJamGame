using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnTransform;
    void Update()
    {
        if(!GameManager.Instance.IsGameStarted) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, spawnTransform.position, transform.rotation);
        }       
    }
}
