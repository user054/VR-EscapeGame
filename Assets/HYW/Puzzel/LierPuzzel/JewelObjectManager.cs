using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class JewelObjectManager : MonoBehaviour
{
    public Material defaultMaterial;
    public Material highlightMaterial;

    private XRBaseInteractable currentInteractable;

    public void OnInteractableSelected(XRBaseInteractable interactable)
    {
        if (currentInteractable != null)
        {
            Renderer renderer = currentInteractable.GetComponent<Renderer>();
            renderer.material = defaultMaterial;
        }

        currentInteractable = interactable;
        Renderer newRenderer = currentInteractable.GetComponent<Renderer>();
        newRenderer.material = highlightMaterial;

        Debug.Log("Jewel 오브젝트 선택");
    }
}