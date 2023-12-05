using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Pen : MonoBehaviour
{
    public static Vector3 Border1, Border2;
    public GameObject BorderCheckPoint1 , BorderCheckPoint2 ;
    public static bool Success ;

    public static bool[] check;

    [SerializeField] AudioSource Clear;
    private bool isPlayed = false;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource open;

    private void Awake()
    {
        Success = false;
        Border1 = BorderCheckPoint1.transform.position;
        Border2 = BorderCheckPoint2.transform.position;

        check = new bool[6];
        for (int i = 0; i < 6; i++)
            check[i] = false;


    }
    
    private static bool Answer_Check()
    {
        for(int i = 0; i < 6; i++)
        {
            if (check[i] == false)
                return false;
        }
        return true;
    }

    void Start()
    {
  
    }

    void Update()
    {
        Success = Answer_Check();

        if (Success && !isPlayed)
        {
            animator.SetTrigger("clear");
            isPlayed = true;
            Clear.PlayOneShot(Clear.clip);
            StartCoroutine(DeskSound());
            //Debug.Log("CardGame Clear");
        }
    }

    IEnumerator DeskSound()
    {
        yield return new WaitForSeconds(1f);
        open.PlayOneShot(open.clip);    
    }

}
