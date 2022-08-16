using UnityEngine;

///...proto2...///
///...REFACTORED

public class deadzonescript : MonoBehaviour
{
    void Start() 
    {
        if(SceneManagerscript.instance!=null)
            SceneManagerscript.instance.lvlcompletepanel.SetActive(false);
        // this.GetComponent<AnchorGameObject>().enabled=false;
    }
    void OnTriggerEnter(Collider i) 
    {
        if(i.transform.CompareTag("Player"))
        {
            ///...PLAYER HAS LOST THE LEVEL

            
            playermovementscript.instance.trailRenderer.time=0;

            GAMESTATES_MANAGER.instance.currentstate=GAMESTATES_MANAGER.gamestate.losescreen;
        }
    }
    void OnTriggerExit(Collider i) 
    {
        if(i.transform.CompareTag("Player"))
        {
            if(SceneManagerscript.instance!=null)
            {
                SceneManagerscript.instance.lvlcompletepanel.SetActive(true);
                SceneManagerscript.instance.losescreentxt.gameObject.SetActive(true);
                SceneManagerscript.instance.winscreentxt.gameObject.SetActive(false);
            }
            
            playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
        }    
    }
}
