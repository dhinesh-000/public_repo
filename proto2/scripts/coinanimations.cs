using System;
using DG.Tweening;
using UnityEngine;

///...REFACTORED...///
public class coinanimations : MonoBehaviour
{
    [Header("START")]
    public Ease ease;
    public LoopType loopType;
    public float scaleEndValue;
    public float timetocomplete;
    [Header("UPDATE")]
    public float coinattractspeed;
    float dist;
    public static Action coincollect;
    bool a;
 
    void Start()
    {
            this.transform.DOLocalRotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360).SetRelative(true).SetEase(ease).SetLoops(-1,loopType);

            this.transform.DOScale(new Vector3(scaleEndValue,scaleEndValue,scaleEndValue),timetocomplete).SetEase(ease).SetLoops(-1,LoopType.Yoyo);
         
    }
    void Update() 
    {
        dist=Vector3.Distance(this.transform.position,playermovementscript.instance.transform.position);
        if(dist<10)
        {
            transform.position=Vector3.MoveTowards(this.transform.position,playermovementscript.instance.transform.position,coinattractspeed*Time.deltaTime);
            this.gameObject.SetActive(false);
        } 
        if(!this.gameObject.activeInHierarchy && !a)
        {
            coincollect?.Invoke();
            a=true;
        }   
    }

    
}
