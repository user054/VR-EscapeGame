using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoketSet : MonoBehaviour
{
    [SerializeField] GameObject [] soket;
    //[SerializeField] XRSocketInteractor[] sokets;
   
    public void Enabled()
    {
        for(int i = 0; i < soket.Length; i++)
        {
            soket[i].SetActive(true);
        }

    }

    public void Disabled(string name)
    {
        for (int i = 0; i < soket.Length; i++)
        {
            if(soket[i].name != name)
            {
                soket[i].SetActive(false);
            }
        }

    }


}
