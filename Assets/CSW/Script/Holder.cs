using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public int number;

    public void SetCheck(int num)
    {
        if(number == num)
        {
            Game_Pen.check[number] = true;
        }
        else
            Game_Pen.check[number] = false;
    }

    public void SetFalse()
    {
        
         Game_Pen.check[number] = false;
    }

}
