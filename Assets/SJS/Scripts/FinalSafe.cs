using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSafe : MonoBehaviour
{
    [SerializeField] int [] finishNumber = new int[3];
    int []setNumber = new int[3];

    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource doorOpenAudio;
    [SerializeField] Animator anim;


    public void winCheck(int index, int number)
    {
        setNumber[index] = number;
        buttonAudio.PlayOneShot(buttonAudio.clip);

        if (finishNumber[0] == setNumber[0] && finishNumber[1] == setNumber[1] && finishNumber[2] == setNumber[2])
        {
            //윈체크 부분 넣어주기
            doorOpenAudio.PlayOneShot(doorOpenAudio.clip);
            anim.SetTrigger("Move");
        }
    }

}
