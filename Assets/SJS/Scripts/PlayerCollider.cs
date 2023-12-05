using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("MapCol") == true)
        {
            rigid.constraints = RigidbodyConstraints.None;
            rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezePositionY;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("MapCol") == true)
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;

        }
    }




}
