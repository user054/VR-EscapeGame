using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrumpHint : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material material;
    [SerializeField] GameObject text;
    Coroutine coroutine = null;



    public void HintSet()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(HintSetCoroutine());
        }
    }

    IEnumerator HintSetCoroutine()
    {
        yield return new WaitForSeconds(60.0f);
        text.SetActive(true);
        Material[] mat = meshRenderer.materials;
        mat[2] = material;
        meshRenderer.materials = mat;
    }

}
