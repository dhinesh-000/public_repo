using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

///...proto2...///
///singleton
///...REFACTORED
public class SceneManagerscript : MonoBehaviour
{
    public static SceneManagerscript instance;
    public GameObject lvlcompletepanel;
    public Text winscreentxt;
    public Text losescreentxt;
    // public Slider vel_indicator;
    public Text lumentxt;
    public Toggle timetoggle;
    public Text lvl_indicator_text;
    public Slider Player_exp_slider;
    // public Text dist_Travelledtext;
    // public Slider slider_time;
    public Button magnetradiusBTN;
    public Text albumname_text;
    public RectTransform panel;
    
    public Vector2 y1,y2;
    [HideInInspector]
    public bool a=false,b=false;
    void Awake() 
    {
        ///...google review handler
        ///...put the bundle identifier after '=' section 
        // Application.OpenURL ("market://details?id=");

        if(instance==null)
        {  
            instance=this;
            DontDestroyOnLoad(gameObject);
        }   
        else    
            Destroy(gameObject);

    }
   public void pause()
    {
        panel.DOAnchorPos(y1,2).SetUpdate(true);
        a=true;
    }
    public void close()
    {
        panel.DOAnchorPos(y2,2f).SetUpdate(true);
        b=true;
    }
    ///...btn
    public void retrylevelfunction()
    {
        
        DOTween.PauseAll();

        
        
        lvlcompletepanel.SetActive(false);

        playermovementscript.instance.transform.position=playermovementscript.instance.startpos_initsetting;///...setting the player back to its initial position at the start of the level
        playermovementscript.instance.rb.velocity=new Vector3(0,0,0); ///...setting the player velocity to zero
        gamemanager.instance.k=gamemanager.instance.k_initval;
        gamemanager.instance.i=gamemanager.instance.i_initial;
        gamemanager.instance.lumen=gamemanager.instance.lumen_initial;


        GAMESTATES_MANAGER.instance.currentstate=GAMESTATES_MANAGER.gamestate.ingame;

        StartCoroutine(LOADINGSCREENscript.instance.loadscene(SceneManager.GetActiveScene().buildIndex));
        StartCoroutine(trailfunc());
    }

    ///...btn

    ///...btn
    public void loadnextlevelfunction()
    {
        DOTween.PauseAll();

        StartCoroutine(LOADINGSCREENscript.instance.loadscene(SceneManager.GetActiveScene().buildIndex+1));       

        lvlcompletepanel.SetActive(false);

        playermovementscript.instance.transform.position=playermovementscript.instance.startpos_initsetting;
        playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
        gamemanager.instance.k_initval=gamemanager.instance.k;
        gamemanager.instance.k=PlayerPrefs.GetFloat("PLAYER_EXP");


        GAMESTATES_MANAGER.instance.currentstate=GAMESTATES_MANAGER.gamestate.ingame;

        SAVESYSTEMscript.instance.saveGameData();
        
        StartCoroutine(trailfunc());
       
    }
    ///...btn
    IEnumerator  trailfunc()
    {       
        yield return new WaitForSeconds(3f);
        playermovementscript.instance.trailRenderer.time=10;
    }
    
    ///...btn
    public void homebuttonfunction()
    {
        StartCoroutine(LOADINGSCREENscript.instance.loadscene(0));
        GAMESTATES_MANAGER.instance.currentstate=GAMESTATES_MANAGER.gamestate.mainmenu;

        ///...true value set in mainmenuscript
        playermovementscript.instance.gameObject.SetActive(false);
        audiomanager.instance.volume.enabled=false;
        PShandler.instance.rain_ps.SetActive(false);
        // audiomanager.instance.gameObject.SetActive(false);
    }
    ///...btn

    
   
}
