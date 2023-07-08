using DG.Tweening;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float fireRate = 0.4f;
    private float nextFire;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            transform.DORotate(Vector3.right * 45, 0.2f,RotateMode.LocalAxisAdd).SetLoops(2, LoopType.Yoyo);
            nextFire = Time.time + fireRate;
        }
    }
}
