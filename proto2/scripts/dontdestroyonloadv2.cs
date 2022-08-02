using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyonloadv2 : MonoBehaviour
{
    void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }  
    
}
