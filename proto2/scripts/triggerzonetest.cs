using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerzonetest : MonoBehaviour
{
    // Start is called before the first frame update
    public float G; 
    public float gravitymultiplier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() 
    {

        float m1=20;
        float m2=playermovementscript.instance.rb.mass;
        float r=Vector3.Distance(this.transform.position,playermovementscript.instance.transform.position);

        playermovementscript.instance.rb.AddForce((this.transform.position-playermovementscript.instance.transform.position). normalized*(G*(m1*m2)/(r*r))*Time.fixedDeltaTime*gravitymultiplier,ForceMode.Impulse);    
    }
}
