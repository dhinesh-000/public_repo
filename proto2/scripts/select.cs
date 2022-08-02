using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class select : MonoBehaviour
{
      public  GameObject[] mygameobjects;

    // colorchange colorchange=new colorchange();
//    public List<GameObject> mylist=new List<GameObject>();

     void Start() 
    {
    
    }
    void Update()
    {
        if(Input.touchCount> 0  && Input.touches[0].phase==TouchPhase.Began)
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.touches[0].position),out RaycastHit hit))
            {
                           
                if(hit.transform.tag=="Player")
                
                {
                    hit.collider.GetComponent<colorchange>().boolchange();

                    
                }
               
            }
        }
              

    }












        

    

    
   
}
