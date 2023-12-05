using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownButton : TriggerButton
{
    enum ButtonSelect
    {
        UP,
        DOWN
    }
    [SerializeField] ButtonSelect upDownButtonSelect;
    [SerializeField] UpDonwNumberLED upDonwNumberLED;
    [SerializeField] GameObject[] numberImage;
    [SerializeField] FinalSafe finalSafe;
    [SerializeField] int index;
    // 0 = 트럼프, 1 = 마지막 금고
    [SerializeField] int check;


    private void Start()
    {
        if(check == 0)
        {
            triggerButtonDelegate = new TriggerButtonActiveDelegate(ButtonPush);
        }
        else
        {
            triggerButtonDelegate = new TriggerButtonActiveDelegate(SafeButton);
        }
    }

    void ButtonPush()
    {
        int value = 0;
        switch(upDownButtonSelect)
        {
            case ButtonSelect.UP:
                value = 1;
                break;
            case ButtonSelect.DOWN:
                value = -1;
                break;
            default:
                value = 0;
                break;
        }

        upDonwNumberLED.UpDownPanel(value, index);

    }

    int numberValue = 0;
    void SafeButton()
    {
        switch (upDownButtonSelect)
        {
            case ButtonSelect.UP:
                numberValue += 1;
                break;
            case ButtonSelect.DOWN:
                numberValue += -1;
                break;
            default:
                numberValue = 0;
                break;
        }

        if(numberValue > 9)
        {
            numberValue = 0;
        }

        if(numberValue - 1 < 0)
        {
            numberImage[9].SetActive(false);
        }
        else
        {
            numberImage[numberValue - 1].SetActive(false);
        }
        numberImage[numberValue].SetActive(true);

        finalSafe.winCheck(index, numberValue);
    }


}
