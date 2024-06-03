using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (isGrabbed)
        {
            grabInteractable.interactionManager.SelectExit(grabInteractable.interactorsSelecting[0], grabInteractable);
            isGrabbed = false;
        }
        else
        {
            isGrabbed = true;
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (!isGrabbed)
        {
            grabInteractable.interactionManager.SelectEnter(args.interactorObject, grabInteractable);
        }
    }
}
