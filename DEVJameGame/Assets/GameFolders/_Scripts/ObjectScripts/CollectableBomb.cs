using DG.Tweening;
using UnityEngine;

public class CollectableBomb : MonoBehaviour
{
    [SerializeField] PlayerCombat player;
    private void OnEnable()
    {
        transform.DORotate(Vector3.up * 360f, 2f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Incremental).SetEase(Ease.OutSine);
    }
}
