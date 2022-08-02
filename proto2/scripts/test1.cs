using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
// using Cinemachine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class test1 : MonoBehaviour
{
    public float boost;
    public GameObject deadtextGO;
    gamemanager gamemanager;

    // public GameObject sphereOfInfluence;
    public float sphereOfInfluenceradius;
    public GameObject distancefromthecentertext;
    public float myboost;
    float distance;

    bool istrue;
    float g;
    public GameObject boosttriggerGO;
    public Vector3 startpos;
    public GameObject distancefromstart;
    public GameObject SOI;

    public GameObject heighttext ,velocitytext,boostGO;

    public GameObject highscore;
    public float highscorevalue;
    float d1;
 
    public float G;

    // bool onoroff;
    public float threshold;
    public Text text;
 

    //pre-vis
    // void OnDrawGizmos() 
    // {
    //     Gizmos.color=Color.red;
    //     Gizmos.DrawWireSphere(sphereOfInfluence.transform.position,sphereOfInfluenceradius);
        
    // }
    //pre-vis
    void Start()
    {
        deadtextGO.GetComponent<Text>().text="";
        loaddata();
        myboost=PlayerPrefs.GetFloat("boost",20);
        highscore.GetComponent<Text>().text=PlayerPrefs.GetFloat("distancetravelled",0).ToString("f2");
        
        // onoroff=true;

    }

  
  
    void Update()
    {
        
         UIupdate();
          
         this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(40f,0,0));
        
         if(Input.GetKeyDown(KeyCode.V))
        {
            savedata();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            loaddata();
        }


         if(myboost>=4f && myboost<=4.1f)
        { 
            boosttriggerGO.transform.DOScaleX(1,0.5f);  //... throwing errors but working     
        }
        if(myboost<4f)
        {
            boosttriggerGO.transform.DOScaleX(0,0.5f);//...throwing errors but working
        }
        
        if(Input.GetKeyDown(KeyCode.M) && myboost>=0)//change this to mobile double tap
        {   
            istrue=!istrue;  
            // vcamswitcher(); 
        }
        if(myboost<=0)
        {
            istrue=false;
        }

        if(istrue==true)
        {
            myboost-=5f*Time.deltaTime;
            this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(40f+myboost,0,0));       
        }
        

        if(Input.GetKey(KeyCode.W))
        {
            //if set to g+=2f; there is no momentum or feels weight to rotate
            g+=3f;
            this.transform.DOLocalRotate(new Vector3(0,0,g),1f*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            g-=3f;
            this.transform.DOLocalRotate(new Vector3(0,0,g),1f*Time.deltaTime);     
        }

#region SOI
        //SOI
        // Collider[] insideSOI= Physics.OverlapSphere(sphereOfInfluence.transform.position,sphereOfInfluenceradius);

        
        // foreach(var i in insideSOI)
        // {
        //     if(i.transform.tag=="Player")
        //     {    

        //         myboost+=Time.deltaTime;

        //         // Debug.Log(i.transform.name);     ///...prints out cube
        //         //distancefromSOItext
                    
        //             distance=Vector3.Distance(this.transform.position,sphereOfInfluence.transform.position);
                    
        //             distancefromthecentertext.GetComponent<Text>().text=(distance-5).ToString("F2");

        //         //distancefromSOItext

        //         //attractive force

        //             float m1= sphereOfInfluence.GetComponent<Rigidbody>().mass;
        //             float m2= this.GetComponent<Rigidbody>().mass;
        //             this.GetComponent<Rigidbody>().AddRelativeForce((sphereOfInfluence.transform.position-this.transform.position).normalized*(G*(m1*m2)/(distance*distance))); 

        //         //attractive force  
        //     }     
        // }
        
        // //SOI
        #endregion
    }

     void UIupdate()
    {
        text.text=this.transform.position.x.ToString();
        ///distancefromthegroundtext
        if(Physics.Raycast(this.transform.position,Vector3.down,out RaycastHit hit))
        {
            if(hit.transform.name!=null)
            {
                float dist=Vector3.Distance(this.transform.position,hit.point);
                heighttext.GetComponent<Text>().text=dist.ToString("f1");

            }
        }
        ///distancefromthegroundtext

        //velocityXtext

            velocitytext.GetComponent<Text>().text=this.GetComponent<Rigidbody>().velocity.x.ToString("F1");

        //velocityXtext

        //boosttext
            boostGO.GetComponent<Text>().text=myboost.ToString("f2");
        //boosttext

        
        //distance from the start
            d1=Vector3.Distance(startpos,this.transform.position);
            distancefromstart.GetComponent<Text>().text=(d1*0.1f).ToString("f2");
        //distance from the start
    }
//    void initialorbitalvel()
//     {
//         Debug.Log("func called");
//         float distance=Vector3.Distance(this.transform.position,SOI.transform.position);
//         //orbital velocity
//         // player.transform.LookAt(spherofinfluence.transform);
//         this.GetComponent<Rigidbody>().velocity+=this.transform.forward*Mathf.Sqrt((G*this.GetComponent<Rigidbody>().mass)/distance);    
//         //orbital velocity
//     }
    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag=="boost")
        {
            // initialorbitalvel();
            this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(boost,0,0));
            // vcamswitcher();
            StartCoroutine(myfunc());
        }
        
    }
        IEnumerator  myfunc()
        {
            yield return new WaitForSeconds(2f);
            // vcamswitcher();

        }
    

    void OnCollisionEnter(Collision other) ////....game over
    {
        if(other.transform.tag=="deadzone")
        {
            deadtextGO.GetComponent<Text>().text="DEAD!";
                  
            // FindObjectOfType<gamemanager>().reloadscene();
        }
    }
    public void savedata()
    {

        Debug.Log("savedata");
        PlayerPrefs.SetFloat("boost",myboost);
        
        PlayerPrefs.SetFloat("distancetravelled",d1*0.1f);
        
        
    }
    public void loaddata()
    {
        Debug.Log("loaddata");

        myboost=PlayerPrefs.GetFloat("boost"); 
    }
    public void reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
