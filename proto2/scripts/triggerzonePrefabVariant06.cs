using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant06 : MonoBehaviour
{
    triggerzone triggerzonescript;
    public GameObject[] designvariants;
    bool a;
    float b;
    float c;
    public float accel_dot;
    public float accel_control2;

    void Start()
    {
        triggerzonescript=this.GetComponent<triggerzone>();
    }

    // Update is called once per frame
    void Update()
    {

        if(triggerzonescript.inside==true)
        {
            if(b>=0)
            {
                b+=Time.deltaTime*accel_dot;
                float h=Mathf.Lerp(20,0,b);
                designvariants[0].GetComponent<Renderer>().material.SetFloat("_control1",h);
            }
            if(c>=0)
            {
                c+=Time.deltaTime*accel_control2;
                float j=Mathf.Lerp(2.5f,5,c);
                designvariants[1].GetComponent<Renderer>().material.SetFloat("_control2",j);
            }
        }
       ///...indicating the harvest is done
        if(triggerzonescript.spheremesh.transform.localScale.x<=0)
        {
            if(!a)
            {
                DOVirtual.Color(designvariants[2].GetComponent<Renderer>().material.GetColor("_color"),triggerzonescript.mycolor,2f,v => designvariants[2]. GetComponent<Renderer>().material.SetColor("_color",v));
                a=true;
            }  
        }
        ///...indicating the harvest is done  
    }
}
