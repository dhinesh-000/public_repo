using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polkadottouch : MonoBehaviour
{

    // public float posterizelvl;
  void Start()
  {
       
  }
  
  void Update()
  {
    // this.GetComponent<Renderer>().material.SetFloat("_posterizelevels",posterizelvl); 
      ///...must use renderer component to use the params of the shader material properties...///

    this.GetComponent<Renderer>().material.SetVector("_pos",new Vector3(
                                            mousePositionX(Input.mousePosition.x,0,Screen.width,-0.5f,0.5f),
                                            mousePositionY(Input.mousePosition.y,0,Screen.height,-0.5f,0.5f),
                                            0)); ///...working...///
    // this.GetComponent<Renderer>().material.SetFloat("_posx", mousePositionX(Input.mousePosition.x,0,Screen.width,0.5f,-0.5f));

    // this.GetComponent<Renderer>().material.SetFloat("_posy",mousePositionY(Input.mousePosition.y,0,Screen.height,0.5f,-0.5f));
  }
    
    //remapping function
    float mousePositionX(float myvalue,float amin,float amax,float bmin,float bmax)
    {
        float s= bmin + (myvalue-amin)*(bmax-bmin)/(amax-amin);
        return s;
    }
    float mousePositionY(float myvalue,float amin,float amax,float bmin,float bmax)
    {
        float s= bmin + (myvalue-amin)*(bmax-bmin)/(amax-amin);
        return s;
    }
}
