using DG.Tweening;
using UnityEngine;

public class pathtest : MonoBehaviour
{
    public Vector3[] waypoints;
    public float durationToComplete;
    public PathType pathType;
    public PathMode pathMode;
    public int resolution;
    public Ease ease;
    public LoopType loopType;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOPath(waypoints,durationToComplete,pathType,pathMode,resolution).SetEase(ease).SetLoops(-1,loopType);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
