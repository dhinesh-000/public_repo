using UnityEngine; 
using UnityEngine.UI; 

///...proto2
///...singleton
///...dontdestroyonload
public class gamemanager : MonoBehaviour
{

    public static gamemanager instance;
    // public Slider lvl_completion_slider;
    public int numberOfSpawnpoint;
    float f1=10;
    
    // public float total; ///... find the purpose of this variable
    
    // [HideInInspector]
    // public float t1,t2,t3;
    [HideInInspector]
    public float eachPercentage;
    [HideInInspector]
    public float eachPercentage_init;
    // public float combomultiplier;
    // public GameObject combotext;
    public AnimationCurve GAME_EXP_AC;

    [Space]
    [Header("TO BE SAVED")]

    public  float k;

    [HideInInspector]
    public  float k_initval;
    [HideInInspector]
    public float  i=0;
    [HideInInspector]
    public float i_initial;
    Keyframe lastkeytime;


    public int lumen;
    [HideInInspector]
    public int lumen_initial;

    // int m=0;
    public int TARGETFPS;
    public Text fps;
    public Text hz;
    
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
    void Start() 
    {
        Application.targetFrameRate=60;
        // yield return new WaitForSeconds(2f);
        eachPercentage=f1/numberOfSpawnpoint;
        eachPercentage_init=eachPercentage;
        Debug.Log(eachPercentage+"%");
        k_initval=k;
        i_initial=i;
        lumen_initial=lumen;

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
    // void FixedUpdate() 
    // {
    //     if(TARGETFPS!=Application.targetFrameRate)
    //     {
    //     Application.targetFrameRate=TARGETFPS;
    //     }   
    // }
    void Update() 
    {
        if(TARGETFPS!=Application.targetFrameRate)
        {
           Application.targetFrameRate=TARGETFPS;
        }   


        ///...gc allocating 
            // fps.text=Application.targetFrameRate.ToString("f3");
            // hz.text=Screen.currentResolution.refreshRate.ToString();
        ///...gc allocating 


        // if(combomultiplier>=1)
        // {    
        //     combotext.GetComponent<Text>().text=combomultiplier.ToString("f0");    
        // }
        // if(GAMESTATES_MANAGER.instance.currentstate==GAMESTATES_MANAGER.gamestate.mainmenu)
        // {
        //     Destroy(gameObject);
        // }
        ///...player xp
        if(SceneManagerscript.instance!=null)
        {
            SceneManagerscript.instance. Player_exp_slider.minValue=GAME_EXP_AC.Evaluate(i);  ///...zeroth value;
            SceneManagerscript.instance.Player_exp_slider.maxValue=GAME_EXP_AC.Evaluate(i+1);   ////...zero + 1th value;
            if(k>=SceneManagerscript.instance.Player_exp_slider.maxValue)
            {
                i++;
                // Debug.Log("working");
            }
            if(k>=GAME_EXP_AC.Evaluate(lastkeytime.time))
            {
                i=lastkeytime.time;
            }

            SceneManagerscript.instance.Player_exp_slider.value=k;
            SceneManagerscript.instance.lvl_indicator_text.text=i.ToString();
            ///...player xp
        }
       
    }
    public void playbuttonfunction()
    {
        ///... TO BE FILLED
    } 


      

}
