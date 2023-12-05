using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    public int N_Queen;
    public bool Grab;

    private bool once_aftergrab;
    private bool once_beforegrab;
    private Vector3 Grab_pos;
    private Rigidbody rb;

    public Material newMaterial;

    [SerializeField] AudioSource Drop;
    void Start()
    {
        once_beforegrab = true; 
        Grab = false;
        rb = GetComponent<Rigidbody>();
        Snap();
        Game.Queen_Init(N_Queen, (int)this.transform.localPosition.x, (int)Mathf.Abs(this.transform.localPosition.z));
    }


    void Update()
    {
        if( Grab ) // true
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            once_aftergrab = true;
            if (once_beforegrab)
            {
                once_beforegrab = false;
                Grab_pos = transform.localPosition;
            }
            
        }
        else //false
        {

            rb.constraints = RigidbodyConstraints.FreezeAll;
            once_beforegrab = true;
            if (once_aftergrab)
            {
                once_aftergrab = false;
                Snap();

                Game.Queen_Move(N_Queen, (int)(this.transform.localPosition.x), (int)Mathf.Abs(this.transform.localPosition.z ));
            }
        }

        if (Game.Success) //true
        {
            Renderer renderer = GetComponent<Collider>().gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial; 
            }
        }
    }

    public void Snap()
    {
        Vector3 point = new Vector3(Mathf.Round(this.transform.localPosition.x), 2f, Mathf.Round(this.transform.localPosition.z));


        if (Game.Can_Queen_Move((int)(point.x), (int)Mathf.Abs(point.z )) == false)
        {
            this.transform.localPosition = Grab_pos;
            rb.velocity = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.EulerAngles(-1.570796325f, 0,0);
            return;
        }

        if (point.x < 0 || point.x > 8 || point.z > 0 || point.z < -8)
        {
            this.transform.localPosition = Grab_pos;
        }
        else
        {
            this.transform.localPosition = point;
        }
        rb.velocity = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.EulerAngles(-1.570796325f, 0, 0);
        Drop.PlayOneShot(Drop.clip);
    }

    public void SetGrab(bool state)
    {
        Grab = state;
    }
}
