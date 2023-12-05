using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Scale : MonoBehaviour
{

    public static Vector3 Border1, Border2;
    public GameObject BorderCheckPoint1, BorderCheckPoint2;
    public static bool Success;

    public bool once = true;
    
    public float weight_A1 = 0;

    public float weight_A2 = 0;

    int heavy_code = 0;

    public float weight_A3 = 0;
    
    public GameObject[] weights = new GameObject[12];
    public int chance = 3;

    public GameObject Bar;
    public GameObject seg1;
    public GameObject seg2;

    public static bool[] check;

    [SerializeField] AudioSource MoveBar;
    [SerializeField] AudioSource Clear;
    [SerializeField] AudioSource Error;
    [SerializeField] AudioSource Deskopen;
    [SerializeField] Animator ani;
    private void Awake()
    {
        Success = false;
        Border1 = BorderCheckPoint1.transform.position;
        Border2 = BorderCheckPoint2.transform.position;

    }

    public void Answer_Check()
    {
        if (once)
        {
            if (0 < weight_A3 && weight_A3 < 2)
            {
                once = false;
                if (weight_A3 != 1)
                {
                    Debug.Log("정답");
                    Success = true;
                    Clear.PlayOneShot(Clear.clip);
                    StartCoroutine(OpenDeskSound());
                    ani.SetTrigger("open");
                }
                else
                {
                    Reset_game();
                    Debug.Log("틀림ㅅㄱ");
                    Error.PlayOneShot(Error.clip);  
                }
               
            }
            else
            {
                Debug.Log("개수 맞춰라");
            }
        }
        else
        {
            Debug.Log("답 더이상 체크 못해요");
        }

    }

    IEnumerator OpenDeskSound()
    {
        yield return new WaitForSeconds(1f);
        Deskopen.PlayOneShot(Deskopen.clip);
    }


    void Start()
    {
        Reset_game();
    }

    public void Reset_game()
    {
        heavy_code = 0;
        once = true;
        chance = 3;
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i].SendMessage("Set_init_loc");
            weights[i].SendMessage("Set_weigh", 1);
        }
        int rand_i = Random.Range(0, weights.Length);
        int rand_b = Random.Range(0, 2);
        float rand_f = rand_b == 0 ? 0.5f : 1.5f;
        weights[rand_i].SendMessage("Set_weigh", rand_f);

        weight_A1 = 0;

        weight_A2 = 0;

        weight_A3 = 0;
    }

    private float ea_speed = 10;
    private float p_speed = 1;
    private float ea = -90;
    private float A1_p = 9;
    private float A2_p = 9;
    void Update()
    {
        if (Success)
        {
            Debug.Log("CardGame Clear");
        }

        if(heavy_code == 0)
        {
            if (ea > -90)
                ea -= Time.fixedDeltaTime * ea_speed;
            else if (ea < -90.5f)
                ea += Time.fixedDeltaTime * ea_speed;

            if (A1_p < 9f)
                A1_p += Time.fixedDeltaTime * p_speed;
            else if(A1_p > 9.05f)
                A1_p -= Time.fixedDeltaTime * p_speed;

            if (A2_p < 9)
                A2_p += Time.fixedDeltaTime * p_speed;
            else if (A2_p > 9.05f) 
                A2_p -= Time.fixedDeltaTime * p_speed;
        }
        if (heavy_code == 1)
        {
            if (ea > -85f)
                ea -= Time.fixedDeltaTime * ea_speed;
            else if (ea < -85.5f)
                ea += Time.fixedDeltaTime * ea_speed;
            

            if (A1_p < 8.5f)
                A1_p += Time.fixedDeltaTime * p_speed;
            else if (A1_p > 8.55f) 
                A1_p -= Time.fixedDeltaTime * p_speed;

            if (A2_p < 9.5f)
                A2_p += Time.fixedDeltaTime * p_speed;
            else if (A2_p > 9.55f) 
                A2_p -= Time.fixedDeltaTime * p_speed;
        }
        if (heavy_code == 2)
        {
            if (ea > -95)
                ea -= Time.fixedDeltaTime * ea_speed;
            else if (ea < -95.5f)
                ea += Time.fixedDeltaTime * ea_speed;

            if (A1_p < 9.5f)
                A1_p += Time.fixedDeltaTime * p_speed;
            else if (A1_p > 9.55f) 
                A1_p -= Time.fixedDeltaTime * p_speed;

            if (A2_p < 8.5f)
                A2_p += Time.fixedDeltaTime * p_speed;
            else if (A2_p > 8.55f)
                A2_p -= Time.fixedDeltaTime * p_speed;
        }
        Bar.transform.localRotation = Quaternion.Euler(ea , -90, 90);
        seg1.transform.localPosition = new Vector3(seg1.transform.localPosition.x, A1_p, seg1.transform.localPosition.z);

        seg2.transform.localPosition = new Vector3(seg2.transform.localPosition.x, A2_p, seg2.transform.localPosition.z);
    }

    public void weigh_check()
    {
        if (chance > 0)
        {
            chance -= 1;
            heavy_code = what_heavy();

            if (heavy_code == 0)
            {
                Debug.Log("Same");
            }
            if (heavy_code == 1)
            {
                Debug.Log("A1 is bigger");
                MoveBar.PlayOneShot(MoveBar.clip);
            }
            if (heavy_code == 2)
            {
                Debug.Log("A2 is bigger");
                MoveBar.PlayOneShot(MoveBar.clip);
            }
        }
        else
        {
            Debug.Log("No more chance");
        }
    }
    private int what_heavy()
    {

        if (weight_A1 > weight_A2)
            return 1;

        if (weight_A2 > weight_A1)
            return 2;

        return 0;
    }

    public void AddWeight_A1(float tmp )
    {
        weight_A1 += tmp;
        if (weight_A1 < 0)
            weight_A1 = 0;
    }

    public void AddWeight_A2(float tmp)
    {
        weight_A2 += tmp;
        if (weight_A2 < 0)
            weight_A2 = 0;
    }

    public void AddWeight_A3(float tmp)
    {
        weight_A3 += tmp;
        if (weight_A3 < 0)
            weight_A3 = 0;
    }
}
