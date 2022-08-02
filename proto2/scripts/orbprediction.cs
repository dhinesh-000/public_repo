using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbprediction : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject SOI;
    
    //  float G;
    public float SOIradius;
     float dist;
    
    public float w;
    public int length;
    Vector3[] segments;
    private void OnDrawGizmos() {
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(SOI.transform.position,SOIradius);
    }
    void Start()
    {
        // G=100;

        SOIradius=20;

        lineRenderer.positionCount=length;
        segments=new Vector3[length];
        lineRenderer.useWorldSpace=false;  //use this to make the line renderer work in local space
    }


    // Update is called once per frame
    void Update()
    {
        // lineRenderer.SetPosition(0,this.transform.position);
        // lineRenderer.SetPosition(1,new Vector3(SOI.transform.position.x,SOI.transform.position.y+w,SOI.transform.position.z));

        // Vector3 q=lineRenderer.GetPosition(1);
        // dist= Vector3.Distance(SOI.transform.position,q);
        // if(dist<=20)
        // {
        //     // Debug.Log(dist);
        //     float a=getgravity(dist,0,SOIradius,0,G);
        //     Debug.Log("gravity is "+a+ "@" +SOI.transform.position.y);

        // }
        // lineRenderer.positionCount=length;

        lineRenderer.positionCount=length;
        segments=new Vector3[length];

        segments[0]=this.transform.position;

        for(int i=1;i<segments.Length;i++)
        {
            segments[i]=new Vector3(this.transform.position.x+i,this.transform.position.y,this.transform.position.z);
            // Collider[] ifinside=Physics.OverlapSphere(SOI.transform.position,SOIradius);
            // {
            //     // foreach( var s in ifinside)
            //     // {
            //     //     Debug.Log(i);
            //     // }
            //     float dis=Vector3.Distance(segments[i],SOI.transform.position);
            //     Debug.Log(dis);
            //     if(lineRenderer.gameObject.tag=="Player")
            //     {
            //         Debug.Log(i);
            //     }
            // }
        }
        lineRenderer.SetPositions(segments);
    }


    //re-mapping function
    float getgravity(float myvalue,float amin,float amax,float bmin,float bmax)
    {
        float s= bmin + (myvalue-amin)*(bmax-bmin)/(amax-amin);
        return 100-s;
    }
    //re-mapping function
}
