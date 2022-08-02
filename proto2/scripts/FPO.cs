using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPO : MonoBehaviour
{
    public  GameObject player;
    public GameObject sphereofinfluence;
    public GameObject testsphere;
    public float threshold;
    float temp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var refpos=player.transform.position;
     


        if(refpos.magnitude>threshold)
        {   
            temp+=0.1f;
            Debug.Log(temp);
            if(temp>5)
            {
                Debug.Log("animations");
                player.transform.position=new Vector3(0,player.transform.position.y,player.transform.position.z);
                temp=0;
            }
            //  StartCoroutine(fpo());
            
            // Invoke("fpoinvoke",20f*Time.deltaTime);
            // this.transform.Translate(player.transform.position*-1);
            // sphereofinfluence.transform.position=new Vector3(sphereofinfluence.transform.position.x-20,sphereofinfluence.transform.position.y,sphereofinfluence.transform.position.z);

            // testsphere.transform.position=new Vector3(testsphere.transform.position.x-50,testsphere.transform.position.y,testsphere.transform.position.z);

        }
    }
    // IEnumerator fpo()
    // {
    //     Debug.Log("playing animation");
    //     yield  return new WaitForSeconds(20f*Time.deltaTime);
    //     Debug.Log("end");
    //     player.transform.position=new Vector3(0,player.transform.position.y,player.transform.position.z);
    // }
    // void fpoinvoke()
    // {
    //     player.transform.position=new Vector3(0,player.transform.position.y,player.transform.position.z);
    // }
}
