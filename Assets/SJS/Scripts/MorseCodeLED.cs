using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCodeLED : MonoBehaviour
{
    [SerializeField] Renderer ledLight;
    [SerializeField] AudioSource audioSource;
    // 0 = Short, 1 = Long
    [SerializeField] AudioClip[] audioClips;
    //[SerializeField] MorseCodeButton morseCodeButton;
    bool morseCodeCheck = true;

    public void Light_ON_OFF(MorseCodeButton morseCodeButton)
    {
        if(morseCodeCheck == true)
        {
            morseCodeButton.ActionCheck = true;
            StartCoroutine(MorseCodeActiveCoroutine(morseCodeButton));
        }
    }

    IEnumerator MorseCodeActiveCoroutine(MorseCodeButton morseCodeButton)
    {
        morseCodeCheck = false;
        for (int i = 0; i < morseCodeButton.LightCount; i++)
        {
            ledLight.material.color = Color.yellow;
            if(morseCodeButton.ReadyTime[i] == 0.5f)
            {
                audioSource.PlayOneShot(audioClips[0]);
            }
            else if(morseCodeButton.ReadyTime[i] >= 1.0f)
            {
                audioSource.PlayOneShot(audioClips[1]);
            }
            yield return new WaitForSeconds(morseCodeButton.ReadyTime[i]);
            ledLight.material.color = Color.white;
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(2.0f);
        morseCodeButton.ActionCheck = false;

        morseCodeCheck = true;
    }

}
