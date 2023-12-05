using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{

    private float timer = 0;
    public float time = 2f;
    private new bool animation = false;
    private bool once = true;

    private Vector3 startpos;
    public Vector3 endpos;


    void Start()
    {
        startpos = transform.localPosition; 
    }

    
    void Update()
    {
        if (Game.Success)
        {
            if (once)
            {
                once = false;
                animation = true;
            }
        }

        if (animation)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                timer = time;
                animation = false;
            }
            
            this.transform.localPosition = SinFunc(startpos,endpos, timer /time);
        }

    }

    private Vector3 SinFunc(Vector3 pos1,Vector3 pos2, float x )
    {
        double k = ((- Math.Cos(x * Math.PI)) + 1) / 2;
       //Debug.Log(k);
        return pos1 + (pos2 - pos1) * (float)k;
    }
}
