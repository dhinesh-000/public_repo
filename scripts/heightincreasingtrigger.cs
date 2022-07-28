
using UnityEngine;

public class heightincreasingtrigger : MonoBehaviour
{
    
    public GameObject   player;
    
    void OnTriggerEnter(Collider other) 
    {
        // Debug.Log(other.transform.localEulerAngles.z);  //... gives a range of 0 to 360
        if(other.transform.CompareTag("Player"))
        {                   
            float z1=other.transform.localEulerAngles.z;
            if(z1>=180)
            {
                z1=z1-360;
                Debug.Log(z1);
            }
            if(z1>=0 && z1<=45)
               player.GetComponent<Rigidbody>().velocity+=new Vector3(0,100f,0); 
            
            if(z1<=0 && z1>=-45f)
               player.GetComponent<Rigidbody>().velocity+=new Vector3(0,-100f,0); 
        }   
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            return;
            
        }    
    }

   
}
