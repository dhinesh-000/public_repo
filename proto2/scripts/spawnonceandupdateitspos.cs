using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class spawnonceandupdateitspos : MonoBehaviour
{
    private ARRaycastManager ARRaycastManager;
     public GameObject test;

     public GameObject cube;
    public GameObject   myprefab;
    List<ARRaycastHit> hits=new List<ARRaycastHit>();
    private GameObject  spawnedobj;
    //   ARPlaneManager aRPlaneManager;
    float f;

    bool trygettouchposition(out Vector2 touchpos)
    {
        if(Input.touchCount>0)
        {
            touchpos=Input.GetTouch(0).position;

            return true;
        }
        touchpos=default;
        return false;
    }
    private void Awake() {
        ARRaycastManager=GetComponent<ARRaycastManager>();
        // aRPlaneManager=GetComponent<ARPlaneManager>();
        // aRPlaneManager.requestedDetectionMode=PlaneDetectionMode.Vertical;
        // Debug.Log(aRPlaneManager.requestedDetectionMode);     /////////////working 


        // cube.transform.localScale=Vector3.one*4;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.touchCount>0)
       {
            test.transform.eulerAngles=new Vector3(0,-Input.GetTouch(0).position.x,0);
            // test.transform.position=new Vector3(Input.GetTouch(0).position.x,0,0);
            
       }
        // test.transform.eulerAngles=new Vector3(0,Input.mousePosition.x,0);
        // cube.transform.eulerAngles=new Vector3(0,Input.mousePosition.x,0);
       
        // test.transform.position=new Vector3(Input.mousePosition.x,0,0);
        

        
        


        if(!trygettouchposition(out Vector2 touchpos))
            return ;

        if(ARRaycastManager.Raycast(touchpos,hits,TrackableType.PlaneWithinPolygon))
        {
            var hit=hits[0].pose;
            if(spawnedobj==null)
            {
                spawnedobj=Instantiate(myprefab,hit.position,hit.rotation);
            }
            else
            {
                spawnedobj.transform.position=hit.position;
    
                // spawnedobj.transform.rotation=hit.rotation;


                spawnedobj.transform.eulerAngles=new Vector3(0,-Input.GetTouch(0).position.x,0);
            }


        }
    }

   

  
}
