using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] XRController controller_L;
    [SerializeField] XRController controller_R;
    bool l_pushCheck = false;
    bool r_pushCheck = false;

    Coroutine triggerButtonActiveCoroutine = null;

    protected delegate void TriggerButtonActiveDelegate();
    protected TriggerButtonActiveDelegate triggerButtonDelegate = null;


    //건드리지 말기
    public void Hover(bool value)
    {
        if (value == true)
        {
            if (triggerButtonActiveCoroutine != null)
            {
                StopCoroutine(triggerButtonActiveCoroutine);
            }
            StartTriggerButtonActiveCoroutineStart();
        }
        else
        {
            if (triggerButtonActiveCoroutine != null)
            {
                StopCoroutine(triggerButtonActiveCoroutine);
            }
        }
    }

    void StartTriggerButtonActiveCoroutineStart()
    {
        controller_L.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool l_check);
        if (l_check == true)
        {
            l_pushCheck = true;
        }

        controller_R.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool r_check);
        if(r_check == true)
        {
            r_pushCheck = true;
        }
        triggerButtonActiveCoroutine = StartCoroutine(StartTriggerButtonActiveCoroutine());
    }
    //

    //건드리지 말기
    IEnumerator StartTriggerButtonActiveCoroutine()
    {
        while (true)
        {
            yield return null;

            controller_L.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool l_check);

            controller_R.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool r_check);

            if (l_check == true && l_pushCheck == false && triggerButtonDelegate != null)
            {
                //실행시킬 함수 넣어주기
                triggerButtonDelegate();
                l_pushCheck = true;
            }
            if(l_check == false)
            {
                l_pushCheck = false;
            }

            if (r_check == true && r_pushCheck == false && triggerButtonDelegate != null)
            {
                //실행시킬 함수 넣어주기
                triggerButtonDelegate();
                r_pushCheck = true;
            }
            if (r_check == false)
            {
                r_pushCheck = false;
            }
        }
    }

    //

}
