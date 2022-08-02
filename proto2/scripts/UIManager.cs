using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject btn1,btn2;
    

    ///...pinterest btn test
    public void testfuncDOWN()
    {
        btn1.gameObject.SetActive(true);
        btn2.gameObject.SetActive(true);
    }
    public void testfuncUP()
    {
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
    }
    public void btn1func(){Debug.Log("btn1");}
    public void btn2func(){Debug.Log("btn2");}
    ///...pinterest btn test
}
