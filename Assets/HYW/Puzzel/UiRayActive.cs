using UnityEngine;
using UnityEngine.Events;

public class UiRayActive : MonoBehaviour
{
    [SerializeField] private Transform linkedhandposition;
    [SerializeField] private LayerMask layerToHit;
    [SerializeField] private float maxDistanceFromCanvas;

    [Header("UI HOVER EVENT")]
    public UnityEvent onUIHoverStart;
    public UnityEvent onUIHoverEnd;

    enum CurrentInteractorState
    {
        DefaultMode,
        UIMode
    }
    private CurrentInteractorState currentInteractorMode;


    private void Awake() => currentInteractorMode = CurrentInteractorState.DefaultMode;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(linkedhandposition.position, linkedhandposition.forward, out hit, maxDistanceFromCanvas, layerToHit))
        {
            if (currentInteractorMode != CurrentInteractorState.UIMode)
            {
                onUIHoverStart.Invoke();
                currentInteractorMode = CurrentInteractorState.UIMode;
            }

        }
        else
        {
            if(currentInteractorMode == CurrentInteractorState.UIMode)
            {
                onUIHoverEnd.Invoke();
                currentInteractorMode = CurrentInteractorState.DefaultMode;
            }
        }
    }
}
