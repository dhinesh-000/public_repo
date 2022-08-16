using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LOADINGSCREENscript : MonoBehaviour
{
    public static LOADINGSCREENscript instance;
    public Image loadingbar;
    void Awake() 
    {
        if(instance==null)
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }    
        else 
        {
            Destroy(gameObject);
        }
    }
    public  IEnumerator loadscene(int i)
    {
        AsyncOperation operation=SceneManager.LoadSceneAsync(i);

        while(!operation.isDone)
        {
            float progressvalue=Mathf.Clamp01(operation.progress/0.9f);
            loadingbar.fillAmount=progressvalue;
            if(progressvalue==1)
            {
                loadingbar.fillAmount=0f;
                Debug.Log("loaded");
            }
            yield return null;
            
        }
        
         
    }
}
