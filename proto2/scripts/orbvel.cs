using UnityEngine;
using DG.Tweening;
using System;

///...proto2...///
///...singleton
///...contains rigidbody...///
public class orbvel : MonoBehaviour
{
    public  static orbvel instance;
    public float outerringrad;
    public float innerringrad;
    public float radiusSOI;
    private void OnDrawGizmos() 
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(this.transform.position,innerringrad);
        Gizmos.DrawWireSphere(this.transform.position,outerringrad);
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(this.transform.position ,radiusSOI);
    }
       void Awake() 
    {
        instance=this;
        this.GetComponent<AnchorGameObject>().enabled=false;
    }
    private void Update() 
    {
        ///...audio
            float d;    
            d=Vector3.Distance(playermovementscript.instance.transform.position,this.transform.position);
            
            if(d<=outerringrad )
            {            
                this.GetComponent<AudioSource>().DOFade(1,1f);
            }
            if(d>=outerringrad )
            {
                this.GetComponent<AudioSource>().DOFade(0,1f);    
            }     
        ///...audio

        
    }  
}