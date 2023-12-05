using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : TriggerButton
{
    [SerializeField] AudioSource backGroundMusic;
    [SerializeField] Animator handle;
    //[SerializeField] Animator LP;
    bool musicState = true;

    private void Start()
    {
        triggerButtonDelegate = new TriggerButtonActiveDelegate(MusicControl);
    }

    public void MusicControl()
    {
        if(musicState == false)
        {
            MusicPlay();
            musicState = true;
        }
        else
        {
            MusicStop();
            musicState = false;
        }
    }

    public void MusicPlay()
    {
        backGroundMusic.PlayOneShot(backGroundMusic.clip);
        handle.SetBool("Play", true);
    }

    public void MusicStop()
    {
        backGroundMusic.Stop();
        handle.SetBool("Play", false);

    }




}
