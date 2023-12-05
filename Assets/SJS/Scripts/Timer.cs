using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerSec = 60;
    [SerializeField] int timerMin = 15;
    //float tmpNum = 0.0f;
    StringBuilder timerSecondNumber = new StringBuilder();
    StringBuilder timerSecond2Number = new StringBuilder();
    StringBuilder timerMinuteNumber = new StringBuilder();
    StringBuilder timerMinute2Number = new StringBuilder();

    [SerializeField] TextMeshPro textMesh;
    [SerializeField] AudioSource alarm;
    [SerializeField] AudioSource minute;
    int check = 4;

    [SerializeField] EndingSceneChange sceneChange;

    private void Start()
    {
        timerMinuteNumber.Clear();
        timerMinute2Number.Clear();
        timerMinuteNumber.Append(timerMin / 10);
        timerMinute2Number.Append(timerMin % 10);
    }

    private void Update()
    {
        timerUpdate();
    }

    void timerUpdate()
    {
        //tmpNum += Time.deltaTime;

        timerSec -= Time.deltaTime;

        timerSecondNumber.Clear();
        timerSecond2Number.Clear();

        timerSecondNumber.Append((int)timerSec / 10);
        timerSecond2Number.Append((int)timerSec % 10);

        if (timerSec <= 0)
        {
            timerSecondNumber.Clear();
            timerSecond2Number.Clear();

            timerSecondNumber.Append(60);
            timerSecond2Number.Append(60);

            timerMin--;
            timerMinuteNumber.Clear();
            timerMinute2Number.Clear();

            timerMinuteNumber.Append(timerMin / 10);
            timerMinute2Number.Append(timerMin % 10);

            timerSec = 60.0f;
            //tmpNum = 0.0f;
        }

        if (timerMin == 5.0f && check == 4)
        {
            soundSet(alarm);
            check--;
        }
        else if (timerMin == 3.0f && check == 3)
        {
            soundSet(alarm);
            check--;
        }
        else if (timerMin == 1.0f && check == 2)
        {
            soundSet(alarm);
            check--;
        }
        else if(timerMin < 1.0f && check == 1)
        {
            soundSet(minute);
            check--;
        }
        else if(timerSec <= 0.0f && check == 0)
        {
            sceneChange.EndingSceneChangeFunc();
        }

        textMesh.text = timerMinuteNumber.ToString() + " " + timerMinute2Number.ToString() + " " + timerSecondNumber.ToString() + " " + timerSecond2Number.ToString();
    }

    void soundSet(AudioSource audio)
    {
        audio.PlayOneShot(audio.clip);
    }

}
