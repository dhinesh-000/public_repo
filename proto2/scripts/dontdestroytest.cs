using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroytest : MonoBehaviour
{
    public static dontdestroytest instance;
    private void Awake() 
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
