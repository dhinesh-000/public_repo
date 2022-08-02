using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///...proto2...///
///singleton
public class nextlvltrigger : MonoBehaviour
{
    public static nextlvltrigger instance;
    // public GameObject lvlcompletepanel;
    [HideInInspector]
    public bool lvlcomplete;
      void Awake() 
    {
        if(instance==null)
            instance=this;
        else    
            Destroy(gameObject);
    }
    void Start()
    {
        SceneManagerscript.instance.lvlcompletepanel.SetActive(false);
        // this.GetComponent<AnchorGameObject>().enabled=false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log( "level complete");
            //lvlcompletepanel.SetActive(true);
            SceneManagerscript.instance.lvlcompletepanel.SetActive(true); 
            playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
            gamemanager.instance.currentstate=gamemanager.gamestate.winscreen;
            SceneManagerscript.instance.losescreentxt.SetActive(false);
            SceneManagerscript.instance.winscreentxt.SetActive(true);
            // lvlcomplete=true;

        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.transform.CompareTag("Player"))
        {
            lvlcomplete=true;
            playermovementscript.instance.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
        }
    }
}
