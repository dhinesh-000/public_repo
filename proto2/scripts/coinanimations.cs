using DG.Tweening;
using UnityEngine;

public class coinanimations : MonoBehaviour
{
    public Ease ease;
    public LoopType loopType;
    public float scaleEndValue;
    public float timetocomplete;
    void Start()
    {
        this.transform.DOLocalRotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360).SetRelative(true).SetEase(ease).SetLoops(-1,loopType);

        this.transform.DOScale(new Vector3(scaleEndValue,scaleEndValue,scaleEndValue),timetocomplete).SetEase(ease).SetLoops(-1,LoopType.Yoyo);
    }

    
}
