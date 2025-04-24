using UnityEngine;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    public FadeToColor fadeToColor;
    

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;


    public bool isOpen = false;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

    }



    private bool grabbed = false;
    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!grabbed)
        {
            fadeToColor.FadeImage(true, isOpen);

            grabbed = true;
        }
    }
    
    private void OnRelease(SelectExitEventArgs args)
    {

    }



    
}