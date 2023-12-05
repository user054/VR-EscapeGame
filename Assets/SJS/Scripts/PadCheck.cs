using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PadCheck : MonoBehaviour
{
    [SerializeField] GameObject[] pad;
    [SerializeField] Animator anim;

    bool blueCheck = false;
    bool greenCheck = false;
    bool redCheck = false;

    public bool BlueCheck { get { return blueCheck; } set { blueCheck = value; } }
    public bool GreenCheck { get { return greenCheck; } set { greenCheck = value; } }
    public bool RedCheck { get { return redCheck; } set { redCheck = value; } }

    private void Start()
    {
        StartCoroutine(padCheck());
    }

    IEnumerator padCheck()
    {
        while(true)
        {
            yield return null;
            if (blueCheck == true && greenCheck == true && redCheck == true)
            {
                anim.SetTrigger("Move");
                break;
            }
        }
    }


}
