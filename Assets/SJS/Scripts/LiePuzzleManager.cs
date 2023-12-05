using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiePuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject[] human;
    [SerializeField] GameObject[] jewel;

    [SerializeField] int humanWin;
    [SerializeField] int jewelWin;

    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource clearAudio;
    [SerializeField] AudioSource doorOpenAudio;
    [SerializeField] Animator anim;

    public void JewelSet(GameObject thisObj)
    {
        buttonAudio.PlayOneShot(buttonAudio.clip);
        for (int i = 0; i < jewel.Length; i++)
        {
            jewel[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            jewel[i].gameObject.GetComponent<LiePuzzleButton>().Value = 0;
        }

        thisObj.GetComponent<MeshRenderer>().material.color = Color.green;
        thisObj.GetComponent<LiePuzzleButton>().Value = 1;
        WinCheck();
    }

    public void HumanSet(GameObject thisObj)
    {
        buttonAudio.PlayOneShot(buttonAudio.clip);
        for (int i = 0; i < jewel.Length; i++)
        {
            human[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            human[i].gameObject.GetComponent<LiePuzzleButton>().Value = 0;
        }

        thisObj.GetComponent<MeshRenderer>().material.color = Color.green;
        thisObj.GetComponent<LiePuzzleButton>().Value = 1;
        WinCheck();
    }

    void WinCheck()
    {
        bool humanCheck = true;
        bool jewelCheck = true;
        if (human[humanWin].GetComponent<LiePuzzleButton>().Value == 1)
        {
            humanCheck = true;
        }
        else
        {
            humanCheck = false;
        }

        if (jewel[jewelWin].GetComponent<LiePuzzleButton>().Value == 1)
        {
            jewelCheck = true;
        }
        else
        {
            jewelCheck = false;
        }

        if(humanCheck == true && jewelCheck == true)
        {
            //À©Ã¼Å©
            clearAudio.PlayOneShot(clearAudio.clip);
            doorOpenAudio.PlayOneShot(doorOpenAudio.clip);
            anim.SetTrigger("Move");

            for (int i = 0; i <= jewel.Length; i++)
            {
                jewel[i].gameObject.GetComponent<LiePuzzleButton>().ButtonDisabled();
                human[i].gameObject.GetComponent<LiePuzzleButton>().ButtonDisabled();
            }

        }

    }

}
