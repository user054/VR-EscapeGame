using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] FadeInOut fade;
    [SerializeField] FadeInOut fade2;

    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        fade.DisplayFadeInOutController(0, 0, 1, 0.01f);
        yield return new WaitForSeconds(3);
        fade.DisplayFadeInOutController(1, 1, 0, -0.01f);
        yield return new WaitForSeconds(1.5f);
        fade2.DisplayFadeInOutController(0, 0, 1, 0.01f);
    }

}
