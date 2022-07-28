
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

    public CanvasGroup fillimage;
    public float SCENEtransitiontime;
    public Text loadingtext;
    public Slider vel_indicator;
    public GameObject mainmenu;
    public GameObject player;
    public GameObject ui;

    public GameObject lvl;
   
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
    public void retrylevelfunction()
    {

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playermovementscript.instance.transform.position=playermovementscript.instance.startpos_initsetting;
        playermovementscript.instance.rb.velocity=new Vector3(0,0,0);
        playermovementscript.instance.GetComponent<TrailRenderer>().time=300;
        lvlcompletepanel.SetActive(false);

        ///...since the  variables is marked as dontdestroyonload this value has to be harcoded to what we need 
        gamemanager.instance.total=0;
        gamemanager.instance.k=gamemanager.instance.k_initval;
        ///...since the  variables is marked as dontdestroyonload this value has to be harcoded to what we need
        
        objpool.instance.reset();
    }

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

    public void homebuttonfunction()
    {
        DOVirtual.Float(0,1,SCENEtransitiontime,v=>fillimage.alpha=v).SetEase(Ease.InCubic);
        lvlcompletepanel.SetActive(false);
        ui.SetActive(false);      
        DOVirtual.Float(1,0,SCENEtransitiontime,v=>fillimage.alpha=v).SetEase(Ease.InCubic);
        StartCoroutine(call());

    }
    IEnumerator call()
    {
        yield return new WaitForSeconds(1f);
        mainmenu.SetActive(true);
    }

    
   
}
