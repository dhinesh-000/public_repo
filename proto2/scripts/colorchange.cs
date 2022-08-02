using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class colorchange : MonoBehaviour
{
    // select select=new select();
     public bool selected;

    [HideInInspector]
    public bool isitactive;
    // Update is called once per frame
    void Update()
    {
        

        if(selected)
        {
            this.GetComponent<MeshRenderer>().material.color=Color.blue;
            isitactive=true;
            this.GetComponent<Lean.Touch.LeanDragTranslate>().enabled=true;
            this.GetComponent<Lean.Touch.LeanTwistRotateAxis>().enabled=true;
            this.GetComponent<Lean.Touch.LeanPinchScale>().enabled=true;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.color=Color.white;
            isitactive=false;

            this.GetComponent<Lean.Touch.LeanDragTranslate>().enabled=false;
            this.GetComponent<Lean.Touch.LeanTwistRotateAxis>().enabled=false;
            this.GetComponent<Lean.Touch.LeanPinchScale>().enabled=false;
        }
    }
    public void boolchange()
    {
        selected=!selected;

        
    }
}
