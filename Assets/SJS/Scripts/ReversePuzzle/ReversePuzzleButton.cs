using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePuzzleButton : TriggerButton
{
    ReversePuzzle reversePuzzle;
    [SerializeField] int xValue;
    [SerializeField] int yValue;
    [SerializeField] int buttonNumberOriginal;
    [SerializeField] MeshRenderer meshRenderer;
    int buttonNumber;

    public int ButtonNumber {get{ return buttonNumber; } set { buttonNumber = value; } }
    public MeshRenderer MeshRendererData => meshRenderer;

    private void Start()
    {
        reversePuzzle = FindObjectOfType<ReversePuzzle>();
        triggerButtonDelegate = new TriggerButtonActiveDelegate(ButtonPush);
        buttonNumber = buttonNumberOriginal;
    }

    void ButtonPush()
    {
        reversePuzzle.ReversePuzzleCal(xValue, yValue);

    }

    public void ButtonDefaultSet()
    {
        buttonNumber = buttonNumberOriginal;
    }

}
