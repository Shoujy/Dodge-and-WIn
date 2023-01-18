using UnityEngine;
using DG.Tweening;

public class HelpAnim : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    [SerializeField] private float _scaleTo;
    [SerializeField] private float _scaleDuration;
    
    void Start()
    {
        _text.transform.DOScale(_scaleTo, _scaleDuration).SetLoops(4, LoopType.Yoyo);
        Invoke("HideHelpPanel", 4.0f);
    }

    private void OnDisable()
    {
        if (transform != null)
        {
            transform.DOKill();
        }
    }

    private void HideHelpPanel()
    {
        gameObject.SetActive(false);
    }
}
