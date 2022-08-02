using System.Collections;
using DG.Tweening;

using UnityEngine;

///...proto2...///
public class boosttrigger : MonoBehaviour
{
    bool istrue;
    // public orbvel orbvelscript;
    // public boosttriggerpropertiesSCROBJ prefabpropertiesSCROBJ;
    public float decreaseovertime;
    bool a;
    [Tooltip("higher this value faster the decreaseovertime variable comes to zero")]
    public float rate;
    public AudioClip myclip;
    float h;
    void Start() 
    {
    }
    void Update() 
    {
        
        if(istrue)
        {
            if(decreaseovertime>=0)
            {
               decreaseovertime-=Time.deltaTime*rate;   
            }

        }
        ///...mesh scaling
        if(decreaseovertime<=0)
        {
            if(!a)
            {   
                this.transform.DOScaleX(0,3f);
                a=true;
            }
        }
        ///...mesh scaling
         
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            h=playermovementscript.instance.rb.velocity.x;
            Debug.Log(h);
            ///...audio
            this.GetComponent<AudioSource>().PlayOneShot(myclip,1);
            ///...audio
            istrue=true;
            playermovementscript.instance.GetComponent<Rigidbody>().velocity=
                new Vector3(
                playermovementscript.instance.GetComponent<Rigidbody>().velocity.x+decreaseovertime,
                playermovementscript.instance.GetComponent<Rigidbody>().velocity.y,
                playermovementscript.instance.GetComponent<Rigidbody>().velocity.z);
            
            ///...camera shake
            VCamHandler.instance.shakecam();
            ///...camera shake

            StartCoroutine(callfnc());
        }   
    }
    private void OnTriggerExit(Collider other) 
    {
         if(other.transform.CompareTag("Player"))
        {
            decreaseovertime=10;
        }       
    }


    IEnumerator callfnc()
    {
        yield return new WaitForSeconds(2f);
        DOVirtual.Float(playermovementscript.instance.rb.velocity.x,h,2f,v=> playermovementscript.instance.rb.velocity=new Vector3(v,playermovementscript.instance.rb.velocity.y,playermovementscript.instance.rb.velocity.z));
    }

}
