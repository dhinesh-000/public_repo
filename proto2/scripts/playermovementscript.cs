using System.Collections;
using UnityEngine;

///...proto2...///
///singleton
///...REFACTORED...///
public class playermovementscript : MonoBehaviour
{
    public static playermovementscript instance;


    [Header("START")]
    public Rigidbody rb;
    public TrailRenderer trailRenderer;
    public AudioSource audioSource;



    [Header("FIXED UPDATE")]
    public float forceintensity;



    [Header("UPDATE")] 
     public float  slowmotime=10;

    // [HideInInspector]
    // public float startpos_x=0;
    public GameObject sphere;
    public AudioClip clip1;
    [Tooltip("red circle in the scene view")]
    public float magnetradius;
    public float magnetlifetime;




    [HideInInspector]
    public GameObject magnetGO;
    
    [HideInInspector]
    public Vector3  startpos_initsetting;

    

    // void OnDrawGizmos() 
    // {
    //     Gizmos.color=Color.red;
    //     Gizmos.DrawWireSphere(this.transform.position,magnetradius);    
    // }

    void Awake() 
    {
        if(instance==null)
            {instance=this;
            DontDestroyOnLoad(gameObject);}
        else    
            Destroy(gameObject);
            
        // this.gameObject.SetActive(false);
    }
     
    void Start()
    {
        magnetGO.SetActive(false);
        rb=GetComponent<Rigidbody>(); 
        trailRenderer=GetComponent<TrailRenderer>();
        audioSource=GetComponent<AudioSource>();
        startpos_initsetting=this.transform.position;
    }
    void FixedUpdate() 
    {
        ///...PLAYER MOVEMENT CONTROLS
            if(GAMESTATES_MANAGER.instance.currentstate==GAMESTATES_MANAGER.gamestate.ingame) 
            {
                ///...keyboard controls
                if(Input.GetKey(KeyCode.D))
                {   
                    rb.AddForce(transform.right*forceintensity);
                }  
                if(Input.GetKey(KeyCode.A))
                {
                    rb.AddForce(-transform.right*forceintensity);
                }
                ///...keyboard controls

                ///...mobile controls
                if(Input.touchCount>0)
                {
                    if(Input.GetTouch(0).position.x > Screen.width/2 && Input.GetTouch(0).phase == TouchPhase.Stationary)
                    {   
                        rb.AddForce(transform.right*forceintensity);
                    }  
                    if(Input.GetTouch(0).position.x < Screen.width/2 && Input.GetTouch(0).phase == TouchPhase.Stationary)
                    {
                        rb.AddForce(-transform.right*forceintensity);
                    }    
                }
                ///...mobile controls
            }           
        ///...PLAYER MOVEMENT CONTROLS
        
    }

   
     void Update()
    {        
        if(SceneManagerscript.instance!=null)
        {
            if(SceneManagerscript.instance.timetoggle.isOn==true)
            {
                Time.timeScale=0.75f;
                forceintensity=160;
                
                if(slowmotime>=0)
                    slowmotime-=Time.deltaTime;
            }
            else if(SceneManagerscript.instance.timetoggle.isOn==false)
            {
                Time.timeScale=1.7f;
                forceintensity=80;
            }

            if(SceneManagerscript.instance.a==true)
            {
                Time.timeScale=0;   
            }
            if(SceneManagerscript.instance.a==false)
            {
                Time.timeScale=1.7f;
            }
        }

        
    }
    public void TIMESTOPAUDIOFUNCTIONonselect()
    {
        if(SceneManagerscript.instance.timetoggle.isOn==true)
            sphere.GetComponent<AudioSource>().PlayOneShot(clip1);
        
    }
    

    ///...PRESS THIS BUTTON(FUNCTION) TO ACTIVATE THE COIN MAGNET 
    public void coinmagnetfunction()
    {
        magnetradius=30;
        magnetGO.SetActive(true);
        StartCoroutine(j());
        SceneManagerscript.instance. magnetradiusBTN.interactable=false;///...prevents multiple registration of clicks 

    }
    IEnumerator j()
    {
        yield return new WaitForSeconds(magnetlifetime);
        SceneManagerscript.instance.magnetradiusBTN.interactable=true;
        magnetGO.SetActive(false);
        magnetradius=10;
    }
   

}
