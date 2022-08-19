using UnityEngine;

///...proto2...///
///...singleton
///...REFACTORED
public class nextlvltrigger : MonoBehaviour
{
    public static nextlvltrigger instance;
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
        this.GetComponentInParent<AnchorGameObject>().enabled=false;
    }
    void OnTriggerEnter(Collider i)
    {
        if(i.transform.CompareTag("Player"))
        {
            ///...PLAYER HAS WON THE LEVEL
            GAMESTATES_MANAGER.instance.currentstate=GAMESTATES_MANAGER.gamestate.progressmenu;
            playermovementscript.instance.trailRenderer.time=0;
        }
    }
    void OnTriggerExit(Collider i) 
    {
        if(i.transform.CompareTag("Player"))
        {
            SceneManagerscript.instance.lvlcompletepanel.SetActive(true); 
            SceneManagerscript.instance.winscreentxt.gameObject.SetActive(true);
            SceneManagerscript.instance.losescreentxt.gameObject.SetActive(false);

            playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
        }
    }
}
