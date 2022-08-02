using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colldet : MonoBehaviour
{
     
    
    public GameObject spherofinfluence;
    [Tooltip("this is the player within the Sphere Of Influence")]
        public GameObject player;

    [Tooltip("the gravitation pull of two objects ,have to experiment more")]
        public float G;
   
    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag=="Player")
        {
            // initialorbitalvel(); 
            // Debug.Log(other.transform.name); //prints out Player
        }
    }
    void initialorbitalvel()
    {
        Debug.Log("func called");
        float distance=Vector3.Distance(spherofinfluence.transform.position,player.transform.position);
        //orbital velocity
        // player.transform.LookAt(spherofinfluence.transform);
        player.GetComponent<Rigidbody>().velocity+=player.transform.forward*Mathf.Sqrt((G*spherofinfluence.GetComponent<Rigidbody>().mass)/distance);    
        //orbital velocity
    }

}
