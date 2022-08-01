using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///...proto2 
///...singleton
public class objpool : MonoBehaviour
{ 
 public static objpool instance;
//  public GameObject[] prefabvariants;
 public GameObject prefabvariant01;
 public int prefabvariant01count;
 public GameObject prefabvariant02;
 public int prefabvariant02count;
 public GameObject parent;
 public List<GameObject> mylistPV01=new List<GameObject>();
 public List<GameObject> mylistPV02=new List<GameObject>();
 void Awake() 
 {
    if(instance==null)
    {
        instance=this;  
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
    init();
 }

   

 public void init()
 {
     for (var i = 0; i < prefabvariant01count; i++)
    {   
        GameObject obj= Instantiate(prefabvariant01,this.transform.position,transform.localRotation=Quaternion.Euler(-90,0,0),parent.transform);
        obj.SetActive(false);
        mylistPV01.Add(obj);
    }   
    for (var i = 0; i < prefabvariant02count;i++)
    {
        GameObject obj= Instantiate(prefabvariant02,this.transform.position,transform.localRotation=Quaternion.Euler(-90,0,0),parent.transform);
        obj.SetActive(false);
        mylistPV02.Add(obj);
    }
 }
 
 public GameObject GetGameObjectPV01()
 {
    for(int i=0;i<=mylistPV01.Count;i++)
    {
        if(!mylistPV01[i].activeInHierarchy)
        {
            return mylistPV01[i];
        }
    }
    return null;
 }
  public GameObject GetGameObjectPV02()
 {
    for(int i=0;i<=mylistPV02.Count;i++)
    {
        if(!mylistPV02[i].activeInHierarchy)
        {
            return mylistPV02[i];
        }
    }
    return null;
 }
 public void reset(){
    for (int i=0;i<prefabvariant01count;i++)
    {
        if(mylistPV01[i].activeInHierarchy)
        {
            mylistPV01[i].SetActive(false);
        }
    }

 }
}
