using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class KeyPad_12 : MonoBehaviour
{
    [SerializeField] TextMeshPro keypadTextPrint;
    [SerializeField] int checkNumber = 0;
    StringBuilder keyPadTextData = new StringBuilder();
    [SerializeField] AudioSource keypadAudio;
    [SerializeField] AudioSource nonClearAudio;
    [SerializeField] AudioSource clearAudio;
    [SerializeField] AudioSource drawerAudio;

    [SerializeField] Animator anim;

    //[SerializeField] GameObject []textImage1;
    //[SerializeField] GameObject []textImage2;
    //[SerializeField] GameObject []textImage3;
    //List<GameObject[]> textImageList = new List<GameObject[]>();

    // 0 = 최종퍼즐, 1 = 모스코드
    [SerializeField] int Check = 0;

    bool coroutineCheck = false;


    int keyPadCount = 0;
    int keyPadValue = 0;
    bool keyPadCheck = true;

    private void Start()
    {
        //textImageList.Add(textImage1);
        //textImageList.Add(textImage2);
        //textImageList.Add(textImage3);

        StartCoroutine(updateCoroutine());
    }

    IEnumerator updateCoroutine()
    {
        while (true)
        {
            yield return null;
            if (keyPadCount <= 0)
            {
                keyPadCount = 0;
            }
            if (keyPadCount > 4)
            {
                KeyPadTextDelete();
                keyPadCount = 4;
            }

            if(coroutineCheck == true)
            {
                break;
            }
        }
    }


    public void KeyPad(int keypadNumber)
    {

        if(keyPadCheck == true)
        {
            switch (keypadNumber)
            {
                case -1:
                    KeyPadTextDelete();
                    break;
                case -2:
                    KeyPadNumberCheck();
                    break;
                default:
                    if (keyPadCount < 4)
                    {
                        StartCoroutine(KepadDelay());
                        keyPadCount++;

                        KeyPadTextInput(keypadNumber);
                        KeyPadTextPrint();
                    }
                    break;
            }
            keypadAudio.PlayOneShot(keypadAudio.clip);
        }

    }

    void KeyPadTextInput(int inputKeypadNumber)
    {
        //키패드의 기존숫자의 자리수를 한칸 옮겨주고 새로 입력된 숫자를 이전 위치로 입력시키기 위한 코드
        keyPadValue *= 10;
        keyPadValue += inputKeypadNumber;
    }

    void KeyPadTextPrint()
    {

        //if (Check == 0)
        //{
        //    if(keyPadCount == 3)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            for (int i = 0; i < 10; i++)
        //            {
        //                textImageList[j][i].SetActive(false);
        //            }
        //        }
        //    }


        //}
        //else
        //{
            keyPadTextData.Clear();
            keyPadTextData.Append(keyPadValue);
            keypadTextPrint.color = Color.green;
            keypadTextPrint.text = keyPadTextData.ToString();
        //}
    }

    void KeyPadTextDelete()
    {
        keyPadCount--;

        keyPadValue /= 10;
        keyPadTextData.Clear();
        keyPadTextData.Append(keyPadValue);
        keypadTextPrint.color = Color.green;


        if (keyPadValue <= 0)
        {
            keypadTextPrint.text = "".ToString();

        }
        else
        {
            keypadTextPrint.text = keyPadTextData.ToString();
        }
        if(keyPadValue < 0)
        {
            keyPadValue = 0;
        }
    }

    void KeyPadNumberCheck()
    {
        if(checkNumber == keyPadValue)
        {
            //정답처리해주기
            clearAudio.PlayOneShot(clearAudio.clip);
            anim.SetTrigger("Move");
            drawerAudio.PlayOneShot(drawerAudio.clip);
            coroutineCheck = true;
        }
        else
        {
            //오답 사운드 넣어주기
            nonClearAudio.PlayOneShot(nonClearAudio.clip);

            keyPadCount = 0;
            keyPadValue = 0;

            StartCoroutine(KeyPadFail());
        }
    }

    IEnumerator KeyPadFail()
    {
        keyPadCheck = false;
        keypadTextPrint.color = Color.red;
        keypadTextPrint.text = "ERROR";
        yield return new WaitForSeconds(2.0f);
        keyPadCheck = true;
        keyPadTextData.Clear();
        keypadTextPrint.text = "";
        keyPadCount = 0;
        keyPadValue = 0;

    }

    IEnumerator KepadDelay()
    {
        keyPadCheck = false;
        yield return new WaitForSeconds(0.4f);
        keyPadCheck = true;
    }

}
