using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOIscript : MonoBehaviour
{
    public float radiusSOI;
    public float myboost;
    public float G;
    GameObject player;
    //pre vis

    void OnDrawGizmos() 
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(this.transform.position,radiusSOI);

    }
    void Start()
    {
        
    }
    private void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] ifinside=Physics.OverlapSphere(this.transform.position,radiusSOI);

          foreach(var i in ifinside)
        {
            if(i.transform.tag=="Player")
            {    

                myboost+=Time.deltaTime;

                // Debug.Log(i.transform.name);     ///...prints out cube
                // //distancefromSOItext
                    
                   float distance=Vector3.Distance(i.transform.position,this.transform.position);
                    
                    // distancefromthecentertext.GetComponent<Text>().text=(distance-5).ToString("F2");

                // //distancefromSOItext
                player=i.transform.gameObject;

                //attractive force

                    float m1= this.GetComponent<Rigidbody>().mass;
                    float m2= i.GetComponent<Rigidbody>().mass;
                    i.GetComponent<Rigidbody>().AddRelativeForce((this.transform.position-i.transform.position).normalized*(G*(m1*m2)/(distance*distance))); 

                //attractive force  
            }     
        }
        
        //SOI
    }
    // private void OnTriggerEnter(Collider other) {
    //     if(other.transform.tag=="Player")
    //         initialorbitalvel();    
    // }
    // void initialorbitalvel()
    // {
    //     Debug.Log("func called");
    //     float distance=Vector3.Distance(this.transform.position,player.transform.position);
    //     //orbital velocity
    //     // player.transform.LookAt(spherofinfluence.transform);
    //     player.GetComponent<Rigidbody>().velocity+=player.transform.forward*Mathf.Sqrt((G*player.GetComponent<Rigidbody>().mass)/distance);    
    //     //orbital velocity
    // }
}
