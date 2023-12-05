using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSelectionManager : MonoBehaviour
{
    public ObjectManager trueObjectManager;
    public ObjectManager jewelObjectManager;

    private int selectedTrueCount = 0;
    private int selectedJewelCount = 0;
    private bool canSelect = true;

    public void OnInteractableSelected(XRBaseInteractable interactable)
    {
        if (canSelect)
        {
            ObjectManager objectManager = interactable.GetComponentInParent<ObjectManager>();
            if (objectManager != null)
            {
                objectManager.OnInteractableSelected(interactable);

                if (interactable.CompareTag("true"))
                {
                    selectedTrueCount++;
                }

                if (interactable.CompareTag("jewel"))
                {
                    selectedJewelCount++;
                }

                if (selectedTrueCount > 0 && selectedJewelCount > 0)
                {
                    canSelect = false;
                    Debug.Log("����.");
                }
            }
            else
            {
                Debug.LogError("ObjectManager�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.Log("����.");
        }
    }

    public void OnInteractableDeselected(XRBaseInteractable interactable)
    {
        if (!canSelect)
        {
            if (interactable.CompareTag("true"))
            {
                selectedTrueCount--;
            }

            if (interactable.CompareTag("jewel"))
            {
                selectedJewelCount--;
            }

            if (selectedTrueCount == 0 || selectedJewelCount == 0)
            {
                canSelect = true;
            }
        }
    }
}