using UnityEngine;
using UnityEngine.UI;

public class polkadottouch : MonoBehaviour
{
    public Camera cameraGO;
    // public Image image;
    Vector3 pos;
    void Awake() 
    {
      cameraGO=Camera.main;
    }
    void Update() 
    {  
      
        pos= cameraGO.ScreenToViewportPoint(Input.mousePosition);
        this.GetComponent<Image>().material.SetFloat("_posx",pos.x);
        this.GetComponent<Image>().material.SetFloat("_posy",pos.y);
      
    }
}
