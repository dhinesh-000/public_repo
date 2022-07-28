using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

///...proto2...///
///singleton
public class playermovementscript : MonoBehaviour
{
    public static playermovementscript instance;
    public float forceintensity=80;
    public Rigidbody rb;
    public  float boost;
    [HideInInspector]
    public Vector3  startpos_initsetting;
     public Slider slider_time;
     public float  initval=10;
    public GameObject dist_Travelledtext;
    
    public float startpos_x=0;
    void Awake() 
    {
        if(instance==null)
            {instance=this;
            DontDestroyOnLoad(gameObject);}
        else    
            Destroy(gameObject);
            
        
    }
     
    void Start()
    {
        rb=GetComponent<Rigidbody>(); 
        startpos_initsetting=this.transform.position;
    }
    void Update()
    {
        if(this.rb.velocity.magnitude>200)
        {
            rb.velocity=new Vector3(0,0,0);
            SceneManagerscript.instance.lvlcompletepanel.SetActive(true);
        }
        /////////////////
        bool y=Input.GetKey(KeyCode.Y);
        bool u=Input.GetKey(KeyCode.U);
        if(y)
        {
            Time.timeScale=0.5f;
            forceintensity=160;
            if(initval>=0)
                initval-=Time.deltaTime;
        }
        else
        {
            Time.timeScale=1.5f;
            forceintensity=80;
        }
        slider_time.value=initval;
        ///...UI
        float dist=this.gameObject.transform.position.x-startpos_x;
        dist_Travelledtext.GetComponent<Text>().text=dist.ToString("f0");
        ///...UI

        //boost
            //mobile touch - touch and hold any part of the screen
            if(Input.GetKey(KeyCode.B))
            {
                
                if(boost>=0 && triggerzone.instance.canPlayerUseBoost==false)
                {
                    boost-=Time.deltaTime*5f;
                    rb.AddForce(new Vector3(boost,this.transform.position.y,this.transform.position.z));
                }
                
            }
        //boost

        // player movement controls
            //mobile touch -left  and  right side of the screen
            if(Input.GetKey(KeyCode.D))
            {   
                rb.AddForce(transform.right*forceintensity);
            }  
            if(Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right*forceintensity);
            }    
        // player movement controls

    }

}
