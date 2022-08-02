using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant03 : MonoBehaviour
{
   public GameObject[] designvariants;
   
   float alphatime;
   float quadringtime;
   public float accel_rot;
   public float accel_quad;
   triggerzone triggerzonescript;
   bool a=false,b=false;

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
            quadringtime+=Time.deltaTime*accel_quad;
            float g=Mathf.Lerp(1.1f,0,quadringtime);
        }
        ///...indicating the harvest is done
        if(triggerzonescript.spheremesh.transform.localScale.x<=0)
        {
            if(!a)
            {
                DOVirtual.Color(designvariants[2].GetComponent<Renderer>().material.GetColor("_outerringcolor"),triggerzonescript.mycolor,2f,v => designvariants[2].GetComponent<Renderer>().material.SetColor("_outerringcolor",v));
                DOVirtual.Float(1.1f,0,2f,v=>designvariants[2].GetComponent<Renderer>().material.SetFloat("_overallradius",v));
                  
                a=true;
            }  
        }
        ///...indicating the harvest is done
    } 
    if(triggerzonescript.exit==true)
            { 
                if(triggerzonescript.spheremesh.transform.localScale.x<=0)
                {
                    if(!b)
                    {
                        DOVirtual.Float(1,0,1f,v =>designvariants[2]. GetComponent<Renderer>().material.SetFloat("_thickness",v));

                        b=true;
                    }
                }
                    
                
            }    
   }
}
