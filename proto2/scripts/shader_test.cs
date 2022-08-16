using UnityEngine;
using DG.Tweening;

public class shader_test : MonoBehaviour
{
    // public bool mybool;
    public LoopType loopType;
    public Ease ease;
    public float timetocomplete;

    void Start() 
    {
        DOVirtual.Float(0,1.39f,timetocomplete,v => this.GetComponent<Renderer>().material.SetFloat("_Float",v)).SetEase(ease).SetLoops(-1,loopType);
    }  
}
