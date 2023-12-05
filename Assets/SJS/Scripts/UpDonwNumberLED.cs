using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpDonwNumberLED : MonoBehaviour
{
    [SerializeField] UpDownPad upDownPad;
    [SerializeField] TextMeshPro printText;
    int panelNumber = 0;

    public int PanelNumber => panelNumber;

    public void UpDownPanel(int value, int index)
    {
        if (panelNumber + value <= -1)
        {
            panelNumber = 9;
        }
        else if(panelNumber + value >= 10)
        {
            panelNumber = 0;
        }
        else
        {
            panelNumber += value;
        }

        printText.text = panelNumber.ToString();

        upDownPad.PadNumberFinish(index, panelNumber);
    }


}
