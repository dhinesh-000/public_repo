using UnityEngine;

public class dontdestroyonloadscript : MonoBehaviour
{
    public static dontdestroyonloadscript instance;
       
    void Awake() 
    {
        if(instance==null)
        {
            DontDestroyOnLoad(gameObject);     
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
