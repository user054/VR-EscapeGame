using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "MorseCodeData", menuName = "Scriptable Object/MorseCodeData", order = 1)]
public class MorseCodeScriptableObject : ScriptableObject
{
    [SerializeField] int lightCount;
    [SerializeField] float []readyTime;

    public int LightCount => lightCount;
    public float[] ReadyTime => readyTime;

}
