using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : TriggerButton
{

    private void Start()
    {
        triggerButtonDelegate += DoorOpenFunc;
    }

    void DoorOpenFunc()
    {

    }

}
