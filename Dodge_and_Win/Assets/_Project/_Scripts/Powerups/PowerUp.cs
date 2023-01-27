using UnityEngine;
using DG.Tweening;
using System.Collections;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] private float _scaleTo;
    [SerializeField] private float _scaleDuration;

    [SerializeField] private SpriteRenderer myImage;

    private int _lifeTime = 5;

    private void Awake()
    {
        myImage = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Invoke("DestroyPowerUp", _lifeTime);

        transform.DOScale(_scaleTo, _scaleDuration).SetLoops(-1, LoopType.Yoyo);

        myImage.DOFade(0.5f, 1.0f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        if (transform != null)
        {
            transform.DOKill();
            myImage.DOKill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Activate();
            Destroy(gameObject);
        }
    }
    private void DestroyPowerUp()
    {
        Destroy(gameObject);
    }

    public abstract void Activate();
    public abstract void Deactivate();
}