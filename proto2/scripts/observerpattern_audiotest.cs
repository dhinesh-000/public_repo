using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observerpattern_audiotest : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake() => audioSource=GetComponent<AudioSource>();
    private void OnEnable() => triggerzone.OnplayerEnter +=playoneshotAudio;
    private void OnDisable() => triggerzone.OnplayerEnter -=playoneshotAudio;
    private void playoneshotAudio() => audioSource.Play();
}
