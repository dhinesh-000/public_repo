using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class spawneveryupdate : MonoBehaviour
{
    private ARRaycastManager ARRaycastManager;
    public GameObject   myprefab;
    List<ARRaycastHit> hits=new List<ARRaycastHit>();

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
    }

    // Update is called once per frame
    void Update()
    {
        if(!trygettouchposition(out Vector2 touchpos))
            return ;

        if(ARRaycastManager.Raycast(touchpos,hits,TrackableType.PlaneWithinPolygon))
        {
            var hit=hits[0].pose;
             Instantiate(myprefab,hit.position,hit.rotation);
        }
    }  
}
