using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_intrer : MonoBehaviour
{
    public GameObject Manager;
    public int code;
    public bool toggler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggler)
        {
            if (code == 1)
            {
                toggler = false;
                Manager.SendMessage("weigh_check");
            }
            if (code == 2)
            {
                toggler = false;
                Manager.SendMessage("Reset_game");
            }
            if (code == 3)
            {
                toggler = false;
                Manager.SendMessage("Answer_Check");
            }
        }
    }
}
