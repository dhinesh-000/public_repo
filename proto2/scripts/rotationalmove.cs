using DG.Tweening;
using UnityEngine;

public class rotationalmove : MonoBehaviour
{
    public bool shouldrotate;
    public float howmuchtorotate;
    public  float timetorotate;
    public Ease ease;
    public LoopType loopType;
    void Start()
    {
        if(shouldrotate==true)
        {
            this.transform.DOLocalRotate(new Vector3(0,  howmuchtorotate,0), timetorotate, RotateMode.FastBeyond360).SetRelative(true).SetEase(ease).SetLoops(-1,loopType);
        }
    }

   
}
