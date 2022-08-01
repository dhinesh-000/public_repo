using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant07 : MonoBehaviour
{
    triggerzone triggerzonescript;
    public GameObject[] designvariants;
    bool a;
    float b,c;
    public float accel_control2;
    public float accel_control4;
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
                b+=Time.deltaTime*accel_control2;
                float j=Mathf.Lerp(0.39f,2,b);
                designvariants[0].GetComponent<Renderer>().material.SetFloat("_control2",j);
            }
            if(c>=0)
            {
                c+=Time.deltaTime*accel_control4;
                float k=Mathf.Lerp(0.09f,5,c);
                designvariants[1].GetComponent<Renderer>().material.SetFloat("_control4",k);
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
