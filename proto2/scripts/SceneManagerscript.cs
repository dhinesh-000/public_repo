
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
///...proto2...///
///singleton

public class SceneManagerscript : MonoBehaviour
{
    public static SceneManagerscript instance;
    public GameObject lvlcompletepanel;
    public GameObject winscreentxt;
    public GameObject losescreentxt;

    public CanvasGroup fillimage;
    public float SCENEtransitiontime;
    // public Text loadingtext;
    public Slider vel_indicator;
    public GameObject mainmenu;
    // public GameObject player;
    public GameObject ui;
    public GameObject lumentxt;

     public GameObject veltext;
   
     void Awake() 
    {
        ///...put the bundle identifier after '=' section 
        // Application.OpenURL ("market://details?id=");

        if(instance==null)
        {  
            instance=this;
            DontDestroyOnLoad(gameObject);
        }   
        else    
            Destroy(gameObject);

        fillimage.alpha=0;
    }
    void Update() 
    {
        vel_indicator.value=playermovementscript.instance.rb.velocity.x;
        veltext.GetComponent<Text>().text=playermovementscript.instance.rb.velocity.x.ToString("f1");
        if(lvlcompletepanel.activeInHierarchy)
        {
            Time.timeScale=0;
            // AudioListener.pause = true;
        }   
        else
        {
            // AudioListener.pause=false; 
        }

        if(lvlcompletepanel.activeInHierarchy)
        {
            PlayerPrefs.SetFloat("PLAYER_EXP",gamemanager.instance.k);
            // Debug.Log(PlayerPrefs.GetFloat("PLAYER_EXP"));
        }

                   
    }
    ///...btn
    public void retrylevelfunction()
    {
        ///... use this clear line to remove dotween target missing/field errors
        DOTween.Clear(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playermovementscript.instance.transform.position=playermovementscript.instance.startpos_initsetting;
        playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
        playermovementscript.instance.GetComponent<TrailRenderer>().time=300;
        lvlcompletepanel.SetActive(false);

        ///...since the  variables is marked as dontdestroyonload this value has to be harcoded to what we need 
        gamemanager.instance.total=0;
        gamemanager.instance.k=gamemanager.instance.k_initval;
        gamemanager.instance.i=gamemanager.instance.i_initial;
        ///...since the  variables is marked as dontdestroyonload this value has to be harcoded to what we need
        
        objpool.instance.reset();
    }
    ///...btn

    ///...btn
    public void loadnextlevelfunction()
    {

        DOVirtual.Float(0,1,SCENEtransitiontime,v=>fillimage.alpha=v).SetEase(Ease.InCubic);
        
        AsyncOperation operation= SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        
        // yield return new WaitForSeconds(operation.progress);
        DOVirtual.Float(1,0,SCENEtransitiontime,v=>fillimage.alpha=v).SetEase(Ease.InCubic);

        playermovementscript.instance.transform.position=playermovementscript.instance.startpos_initsetting;
        playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
        lvlcompletepanel.SetActive(false);

        ///...since the variables is marked as dontdestroyonload this value has to be harcoded to what we need
        gamemanager.instance.total=0;
        gamemanager.instance.k_initval=gamemanager.instance.k;
        gamemanager.instance.k=PlayerPrefs.GetFloat("PLAYER_EXP");
        ///...since the  variables is marked as dontdestroyonload this value has to be harcoded to what we need

        objpool.instance.reset();
        
    }
    ///...btn


    ///...btn
    public void homebuttonfunction()
    {
        DOVirtual.Float(0,1,SCENEtransitiontime,v=>fillimage.alpha=v).SetEase(Ease.InCubic);
        lvlcompletepanel.SetActive(false);
        ui.SetActive(false);      
        DOVirtual.Float(1,0,SCENEtransitiontime,v=>fillimage.alpha=v).SetEase(Ease.InCubic);
        StartCoroutine(call());

    }
    ///...btn
    IEnumerator call()
    {
        yield return new WaitForSeconds(1f);
        mainmenu.SetActive(true);
    }

    
   
}
