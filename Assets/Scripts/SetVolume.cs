using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    private AudioSource audio;
    private float _volume = 1f;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audio.volume = _volume;
    }
    public void SetVolumeLevel(float volume)
    {
        _volume = volume;
    }
}