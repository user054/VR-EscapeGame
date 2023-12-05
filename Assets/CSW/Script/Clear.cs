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
        if (other.CompareTag("Player")) // Ư�� �±׸� ���� ������Ʈ�� Ʈ���ſ� �����ϸ�
        {
            // Ʈ���� ���� ���� �ִ� ��� ������Ʈ�� ã���ϴ�.
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
                    renderer.material = newMaterial; // ���׸��� ����
                }
            }
        }
    }
}
