using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameStartSet : MonoBehaviour
{
    [SerializeField] GameObject depth;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject ui2;
    [SerializeField] FadeInOut fade;
    [SerializeField] FadeInOut fade2;
    [SerializeField] GameObject logo;
    [SerializeField] ContinuousMoveProviderBase continuousMove;
    [SerializeField] Collider[] colliders;
    [SerializeField] AudioSource audioSource;


    public void GameStart()
    {
        StartCoroutine(StartCoroutine());
        audioSource.PlayOneShot(audioSource.clip);
    }

    IEnumerator StartCoroutine()
    {
        ui2.SetActive(false);
        fade.DisplayFadeInOutController(1,1,0,-0.005f);
        //fade2.DisplayFadeInOutController(1,1,0,-0.01f);
        logo.SetActive(false);
        yield return new WaitForSeconds(1.8f);
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = true;
        }
        ui.SetActive(false);
        continuousMove.enabled = true;
    }

}
