using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant05 : MonoBehaviour
{
    triggerzone triggerzonescript;
    public GameObject[] designvariants;
    float alphatime;
    float t=5,u;
    public float accel_Lrot;

    public float rot;
    public float floatvalue;
    bool a;
    void Start()
    {
        triggerzonescript=this.GetComponent<triggerzone>();
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerzonescript.inside==true)
        {
            if(alphatime>=0) 
            {
                alphatime+=Time.deltaTime*accel_Lrot;
                float f=Mathf.Lerp(2.72f,0.72f,alphatime);
                designvariants[0].GetComponent<Renderer>().material.SetFloat("_control1",f);
                designvariants[1].GetComponent<Renderer>().material.SetFloat("_control1",f);

            }
            if(t>=0)
            {
                t-=Time.deltaTime*rot;
                float g= Mathf.Lerp(5,0,t);
                designvariants[2].GetComponent<Renderer>().material.SetFloat("_rotate",t);
            }
            if(u>=0)
            {
                u+=Time.deltaTime*floatvalue;
                float j=Mathf.Lerp(0.39f,-0.3f,u);
                designvariants[2].GetComponent<Renderer>().material.SetFloat("_Float",j);
            }
        }
        ///...indicating the harvest is done
        if(triggerzonescript.spheremesh.transform.localScale.x<=0)
        {
            if(!a)
            {
                DOVirtual.Color(designvariants[3].GetComponent<Renderer>().material.GetColor("_color"),triggerzonescript.mycolor,2f,v => designvariants[3]. GetComponent<Renderer>().material.SetColor("_color",v));
                
                designvariants[2].GetComponent<Renderer>().material.SetFloat("_alphathreshold",2);

                a=true;
            }  
        }
        ///...indicating the harvest is done
    }///...update
}
