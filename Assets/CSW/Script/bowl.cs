using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl : MonoBehaviour
{
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Weigh") && !Game_Scale.Success) // Ư�� �±׸� ���� ������Ʈ�� Ʈ���ſ� �����ϸ�
        {
            collision.gameObject.SendMessage("Check_ans");
        }
    }
}
