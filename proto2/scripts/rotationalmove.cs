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
            this.transform.DOLocalRotate(new Vector3(0,0, this.transform.localRotation.z+howmuchtorotate), timetorotate, RotateMode.FastBeyond360).SetRelative(true).SetEase(ease).SetLoops(-1,loopType);
        }
    }

   
}
