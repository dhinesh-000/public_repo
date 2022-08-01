using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant01 : MonoBehaviour
{
    public GameObject quadrings;    
    float f;
    [ColorUsage(true,true)]
    public Color outerringchangedcolor;
    [ColorUsage(true,true)]
    public Color outerringinitcolor;
    
    bool alpha=false;
    bool alpha1=false;    
    public float OTRfadetime;
    public float alphathresholdfadetime;
    public float outerringradCOLORfadetime;

    triggerzone triggerzonescript;

    void OnEnable() 
    {
        initialsetting();
    }
    public void initialsetting()
    {
        quadrings.GetComponent<Renderer>().material.SetFloat("_alphathreshold",0);
        quadrings.GetComponent<Renderer>().material.SetFloat("_thickness",0.3f);
        quadrings.GetComponent<Renderer>().material.SetColor("_outerringcolor",outerringinitcolor);
    }
    void Start() 
    {
        triggerzonescript=this.GetComponent<triggerzone>();
    }
    
    void Update()
    {
         ///...this is the part of the code relating to the prefab variant 01
        if(triggerzonescript.inside==false)
        {
            f=29;
            f+=Time.time;
            quadrings.GetComponent<Renderer>().material.SetFloat("_expansion",f);
        }
        else if(triggerzonescript.inside==true) 
        {
            quadrings.GetComponent<Renderer>().material.SetFloat("_expansion",triggerzonescript. harvestamount);                    
        }    
        if((triggerzonescript.spheremesh.transform.localScale.x<=0 )) 
        {
            if(triggerzonescript.exit==true && triggerzonescript.inside==false)
            {
                
                // quadrings.GetComponent<Renderer>().material.SetFloat("_expansion",0);
                if(!alpha)
                {
                    DOVirtual.Float(0,2,alphathresholdfadetime,v => quadrings.GetComponent<Renderer>().material.SetFloat("_alphathreshold",v));
                    
                    alpha=true; 
                }
            }
            if(!alpha1)
            {
                // DOVirtual.Float(1,0,OTRfadetime,v =>quadrings.GetComponent<Renderer>().material.SetFloat("_thickness",v));

                ///...prompting the player that triggerzoneGO star is dead by changing the color of the outerring 
                DOVirtual.Float(1,0,OTRfadetime,v =>quadrings.GetComponent<Renderer>().material.SetFloat("_thickness",v));
                DOVirtual.Color(quadrings.GetComponent<Renderer>().material.GetColor("_outerringcolor"),outerringchangedcolor,outerringradCOLORfadetime,v => quadrings.GetComponent<Renderer>().material.SetColor("_outerringcolor",v));

                alpha1=true;
            }
                
        } 
        ///...this is the part of the code relating to the prefab variant 01
    }
}
