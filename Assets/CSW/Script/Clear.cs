using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{

    public Material newMaterial;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 특정 태그를 가진 오브젝트가 트리거에 진입하면
        {
            // 트리거 구역 내에 있는 모든 오브젝트를 찾습니다.
            Collider[] collidersInTrigger = Physics.OverlapBox(
                GetComponent<Collider>().bounds.center,
                GetComponent<Collider>().bounds.extents,
                Quaternion.identity
            );

            foreach (Collider collider in collidersInTrigger)
            {
                Renderer renderer = collider.gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = newMaterial; // 메테리얼 변경
                }
            }
        }
    }
}
