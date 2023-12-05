using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadButton : TriggerButton
{
    [SerializeField] KeyPad_12 keypad;

    //keyPadNumber == -1 : Delete, keyPadNumber == -2 : Check
    [SerializeField] int keyPadNumber = 0;

    private void Start()
    {
        triggerButtonDelegate = new TriggerButtonActiveDelegate(KeyPadPush);
    }

    void KeyPadPush()
    {
        keypad.KeyPad(keyPadNumber);
    }

}
