using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static int[,] board ;

    private static int[,] queens ;

    public static bool Success ;

    [SerializeField] AudioSource Clear;
    [SerializeField] AudioSource Open;
    private bool isPlayed = false;
    private void Awake()
    {
        Success = false;
        board = new int[8, 8];
        queens = new int[8, 2];
    }

    private static bool Answer_Check()
    {
        for (int j = 0; j <64; j++)
        {
            board[j / 8, j % 8] = 0;
        }

        for (int i = 0; i<8;i++)
        {
            int x = queens[i, 0];
            int y = queens[i, 1];

            board[x, y]++;
            mover(new Vector2(x, y), new Vector2(1, 0));
            mover(new Vector2(x, y), new Vector2(-1, 0));
            mover(new Vector2(x, y), new Vector2(0, 1));
            mover(new Vector2(x, y), new Vector2(0, -1));

            mover(new Vector2(x, y), new Vector2(1, 1));
            mover(new Vector2(x, y), new Vector2(1, -1));
            mover(new Vector2(x, y), new Vector2(-1, 1));
            mover(new Vector2(x, y), new Vector2(-1, -1));

        }

        for (int i = 0; i < 8; i++)
        {
            int x = queens[i, 0];
            int y = queens[i, 1];
            if (board[x,y] > 1)
            {
                return false;
            }
        }

        return true;

    }
    private static void mover(Vector2 loc, Vector2 dir)
    {
        while (true)
        {
            loc += dir;
            if(loc.x <0 || loc.x >7) //out
            {
                return;
            }
            if (loc.y < 0 || loc.y > 7) //out
            {
                return;
            }

            board[(int)loc.x, (int)loc.y]++;
        }
    }

    public static void Queen_Init(int N, int x, int y)
    {
        //Debug.Log("N : " + N + " x : " + x + " y : " + y);
        queens[N, 0] = x;
        queens[N, 1] = y;
    }
    public static void Queen_Move(int N, int x, int y)
    {

        queens[N, 0] = x;
        queens[N, 1] = y;

        Success = Answer_Check();
    }

    public static bool Can_Queen_Move(int x,int y)
    {
        for(int i = 0; i < 8; i++)
        {
            if (queens[i, 0] == x && queens[i, 1] == y)
                return false;
        }
        return true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Success&& !isPlayed)
        {
            isPlayed = true;
            Clear.PlayOneShot(Clear.clip);
            StartCoroutine(OpenSound());    
            //Debug.Log("Clear");
        }
    }

    IEnumerator OpenSound()
    {
        yield return new WaitForSeconds(1f);
        Open.PlayOneShot(Open.clip);    
    }

}
