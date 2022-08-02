using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollectaudio : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake() => audioSource=GetComponent<AudioSource>();
    private void OnEnable() => playermovementscript.coincollect +=playoneshotAudio;
    private void OnDisable() => playermovementscript.coincollect -=playoneshotAudio;
    private void playoneshotAudio() => audioSource.Play();
}
