using System.Collections;
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

    float h;
    public Slider Player_exp_slider;
    public  float k;
    public float k_initval;
    float  i=0;
    Keyframe lastkeytime;
    public int lumen;


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

        // eachPercentage=f1/numberOfSpawnpoint;
       
        // f1=GAME_EXP_AC.Evaluate(i+1);
        // lvl_completion_slider.maxValue=GAME_EXP_AC.Evaluate(i+1);
        // lvl_completion_slider.value=total;
        
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


    }

}
