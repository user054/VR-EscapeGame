using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    public int number;
    

    public void SetCheck(int num)
    {
        if(number == num)
        {
            Game_Card.check[number] = true;
        }
        else
            Game_Card.check[number] = false;
    }

    public void SetFalse()
    {
        
         Game_Card.check[number] = false;
    }

}
