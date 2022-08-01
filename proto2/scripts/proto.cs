using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;



// [RequireComponent(typeof(Rigidbody))]
public class proto : MonoBehaviour
{

    [Tooltip("distance from the ground")]
        public GameObject heighttext;
    [Tooltip("appx. velocity in the x dir")]
        public GameObject velocitytext;

        Rigidbody rb;
        float g;

        public float myboost;
        public GameObject distancefromstart;
        public Vector3 startpos;
       

        public GameObject cube;

       
        public GameObject boosttriggerGO;
        bool istrue;
        public GameObject boostGO;
        float h;
    void Start()
    {
        DOTween.SetTweensCapacity(2000,625);        
    }

    public void pausescene()
    {
        //works fine now
        Time.timeScale=0f;
        h=cube.GetComponent<Rigidbody>().velocity.x;
        cube.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
    }
    public void resumescene()
    {
        //works fine now
        Time.timeScale=1f;
        cube.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.None;
        cube.GetComponent<Rigidbody>().velocity=new Vector3(h,0,0);
    }
   
}
