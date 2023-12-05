using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReversePuzzle : MonoBehaviour
{
    GameObject[,] reversePuzzleButton;
    [SerializeField] GameObject[] reversePuzzleButtonSet;
    [SerializeField] int gameCount;
    Coroutine resetCoroutine;
    [SerializeField] float resetTime;
    [SerializeField] MeshRenderer[] meshRenderers;

    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource nonClearAudio;
    [SerializeField] AudioSource clearAudio;
    [SerializeField] AudioSource drawerAudio;

    [SerializeField] Animator anim;

    private void Start()
    {
        reversePuzzleButton = new GameObject[3, 5] { {reversePuzzleButtonSet[0], reversePuzzleButtonSet[1], reversePuzzleButtonSet[2], reversePuzzleButtonSet[3], reversePuzzleButtonSet[4]},
                                                     {reversePuzzleButtonSet[5], reversePuzzleButtonSet[6], reversePuzzleButtonSet[7], reversePuzzleButtonSet[8], reversePuzzleButtonSet[9] },
                                                   {reversePuzzleButtonSet[10], reversePuzzleButtonSet[11], reversePuzzleButtonSet[12], reversePuzzleButtonSet[13], reversePuzzleButtonSet[14]} };
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ButtonDefaultSet();
    }



    public void ReversePuzzleCal(int xValue, int yValue)
    {
        if(gameCount < 4)
        {
            buttonAudio.PlayOneShot(buttonAudio.clip);
            LightOn(gameCount);
            gameCount++;
            reversePuzzleButton[yValue, xValue].GetComponent<ReversePuzzleButton>().ButtonNumber = NumberCheck(xValue, yValue);
            if (yValue - 1 >= 0)
            {
                reversePuzzleButton[yValue - 1, xValue].GetComponent<ReversePuzzleButton>().ButtonNumber = NumberCheck(xValue, yValue - 1);
            }
            if (xValue + 1 <= 4)
            {
                reversePuzzleButton[yValue, xValue + 1].GetComponent<ReversePuzzleButton>().ButtonNumber = NumberCheck(xValue + 1, yValue);
            }
            if (yValue + 1 <= 2)
            {
                reversePuzzleButton[yValue + 1, xValue].GetComponent<ReversePuzzleButton>().ButtonNumber = NumberCheck(xValue, yValue + 1);
            }
            if (xValue - 1 >= 0)
            {
                reversePuzzleButton[yValue, xValue - 1].GetComponent<ReversePuzzleButton>().ButtonNumber = NumberCheck(xValue - 1, yValue);
            }

            ButtonPrint();

        }

        if (gameCount >= 4)
        {
            if (WinCheck() == false)
            {
                if (resetCoroutine == null)
                {
                    resetCoroutine = StartCoroutine(ResetCoroutine());
                }
            }
            else
            {
                Win();
            }
        }

    }

    void LightOn(int index)
    {
        meshRenderers[index].material.color = Color.red;
    }

    void LightOff()
    {
        for(int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = new Color(128,128,128,255);
        }
    }

    int NumberCheck(int xValue, int yValue)
    {
        if (reversePuzzleButton[yValue, xValue].GetComponent<ReversePuzzleButton>().ButtonNumber == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }

    void ButtonPrint()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if(reversePuzzleButton[i, j].GetComponent<ReversePuzzleButton>().ButtonNumber == 0)
                {
                    reversePuzzleButton[i, j].GetComponent<ReversePuzzleButton>().MeshRendererData.material.color = Color.red;
                }
                else
                {
                    reversePuzzleButton[i, j].GetComponent<ReversePuzzleButton>().MeshRendererData.material.color = Color.blue;
                }
            }
        }

    }

    void ButtonDefaultSet()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                reversePuzzleButton[i, j].GetComponent<ReversePuzzleButton>().ButtonDefaultSet();
            }
        }
        ButtonPrint();
    }

    void ButtonLight(int value)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                reversePuzzleButton[i, j].GetComponent<ReversePuzzleButton>().ButtonNumber = value;
            }
        }
        ButtonPrint();

    }

    bool WinCheck()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if(reversePuzzleButton[i, j].GetComponent<ReversePuzzleButton>().ButtonNumber == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void Win()
    {
        clearAudio.PlayOneShot(clearAudio.clip);
        //정답일시 처리해주기
        drawerAudio.PlayOneShot(drawerAudio.clip);
        anim.SetTrigger("Move");
    }

    IEnumerator ResetCoroutine()
    {
        ButtonLight(0);
        yield return new WaitForSeconds(resetTime);
        ButtonLight(1);
        nonClearAudio.PlayOneShot(nonClearAudio.clip);
        yield return new WaitForSeconds(0.3f);
        ButtonLight(0);
        nonClearAudio.PlayOneShot(nonClearAudio.clip);
        yield return new WaitForSeconds(resetTime);

        LightOff();
        ButtonDefaultSet();
        gameCount = 0;
        resetCoroutine = null;
    }


}
