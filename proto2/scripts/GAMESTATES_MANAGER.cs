using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMESTATES_MANAGER : MonoBehaviour
{
    public enum gamestate
    {
        mainmenu,
        ingame,
        pausemenu,
        progressmenu,
        lose
        
    }
    ///...setting mainmenu as the default gamestate
    public gamestate currentstate;
    public static GAMESTATES_MANAGER instance;
    void Awake() 
    {
        instance=this;       
    }
}
