using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Card : MonoBehaviour
{
    public static Vector3 Border1, Border2;
    public GameObject BorderCheckPoint1 , BorderCheckPoint2 ;
    public static bool Success ;

    public static bool[] check;

    [SerializeField] AudioSource Clear;
    private bool isPlayed=false;
    [SerializeField] Animator ani;
    [SerializeField] AudioSource Open;
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

        if (Success&& !isPlayed)
        {
            ani.SetTrigger("Opendoor");
            isPlayed = true;    
            Clear.PlayOneShot(Clear.clip);
            StartCoroutine(Sound());
            Debug.Log("CardGame Clear");
        }
    }
    
    IEnumerator Sound()
    {
        yield return new WaitForSeconds(1f);
        Open.PlayOneShot(Open.clip);
    }

}
