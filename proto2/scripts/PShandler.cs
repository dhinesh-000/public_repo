
using UnityEngine;


public class PShandler : MonoBehaviour
{
    public static PShandler instance;
    public GameObject rain_ps;
    public ParticleSystem ps;

    ParticleSystem.MainModule main;
    
    
    //  ParticleSystem.VelocityOverLifetimeModule vel;
    void Awake() 
    {   
        if(instance==null)
        {
            instance=this;         
        }   
        else
        {
            Destroy(gameObject);
        }
        ps=rain_ps.GetComponent<ParticleSystem>();
        rain_ps.SetActive(false);
        main=ps.main;
        // vel=ps.velocityOverLifetime;
    }
    public void insidefunction()
    {
        main.gravityModifier=-0.75f;
    }
    public void exitfunction()
    {
        main.gravityModifier=0.75f;
    }
}
