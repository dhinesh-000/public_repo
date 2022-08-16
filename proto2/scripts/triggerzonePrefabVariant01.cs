using DG.Tweening;
using UnityEngine;

public class triggerzonePrefabVariant01 : MonoBehaviour
{
    // public GameObject quadrings; 
    public Renderer Renderer;  
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

    int ID_alphathreshold;
    int ID_thickness;
    int ID_outerringcolor;
    int ID_expansion;

    void OnEnable() 
    {
        initialsetting();
    }
    public void initialsetting()
    {
        Renderer.material.SetFloat(ID_alphathreshold,0);
        Renderer.material.SetFloat(ID_thickness,0.3f);
        Renderer.material.SetColor(ID_outerringcolor,outerringinitcolor);
        triggerzonescript=this.GetComponent<triggerzone>();
        alpha=false;
        alpha1=false;
    }
    void Awake() 
    {
        ///...caching shader id
        ID_alphathreshold=Shader.PropertyToID("_alphathreshold");    
        ID_thickness=Shader.PropertyToID("_thickness");
        ID_outerringcolor=Shader.PropertyToID("_outerringcolor");
        ID_expansion=Shader.PropertyToID("_expansion");
        ///...caching shader id

    }
    
    void Update()
    {
         ///...this is the part of the code relating to the prefab variant 01
        if(triggerzonescript.inside==false)
        {
            f=29;
            f+=Time.time;
            Renderer.material.SetFloat(ID_expansion,f);
        }
        else if(triggerzonescript.inside==true) 
        {
            Renderer.material.SetFloat(ID_expansion,triggerzonescript. harvestamount);                    
        }    
        if((triggerzonescript.spheremesh.transform.localScale.x<=0 )) 
        {
            if(!alpha1 && triggerzonescript.exit==false)  
            {
                ///...prompting the player that triggerzoneGO star is dead by changing the color of the outerring 
                DOVirtual.Color(Renderer.material.GetColor(ID_outerringcolor),outerringchangedcolor,outerringradCOLORfadetime,v => Renderer.material.SetColor(ID_outerringcolor,v));

                alpha1=true;
            }
            if(triggerzonescript.exit==true )
            {
                
                // Renderer.material.SetFloat("_expansion",0);
                if(!alpha)
                {
                    DOVirtual.Float(0,2,alphathresholdfadetime,v => Renderer.material.SetFloat(ID_alphathreshold,v));
                    
                    alpha=true; 
                }
            }
                
        } 
        ///...this is the part of the code relating to the prefab variant 01
    }
}
