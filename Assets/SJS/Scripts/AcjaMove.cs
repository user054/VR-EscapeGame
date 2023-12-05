using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcjaMove : MonoBehaviour
{
    [SerializeField] Animator anim;


    public void AcjaMovement()
    {
        anim.SetTrigger("Move");
    }






}
