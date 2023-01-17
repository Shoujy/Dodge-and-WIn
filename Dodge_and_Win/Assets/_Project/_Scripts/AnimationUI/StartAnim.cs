using UnityEngine;
using DG.Tweening;

public class StartAnim : MonoBehaviour
{
    [SerializeField] private float _scaleTo;
    [SerializeField] private float _scaleDuration;
    void Start()
    {
        transform.DOScale(_scaleTo, _scaleDuration).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        if (transform != null)
        {
            transform.DOKill();
        }
    }
}
