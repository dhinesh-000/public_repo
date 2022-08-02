using Cinemachine;
using UnityEngine;
using DG.Tweening;

///...proto2
///...singleton

///...EVERY SINGLETON CLASS MUST HAVE A MINIMUM OF TWO REFERENCES IN THE AWAKE SECTION OF THE CLASS...///
public class VCamHandler : MonoBehaviour
{
    public static VCamHandler instance;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public float intensity,intensity1;
    public float shaketime,shaketime1;
    void Awake() 
    {
      if(instance==null)
        {instance=this;
        DontDestroyOnLoad(gameObject);}
      else 
        Destroy(gameObject);
    }
    void Start() 
    {
      cinemachineVirtualCamera=GetComponent<CinemachineVirtualCamera>();
      cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain=0f;
    }
  public void shakecam()
  {
    ///...camera shake
      Debug.Log("shaking");
      CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

      DOVirtual.Float(intensity,0,shaketime, v =>cinemachineBasicMultiChannelPerlin.m_AmplitudeGain=v);        
    ///...camera shake
      
  } 
  public void shakecamforboost()
  {
    ///...camera shake
      Debug.Log("shaking");
      CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin=cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

      DOVirtual.Float(intensity1,0,shaketime1, v =>cinemachineBasicMultiChannelPerlin.m_AmplitudeGain=v);        
    ///...camera shake
      
  } 
         
}
