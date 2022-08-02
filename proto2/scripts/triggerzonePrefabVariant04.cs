using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant04 : MonoBehaviour
{
    public GameObject[] designvariants;
    
    triggerzone triggerzonescript;
    
   float alphatime;
   public float accel_rot;
   bool a =false;
    
    void Start()
    {
        triggerzonescript=this.GetComponent<triggerzone>();    
    }

    void Update()
    {
        if(triggerzonescript.inside==true)
        {
            if(alphatime>=0)
            {
                alphatime+=Time.deltaTime*accel_rot;
                float f=Mathf.Lerp(0.02f,3f,alphatime);
                designvariants[0].GetComponent<Renderer>().material.SetFloat("_alphathreshold",f);
                designvariants[1].GetComponent<Renderer>().material.SetFloat("_alphathreshold",f);
            }
        }
        ///...indicating the harvest is done
        if(triggerzonescript.spheremesh.transform.localScale.x<=0)
        {
            if(!a)
            {
                DOVirtual.Color(designvariants[3].GetComponent<Renderer>().material.GetColor("_color"),triggerzonescript.mycolor,2f,v => designvariants[3].GetComponent<Renderer>().material.SetColor("_color",v));
                DOVirtual.Float(2.06f,3,3f,v => designvariants[2].GetComponent<Renderer>().material.SetFloat("_control2",v));
                  
                a=true;
            }  
        }
        ///...indicating the harvest is done
      
    }
}
