using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public float weight = 1.0f;
    public int number;
    public bool Holding;
    private Vector3 Position_Start;
    private Quaternion Rotation_Start;
    private Rigidbody rb;

    public GameObject Manager;

    [SerializeField] AudioSource Input;
    void Awake()
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
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        //¸ÊÅ»Ãâ ¹æÁö
        if (!Holding && Is_out())
        {
            Set_init_loc();
        }
    }

    public void Set_init_loc()
    {
        rb.velocity = Vector3.zero;
        this.transform.position = Position_Start + new Vector3(0, 0.005f, 0);
        this.transform.rotation = Rotation_Start;
    }

    public void SetHold(bool State)
    {
        Holding = State;
    }

    public void Set_weigh(float tmp)
    {
        weight = tmp;
    }

    public bool Is_out()
    {
        Vector3 A = Game_Pen.Border1;

        Vector3 B = Game_Pen.Border2;

        Vector3 C = this.transform.position;

        float tmp;
        tmp = Mathf.Abs(A.x - B.x) - (Mathf.Abs(A.x - C.x) + Mathf.Abs(B.x - C.x));
        if (Mathf.Abs(tmp) > 0.01f)
            return true;

        tmp = Mathf.Abs(A.y - B.y) - (Mathf.Abs(A.y - C.y) + Mathf.Abs(B.y - C.y));
        if (Mathf.Abs(tmp) > 0.01f)
            return true;

        tmp = Mathf.Abs(A.z - B.z) - (Mathf.Abs(A.z - C.z) + Mathf.Abs(B.z - C.z));
        if (Mathf.Abs(tmp) > 0.01f)
            return true;

        return false;
    }

    public void Check_ans()
    {
        if(Holding == false)
        {
            Manager.SendMessage("Answer_Check");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Area1" )
        {
            Manager.gameObject.SendMessage("AddWeight_A1", weight);
        }
        if (other.gameObject.tag == "Area2" )
        {
            Manager.gameObject.SendMessage("AddWeight_A2", weight);
        }
        if (other.gameObject.tag == "Area3")
        {
            Manager.gameObject.SendMessage("AddWeight_A3", weight);
        }
        Input.PlayOneShot(Input.clip);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Area1")
        {
            Manager.gameObject.SendMessage("AddWeight_A1",-weight);
        }
        if (other.gameObject.tag == "Area2")
        {
            Manager.gameObject.SendMessage("AddWeight_A2",-weight);
        }
        if (other.gameObject.tag == "Area3")
        {
            Manager.gameObject.SendMessage("AddWeight_A3", -weight);
        }
    }
}
