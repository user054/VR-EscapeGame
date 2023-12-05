using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoketSound : MonoBehaviour
{
    [SerializeField] AudioSource soketAudio;

    public void AudioPlay()
    {
        soketAudio.PlayOneShot(soketAudio.clip);
    }






}
