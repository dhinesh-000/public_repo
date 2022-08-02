using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerend : MonoBehaviour
{
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentposes;
    private Vector3[] segmentV;

    public Transform  targetdir;
    public float targetdist;
    public float smoothspeed;
    public float trailspeed;
    void Start() 
    {
        lineRenderer.positionCount=length;
        segmentposes=new Vector3[length];
        segmentV=new Vector3[length];

    }
    void Update() 
    {
        segmentposes[0]=targetdir.position;
 
        for(int i=1;i<segmentposes.Length;i++)
        {
            segmentposes[i]=Vector3.SmoothDamp(segmentposes[i],segmentposes[i-1]+targetdir.right*targetdist,ref segmentV[i],smoothspeed+i/trailspeed);
        }   
        lineRenderer.SetPositions(segmentposes);
    }
}
