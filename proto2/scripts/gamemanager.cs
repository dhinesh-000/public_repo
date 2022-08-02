using System.Collections;
using UnityEngine;  
using UnityEngine.UI;
using DG.Tweening;

///...proto2
///...singleton
///...dontdestroyonload
public class gamemanager : MonoBehaviour
{
    public enum gamestate
    {
        mainmenu,
        ingame,
        winscreen,
        losescreen
    }
    ///...setting mainmenu as the default gamestate
    public gamestate currentstate=gamestate.mainmenu;
    public static gamemanager instance;
    // public Slider lvl_completion_slider;
    public int numberOfSpawnpoint;
    float f1=10;
    
    public float total;
    // [HideInInspector]
    // public float t1,t2,t3;
    [HideInInspector]
    public float eachPercentage;
    [HideInInspector]
    public float eachPercentage_init;
    // public float combomultiplier;
    // public GameObject combotext;
    public AnimationCurve GAME_EXP_AC;
    public GameObject lvl_indicator_text;

    // float h;
    public Slider Player_exp_slider;
    public  float k;
    [HideInInspector]
    public  float k_initval;
    [HideInInspector]
    public float  i=0;
    [HideInInspector]
    public float i_initial;
    Keyframe lastkeytime;
    public int lumen;
    public Toggle settingicon;
    // public Toggle crediticon;
    public GameObject settingpanel;
    public GameObject creditpanel;
    public float transitiontime;
    public Ease ease;
    public GameObject coinholder;
    
    void Awake() 
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Start() 
    {
        yield return new WaitForSeconds(2f);
        eachPercentage=f1/numberOfSpawnpoint;
        eachPercentage_init=eachPercentage;
        Debug.Log(eachPercentage+"%");
        k_initval=k;
        i_initial=i;

        lastkeytime=GAME_EXP_AC[GAME_EXP_AC.length-1]; ///...last key frame of the GAME_EXP_AC animation curve;
        // Debug.Log(lastkeytime.time);///...gives the time value of the last keyframe;
        // Debug.Log(GAME_EXP_AC.Evaluate(lastkeytime.time));///... gives  the float value corresponding to this specific time value;
        // Debug.Log(GAME_EXP_AC.Evaluate(0)+"XP");
        // for(int i=1;i<=lastkeytime.time;i++)
        // {
        //     h=GAME_EXP_AC.Evaluate(i) - GAME_EXP_AC.Evaluate(i-1);
        //     Debug.Log(h.ToString("f3")+"XP more needed to level up");
        //     Debug.Log( "Needed "+GAME_EXP_AC.Evaluate(i).ToString("f3")+" XP"+ " to complete "+" LEVEL "+i);
        // }
       
    }
    void Update() 
    {
        if(SceneManagerscript.instance.mainmenu.activeInHierarchy)
        {
            currentstate=gamestate.mainmenu;
        }
        else if(!SceneManagerscript.instance.mainmenu.activeInHierarchy )
        {
            currentstate=gamestate.ingame;
        }
        if(SceneManagerscript.instance.winscreentxt.activeInHierarchy)
        {
            currentstate=gamestate.winscreen;
        }
        else if(SceneManagerscript.instance.losescreentxt.activeInHierarchy)
        {
            currentstate=gamestate.losescreen;
        }       
        // if(combomultiplier>=1)
        // {    
        //     combotext.GetComponent<Text>().text=combomultiplier.ToString("f0");    
        // }
        
        ///...player xp
        Player_exp_slider.minValue=GAME_EXP_AC.Evaluate(i);  ///...zeroth value;
        Player_exp_slider.maxValue=GAME_EXP_AC.Evaluate(i+1);   ////...zero + 1th value;
        if(k>=Player_exp_slider.maxValue)
        {
            i++;
            // Debug.Log("working");
        }
        if(k>=GAME_EXP_AC.Evaluate(lastkeytime.time))
        {
            i=lastkeytime.time;
        }

        Player_exp_slider.value=k;
        lvl_indicator_text.GetComponent<Text>().text=i.ToString("f0");
        ///...player xp


        ///...player is in mainmenu screen
        if(currentstate==gamestate.mainmenu)
        {
            if(settingicon.isOn==true)
            {
                settingpanel.SetActive(true);
            }
            else if(settingicon.isOn==false)
            {
                settingpanel.SetActive(false);
                creditpanel.SetActive(false);
            } 
            SceneManagerscript.instance.ui.SetActive(false);
            playermovementscript.instance.gameObject.SetActive(false);
            PShandler.instance.gameObject.SetActive(false);
            // coinholder.SetActive(false);

            
        }
        ///...player is in mainmenu screen

        ///...player is in gamemode
        else if(currentstate==gamestate.ingame)
        {
            SceneManagerscript.instance.ui.SetActive(true);
            playermovementscript.instance.gameObject.SetActive(true);
            SceneManagerscript.instance.mainmenu.SetActive(false);
            PShandler.instance.gameObject.SetActive(true);
            // coinholder.SetActive(true);s
        }
        ///...player is in gamemode
       
    }
    public void pointerdownfunc()
    {
        creditpanel.SetActive(true);
    }
    public void pointerupfunc()
    {
        creditpanel.SetActive(false);
    }
    public void playbuttonfunction()
    {
        SceneManagerscript.instance.fillimage.alpha=1;
        SceneManagerscript.instance.mainmenu.SetActive(false);
        DOVirtual.Float(1,0,transitiontime,v=>SceneManagerscript.instance.fillimage.alpha=v).SetEase(ease);
    }     

}
