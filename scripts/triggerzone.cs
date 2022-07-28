using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

///...proto2...///
///singleton

[RequireComponent(typeof(AudioSource))]
public class triggerzone : MonoBehaviour
{
    public static triggerzone instance;
    [HideInInspector]
    public bool canPlayerUseBoost;  
    [HideInInspector]
    public bool inside;
    [HideInInspector]
    public bool exit;


    public float G;
    public float radiusSOI;
    
    public float harvestamount; 
    [HideInInspector]
    public float harvestamount_initsetting;
    public GameObject spheremesh;
    public float spheremeshinitrad;
    public float shrinkrate=0.5f;

    [ColorUsage(true,true)]
    public Color mycolor;
    float f;
    float g=0;
    public float rateToZero;
    public AudioClip myclip;
    public AnimationCurve animationCurve;

    void Awake() 
    {
        instance=this;   
    }
    void OnEnable() 
    {
        initialsetting();    
    }
    public void initialsetting()
    {
        spheremesh.transform.localScale=new Vector3(1,1,1);
        
        spheremeshinitrad=1;
        g=0;
        G=20;
        harvestamount=10;
        
    }    
    void Start() 
    {
        DOTween.SetTweensCapacity(2000,200);
        
        harvestamount_initsetting=harvestamount;
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(animationCurve.Evaluate(SceneManager.GetActiveScene().buildIndex));
        
    }
    void OnDrawGizmos() 
    {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position,radiusSOI);
    }
  
  private void FixedUpdate() 
  {
        gravity();
  }
  
  void gravity()
    {
        Collider[] ifinside=Physics.OverlapSphere(this.transform.position,radiusSOI);
        foreach(var i in ifinside)
        {
            if(i.transform.CompareTag("Player"))
            {
               
                //  propertyvariant.harvestamount-=Time.deltaTime;
                // if(propertyvariant.harvestamount>=0)
                // {
                //     playermovementscript.instancemovementscript.boost+=Time.deltaTime;
                // }
                // Debug.Log(this.transform.name );

                float m1=20;
                float m2=playermovementscript.instance.rb.mass;
                float r=Vector3.Distance(this.transform.position,playermovementscript.instance.transform.position);

                playermovementscript.instance.GetComponent<Rigidbody>().AddForce((this.transform.position-playermovementscript.instance.transform.position).normalized*(G*(m1*m2)/(r*r))*Time.fixedDeltaTime*200f);
                //stationary gameobject's position - moving gameobject's position
            }
        }
    }
    private void Update() 
    {
        
        ///...spheremesh 
        ///...common to all
            if(inside==true)
            {
                if(spheremeshinitrad>=0)
                {
                    
                    f+=Time.deltaTime;
                    spheremeshinitrad-=Time.deltaTime*shrinkrate;
                    // Debug.Log(f);
                    spheremesh.transform.localScale=new Vector3(spheremeshinitrad,spheremeshinitrad,spheremeshinitrad); 
                }
                else if(spheremeshinitrad<=0){
                    spheremesh.transform.localScale=new Vector3(0,0,0); 
               
                    playermovementscript.instance.GetComponent<AudioSource>().pitch=1;
                    
                }  
            ///...eachPercentage
                if(g<=gamemanager.instance.eachPercentage)
                {
                    
                    g+=Time.deltaTime*rateToZero;
                    gamemanager.instance.total+=Time.deltaTime*rateToZero;
                    gamemanager.instance.k+=Time.deltaTime*animationCurve.Evaluate(SceneManager.GetActiveScene().buildIndex);
                }
            ///...eachPercentage  
                // if(gamemanager.instance.combomultiplier>=1)
                // {
                //     gamemanager.instance.combomultiplier+=Time.deltaTime*0.05f;
                // } 
            }

            if(exit==true && spheremesh.transform.localScale.x<=0)
            {
                // if(gamemanager.instance.combomultiplier>=1)
                // {
                //     gamemanager.instance.combomultiplier-=Time.deltaTime*0.1f;
                // }
                G=0;
                ///...object pooling 
                // if(spheremesh.transform.localScale.x<=0)
                // {
                //     GameObject j=this.gameObject;
                //     j.SetActive(false);
                // }
                ///...object pooling 
            }      
   
      
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Player"))
        {
            ///...initialorbvelocity
            Debug.Log("player found");
                 
            // float m1=orbvel.instance.GetComponent<Rigidbody>().mass;
            float m2=playermovementscript.instance.rb.mass;
            float r=Vector3.Distance(this.transform.position,playermovementscript.instance.transform.position);

            playermovementscript.instance.rb.velocity+=((playermovementscript.instance.transform.forward))*Mathf.Sqrt((G*m2)/r);
            //m2 = the moving gameobject
            ///...initialorbvelocity
            
            canPlayerUseBoost=true;
            
            ///...pshandler
            PShandler.instance.insidefunction();
            ///...pshandler

            ///...camera shake
            Debug.Log(this.transform.name);
            VCamHandler.instance.shakecam();
            ///...camera shake

            ///...audio
            playermovementscript.instance.GetComponent<AudioSource>().pitch=-1;
            this.GetComponent<AudioSource>().PlayOneShot(myclip,1f);
            ///...audio

            // ///...combo
            // if(!x)
            // {
            //     gamemanager.instance.combomultiplier++;
            //     x=true;
            //     gamemanager.instance.combomultiplier=p;
            // }
            // ///...combo

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            

            inside=true; 
            canPlayerUseBoost=true;


            
        ///...harvest and trail
             if (this.harvestamount>=0)
            {
                this.harvestamount-=Time.deltaTime;
                // DOVirtual.Float(playermovementscript.instance.GetComponent<TrailRenderer>().time,200,this.harvestamount,v =>playermovementscript.instance.GetComponent<TrailRenderer>().time=v);

            }
            else 
            {
                // DOVirtual.Float(playermovementscript.instance.GetComponent<TrailRenderer>().time,10,this.harvestamount,v =>playermovementscript.instance.GetComponent<TrailRenderer>().time=v);
            }
        ///...harvest and trail
            if(Input.GetKeyDown(KeyCode.Space))
            {
                G=0f;
            }   
          
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {

            
        ///... trail
            if(playermovementscript.instance.GetComponent<TrailRenderer>().time>5f)
            {       
                // DOVirtual.Float(playermovementscript.instance.GetComponent<TrailRenderer>().time,5,5f,v =>playermovementscript.instance.GetComponent<TrailRenderer>().time=v);
            }
        ///... trail
            // triggerzoneGO.harvestamount=temp;
            canPlayerUseBoost=false;
            G=20f;
            inside=false;
            exit=true;
        ///...camera shake
            VCamHandler.instance.shakecam();
        ///...camera shake

        ///...pshandler
        PShandler.instance.exitfunction();
        ///...pshandler

        ///...audio
        playermovementscript.instance.GetComponent<AudioSource>().pitch=1;
        ///...audio
       
        
    }
    }

}
