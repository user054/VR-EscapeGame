using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneChange : MonoBehaviour
{
    [SerializeField] FadeInOut fade;
    [SerializeField] AudioSource audioSource;
    [SerializeField] string nextScene;

    public void EndingSceneChangeFunc()
    {
        StartCoroutine(EndingSceneChangeCoroutine());
        audioSource.PlayOneShot(audioSource.clip);
    }

    IEnumerator EndingSceneChangeCoroutine()
    {
        fade.DisplayFadeInOutController(0, 0, 1, 0.01f);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(nextScene);
    }



}
