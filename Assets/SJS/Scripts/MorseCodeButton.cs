using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MorseCodeButton : TriggerButton
{
    [SerializeField] int morseCodeNumber = 0;
    [SerializeField] MorseCodeLED led;
    [SerializeField] MorseCodeScriptableObject []morseCodeScriptableObject;
    [SerializeField] Material material;
    bool actionCheck = false;
    int lightCount = 0;
    float []readyTime;

    public bool ActionCheck { get { return actionCheck; } set { actionCheck = value; } }
    public int LightCount { get { return lightCount; } }
    public float[] ReadyTime { get { return readyTime; } }


    private void Start()
    {
        lightCount = morseCodeScriptableObject[morseCodeNumber].LightCount;
        readyTime = morseCodeScriptableObject[morseCodeNumber].ReadyTime;

        triggerButtonDelegate = new TriggerButtonActiveDelegate(MorseCodeActive);
    }

    private void Update()
    {
        if(actionCheck == false)
        {
            material.color = Color.red;//.SetColor("_EmissionColor", Color.red * 0.01f);
        }

        if (actionCheck == true)
        {
            material.color = Color.green;//SetColor("_EmissionColor", Color.green * 1.0f);
            //actionCheck = false;
        }
    }

    void MorseCodeActive()
    {
        led.Light_ON_OFF(this);
        //actionCheck = true;

    }



}
