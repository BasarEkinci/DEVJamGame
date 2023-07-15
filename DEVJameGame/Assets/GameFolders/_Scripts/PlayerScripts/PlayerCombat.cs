using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Transform bombSpawnPos;
    [SerializeField] TMP_Text grenadeText;
    public int bombNumber = 5;

    private float throwForce = 600f;
    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted) return;

        grenadeText.text = bombNumber.ToString();
        
        if (Input.GetKeyDown(KeyCode.Q) && bombNumber > 0 )
        {
            GameObject grenade = Instantiate(bomb, bombSpawnPos.position, transform.rotation);
            SoundManager.Instance.PlaySoundEffect(4);
            bombNumber--;
            Rigidbody grenadeRb = grenade.GetComponent<Rigidbody>();
            grenadeRb.AddForce(transform.forward * (throwForce));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectableBomb") && bombNumber < 5)
        {
            SoundManager.Instance.PlaySoundEffect(3);
            bombNumber++;
            Destroy(other.gameObject);
        }
    }
}
