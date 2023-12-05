using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiePuzzleButton : TriggerButton
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] LiePuzzleManager liePuzzleManager;
    [SerializeField] string target;
    int ivalue = 0;

    public int Value { get { return ivalue; } set { ivalue = value; } }

    private void Start()
    {
        triggerButtonDelegate = new TriggerButtonActiveDelegate(buttonPush);

    }

    void buttonPush()
    {

        if (target == "Human")
        {
            liePuzzleManager.HumanSet(gameObject);
        }
        else
        {
            liePuzzleManager.JewelSet(gameObject);
        }
    }

    public void ButtonDisabled()
    {
        triggerButtonDelegate -= buttonPush;
    }

}
