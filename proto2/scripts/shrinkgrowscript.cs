using DG.Tweening;
using UnityEngine;

public class shrinkgrowscript : MonoBehaviour
{
    public Vector3 endValue;
    public float duration;
    public Ease ease;
    public LoopType loopType;
    public float delay;

    void Start()
    {
        this.transform.DOScale(this.transform.localScale+endValue,duration).SetEase(ease).SetLoops(-1,loopType).SetDelay(delay);   
    }
}
