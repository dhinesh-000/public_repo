using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaEffectors : MonoBehaviour
{
    bool enter;
    public float f;  
    float h=-0.2f;
    
    public bool downwards;
    public bool upwards;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enter==true)
        {
            if(downwards)
            {
                if(h<=f)
                {
                    h+=Time.deltaTime;
                    
                }
                playermovementscript.instance.GetComponent<Rigidbody>().velocity=
                    new Vector3(
                    playermovementscript.instance.GetComponent<Rigidbody>().velocity.x,
                    playermovementscript.instance.GetComponent<Rigidbody>().velocity.y-h,
                    playermovementscript.instance.GetComponent<Rigidbody>().velocity.z);
            }
            if(upwards)
            {
                if(h<=f)
                {
                    h+=Time.deltaTime;
                    
                }
                playermovementscript.instance.GetComponent<Rigidbody>().velocity=
                    new Vector3(
                    playermovementscript.instance.GetComponent<Rigidbody>().velocity.x,
                    playermovementscript.instance.GetComponent<Rigidbody>().velocity.y+h,
                    playermovementscript.instance.GetComponent<Rigidbody>().velocity.z);   
            }
        }   
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            enter=true;
            

        }    
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            h=-0.2f;
        }
    }
}
