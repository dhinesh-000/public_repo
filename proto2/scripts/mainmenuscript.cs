using UnityEngine.UI;
using UnityEngine;

public class mainmenuscript : MonoBehaviour
{
    public static mainmenuscript instance;
    public Button[] LEVELS;
    public GameObject settingpanel;
    public GameObject creditpanel;
    
    int m=0;
    public int[] magnetlifetimeupgrades={10,20,30,40,50};
    void Awake() 
    {
        instance=this;    
    }
    ///...CREDIT PANEL
    public void OnPointerDown()
    {
        ///...player should hold the button to pop up the credit section
        creditpanel.SetActive(true);
    }
    public void OnPointerUp()
    {
        ///...player disengages the button to close the credit section
        creditpanel.SetActive(false);
    }
    ///...CREDIT PANEL

    ///...SETTING PANEL
    public void onselect()
    {
        settingpanel.SetActive(true);
    }
    public void ondeselect()
    {
        settingpanel.SetActive(false);
    }
    ///...SETTING PANEL


    public void magnetLIFETIMEpowerupbuyFUNCTION()
    {
        if(gamemanager.instance.lumen>=magnetlifetimeupgrades[m])
        {
            Debug.Log(magnetlifetimeupgrades[m]);
            playermovementscript.instance.magnetlifetime+=5;
            gamemanager.instance.lumen-=magnetlifetimeupgrades[m];
            m++;
            Debug.Log("powered up");
            Debug.Log(magnetlifetimeupgrades[m]);
        }  
    }
    ///...SCENE SELECTION
    public void LEVELSELECTOR(int i)
    {
        GAMESTATES_MANAGER.instance.currentstate=GAMESTATES_MANAGER.gamestate.ingame;
        ///...false value set in scenemanagerscript
        playermovementscript.instance.gameObject.SetActive(true);
        audiomanager.instance.volume.enabled=true;
        PShandler.instance.rain_ps.SetActive(true);

        
        StartCoroutine(LOADINGSCREENscript.instance.loadscene(i));
    }
    ///...SCENE SELECTION
    
}
