using System.Collections;
using UnityEngine;

public class deadzonescript : MonoBehaviour
{
    public GameObject lvlcompletepanel;
    private void Start() {
        lvlcompletepanel.SetActive(false);
        this.GetComponent<AnchorGameObject>().enabled=false;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log("dead");

            StartCoroutine(startfunction());
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            playermovementscript.instance.GetComponent<TrailRenderer>().time=0f;
            playermovementscript.instance.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
        }    
    }
    IEnumerator startfunction()
    {
        yield return new WaitForSeconds(1f);
        // SceneManagerscript.instance.retrylevelfunction();
        lvlcompletepanel.SetActive(true);
        
    }
}
