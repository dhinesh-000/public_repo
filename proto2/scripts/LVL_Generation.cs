using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///...proto2 
///...singleton
public class LVL_Generation : MonoBehaviour
{
    public bool prefabvariant01;
    public bool prefabvariant02;

    void Start()
    {
        if(prefabvariant01==true)
        {
            // yield return new WaitForSeconds(1f);
            GameObject j=objpool.instance.GetGameObjectPV01();
            if(j!=null)
            {
                j.transform.position=this.transform.position;
                j.SetActive(true);
            }       
        }
        if(prefabvariant02==true)
        {
            // yield return new WaitForSeconds(1f);
            GameObject j=objpool.instance.GetGameObjectPV02();
            if(j!=null)
            {
                j.transform.position=this.transform.position;
                j.SetActive(true);
            }       
        }
    }


}
