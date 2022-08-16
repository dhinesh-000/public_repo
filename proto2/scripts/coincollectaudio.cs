using DG.Tweening;
using UnityEngine;

///...REFACTORED...///
public class coincollectaudio : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake() => audioSource=GetComponent<AudioSource>();
    private void OnEnable() =>coinanimations.coincollect +=playoneshotAudio;
    private void OnDisable() =>coinanimations.coincollect -=playoneshotAudio;
    private void playoneshotAudio() 
    {
        audioSource.Play();
        gamemanager.instance.lumen++;  
        SceneManagerscript.instance.lumentxt.color=new Color(1,1,1,1);
        SceneManagerscript.instance.lumentxt.DOColor(new Color(0,0,0,0),4f);    
        SceneManagerscript.instance.lumentxt.text=gamemanager.instance.lumen.ToString();
    } 
}
