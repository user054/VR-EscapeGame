using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpDownPad : MonoBehaviour
{
    [SerializeField] UpDonwNumberLED[] upDonwNumberLED;
    [SerializeField] int[] finishNumber = new int[4];
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource doorOpenAudio;
    [SerializeField] Animator anim;
    int []buttonNumber = new int[4];

    public void PadNumberFinish(int index, int number)
    {
        NumberSet(index, number);
        if (finishNumber[0] == buttonNumber[0] && finishNumber[1] == buttonNumber[1] && finishNumber[2] == buttonNumber[2] && finishNumber[3] == buttonNumber[3])
        {
            doorOpenAudio.PlayOneShot(doorOpenAudio.clip);
            anim.SetTrigger("Move");

        }

    }

    void NumberSet(int index, int number)
    {
        buttonAudio.PlayOneShot(buttonAudio.clip);

        buttonNumber[index] = number;
    }
}
