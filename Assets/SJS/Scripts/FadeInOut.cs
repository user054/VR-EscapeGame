using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] Image fadeImage = null;
    [SerializeField] TextMeshProUGUI text = null;

    //fadeType = 페이드를 인할지 아웃할지 고르는 코드(0 = 페이드아웃, 1 = 페이드인) fadeValue = 시작할 이미지 알파값(0~1), finalFadeValue = 최종 이미지 알파값(0~1), imageFadeSpeed = 알파값이 증감하는 속도
    public void DisplayFadeInOutController(int fadeType, float fadeValue, float finalFadeValue, float imageFadeSpeed)
    {
        StartCoroutine(PanelFadeCoroutine( fadeType,  fadeValue,  finalFadeValue,  imageFadeSpeed));

    }

    IEnumerator PanelFadeCoroutine(int fadeType, float fadeValue, float finalFadeValue, float imageFadeSpeed)
    {
        while (true)
        {
            fadeValue += imageFadeSpeed;
            yield return new WaitForSeconds(0.01f);
            if(fadeImage != null)
                fadeImage.color = new Color(0, 0, 0, fadeValue);
            else
            {
                text.color = new Color(1, 1, 1, fadeValue);
            }

            if (fadeType == 0 && fadeValue > finalFadeValue)
            {
                yield break;
            }
            else if (fadeType == 1 && fadeValue < finalFadeValue)
            {
                yield break;
            }

        }

    }



}
