using System;
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
     public float  slowmotime=10;
    public GameObject dist_Travelledtext;
    
    public float startpos_x=0;
    public GameObject sphere;
    public AudioClip clip1;
    // public AudioClip clip2;
    // public GameObject trail;
    // bool a;
    // int i=0;
    public float magnetrad;
    public float attractspeed;
    public static Action coincollect;

    void OnDrawGizmos() 
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(this.transform.position,magnetrad);    
    }

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
    void FixedUpdate() 
    {
        ///... use this to update player movement
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
        Collider[] isinside=Physics.OverlapSphere(this.transform.position,magnetrad);
        foreach(var i in isinside)
        {
            if(i.transform.CompareTag("Coin"))
            {
                i.transform.position=Vector3.MoveTowards(i.transform.position,this.transform.position,attractspeed*Time.deltaTime);
                float d=Vector3.Distance(i.transform.position,this.transform.position);
                if(d<=0.1f)
                {
                    i.gameObject.SetActive(false);
                    gamemanager.instance.lumen++;
                    coincollect?.Invoke();
                    ///...lumen text field
                    SceneManagerscript.instance.lumentxt.GetComponent<Text>().color=new Color(1,1,1,1);
                    SceneManagerscript.instance.lumentxt.GetComponent<Text>().DOColor(new Color(0,0,0,0),4f);
                    SceneManagerscript.instance.lumentxt.GetComponent<Text>().text=gamemanager.instance.lumen.ToString();
                    ///...lumen text field
                }
            }
        }
        
    }
    
    void Update()
    {
        // if(this.transform.localPosition.x>1000)
        // {
        //     this.transform.localPosition=new Vector3(0,this.transform.localPosition.y,this.transform.localPosition.z);
        // }
        if(this.rb.velocity.magnitude>200)
        {
            rb.velocity=new Vector3(0,0,0);
            SceneManagerscript.instance.lvlcompletepanel.SetActive(true);
        }
        /////////////////
        bool y=Input.GetKey(KeyCode.Y);
        // bool u=Input.GetKey(KeyCode.U);
        if(y)
        {
            Time.timeScale=0.5f;
            forceintensity=160;
            if(Input.GetKeyDown(KeyCode.Y))
            {
                sphere.GetComponent<AudioSource>().PlayOneShot(clip1);
            }
            if(slowmotime>=0)
                slowmotime-=Time.deltaTime;
        }
        else if(!y)
        {
            // trail.GetComponent<AudioSource>().PlayOneShot(clip2);
            Time.timeScale=1.5f;
            forceintensity=80;
        }
        slider_time.value=slowmotime;
        ///...UI
        float dist=this.gameObject.transform.position.x-startpos_x;
        dist_Travelledtext.GetComponent<Text>().text=dist.ToString("f0");
        ///...UI

        // // player movement controls
        //     //mobile touch -left  and  right side of the screen
            // if(Input.GetKey(KeyCode.D))
            // {   
            //     rb.AddForce(transform.right*forceintensity);
            // }  
            // if(Input.GetKey(KeyCode.A))
            // {
            //     rb.AddForce(-transform.right*forceintensity);
            // }    
        // // player movement controls


    }

}
