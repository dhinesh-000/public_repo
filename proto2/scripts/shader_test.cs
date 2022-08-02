using DG.Tweening;
using UnityEngine;

public class shader_test : MonoBehaviour
{
    float k=2;
    float l=-4.14f;
    public GameObject[] variant01;
    public GameObject[] variant02;
    void Update()
    {
        ///..design variant 01
        if(Input.GetKey(KeyCode.L))
        {
            if(k<=5)
                k+=Time.deltaTime;
            for(int i=0;i<variant01.Length;i++)
            {
                variant01[i].GetComponent<Renderer>().material.SetFloat("_control2",k);
            }
        }
        ///..design variant 01

        ///..design variant 02
        if(Input.GetKey(KeyCode.Q))
        {
            if(l<=-1.50f)
                l+=Time.deltaTime;  
            variant02[0].GetComponent<Renderer>().material.SetVector("_control2",new Vector3(l,-1.35f,0));

            if(k<=5)
                k+=Time.deltaTime;
            variant02[1].GetComponent<Renderer>().material.SetFloat("_control2",k);
        }
        ///..design variant 02

    }
}
