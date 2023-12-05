using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCollisionCheck : MonoBehaviour
{
    [SerializeField] PadCheck padCheck;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Blue"))
        {
            padCheck.BlueCheck = true;
        }
        if (other.CompareTag("Green"))
        {
            padCheck.GreenCheck = true;
        }
        if (other.CompareTag("Red"))
        {
            padCheck.RedCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blue"))
        {
            padCheck.BlueCheck = false;
        }
        if (other.CompareTag("Green"))
        {
            padCheck.GreenCheck = false;
        }
        if (other.CompareTag("Red"))
        {
            padCheck.RedCheck = false;
        }
    }
}
