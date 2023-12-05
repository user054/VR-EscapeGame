using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartScene : MonoBehaviour
{
    [SerializeField] FadeInOut fade;
    [SerializeField] Collider []collider;
    [SerializeField] ContinuousMoveProviderBase continuousMove;

    private void Start()
    {
        StartCoroutine(StartSceneSet());
    }

    IEnumerator StartSceneSet()
    {
        fade.DisplayFadeInOutController(1, 1, 0, -0.01f);
        yield return new WaitForSeconds(1.5f);
        for(int i = 0; i < collider.Length; i++)
        {
            collider[i].enabled = false;
        }
        continuousMove.enabled = true;
    }

}
