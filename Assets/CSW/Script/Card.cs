using Oculus.Interaction.Body.Input;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int number;
    public bool Holding;
    private Vector3 Position_Start;
    private Quaternion Rotation_Start;
    private Rigidbody rb;

    [SerializeField] AudioSource input;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Holding = false;
        Position_Start = this.transform.position;
        Rotation_Start = this.transform.rotation;
    }

    void Update()
    {

        if (Holding)
        {
            //this.transform.rotation = Quaternion.Euler(-90, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None ;
        }

        //¸ÊÅ»Ãâ ¹æÁö
        if (!Holding && Is_out())
        {
            rb.velocity = Vector3.zero;
            this.transform.position = Position_Start + new Vector3(0,0.1f,0);
            this.transform.rotation = Rotation_Start;
        } 
    }

    public void SetHold(bool State)
    {
        Holding = State;
    }

    
    public bool Is_out()
    {
        Vector3 A = Game_Card.Border1;

        Vector3 B = Game_Card.Border2;

        Vector3 C = this.transform.position;

        float tmp;
        tmp = Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.x - C.x) + Mathf.Abs(B.x - C.x));
        if ( Mathf.Abs(tmp) >  0.01f)
            return true;

        tmp = Mathf.Abs(A.y - B.y) - (Mathf.Abs(A.y - C.y) + Mathf.Abs(B.y - C.y));
        if (Mathf.Abs(tmp) > 0.01f)
            return true;

        tmp = Mathf.Abs(A.z - B.z) - (Mathf.Abs(A.z - C.z) + Mathf.Abs(B.z - C.z));
        if (Mathf.Abs(tmp) > 0.01f)
            return true;

        return false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CardHolder" && !Holding)
        {
                this.transform.position = other.transform.position + new Vector3(0, 0.005f, 0);
                rb.velocity = Vector3.zero;
                this.transform.localRotation = Quaternion.Euler(0, 180, 180);
                other.gameObject.SendMessage("SetCheck", number);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CardHolder" && !Holding)
        {
            this.transform.position = other.transform.position + new Vector3(0, 0.005f, 0);
            rb.velocity = Vector3.zero;
            this.transform.localRotation = Quaternion.Euler(0, 180, 180);
            other.gameObject.SendMessage("SetCheck", number);
            input.PlayOneShot(input.clip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CardHolder")
        {
            other.gameObject.SendMessage("SetFalse");
        }
    }
}
