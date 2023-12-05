using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JewelSound : TriggerButton
{
    [SerializeField] AudioSource clickAudio;
    [SerializeField] string sceneName;
    [SerializeField] FadeInOut fade;

    private void Start()
    {
        triggerButtonDelegate = new TriggerButtonActiveDelegate(Clickset);

    }

    public void Clickset()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        StartCoroutine(SceneChange());
    }



    IEnumerator SceneChange()
    {
        fade.DisplayFadeInOutController(0, 0, 1, 0.01f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }





}
