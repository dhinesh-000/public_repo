using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dicttest : MonoBehaviour
{
    

    Dictionary<string ,int> mydict=new Dictionary<string, int>();
    void Start()
    {
        mydict.Add("apple",5);
        mydict.Add("orange",10);

        Debug.Log(mydict["apple"]);
        
        Debug.Log(mydict.Remove("orange"));
        Debug.Log(mydict.Values);
        
        
    }

    
    void Update()
    {
        
    }
}
