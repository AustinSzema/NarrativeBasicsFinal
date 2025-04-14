using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabDetection : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    public NarrativeSO narrativeSO;

    public bool isTheRadio = false;

    public AudioSource audioSource;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    private void Start()
    {
        if (narrativeSO == null)
        {
            Debug.LogWarning("NarrativeSO is null");
        }

        if (audioSource == null && isTheRadio)
        {
            Debug.LogWarning(gameObject.name);
            Debug.LogWarning("is either falsely marked as a radio, or the radio is missing an audioSource");
        }
    }

    private bool canGrab = true;

    private bool grabbedBefore = false;

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (canGrab)
        {
            
            Debug.Log($"{gameObject.name} grabbed by {args.interactorObject.transform.name}");
            if (narrativeSO != null)
            {
                if (!grabbedBefore)
                {
                    StaminaMeter.Instance.ReduceStamina(narrativeSO.staminaCost);
                    grabbedBefore = true;
                }
                NarrativeTextSingleton.Instance.SetText(narrativeSO.description, narrativeSO.staminaCost);
            }
        }
        canGrab = false;
        audioSource.Play();

    }

    private bool dayIsOver = false;
    private void OnRelease(SelectExitEventArgs args)
    {
        canGrab = true;
        NarrativeTextSingleton.Instance.ClearText();
        if (!dayIsOver)
        {
            Debug.Log($"{gameObject.name} released");
     
            if (StaminaMeter.Instance.stamina <= 0)
            {
                canGrab = false;
                dayIsOver = true;
                NarrativeTextSingleton.Instance.StartNextDay();   
            }
        }
        audioSource.Stop();

    }



    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name} highlighted by {args.interactorObject.transform.name}");

        if (narrativeSO != null)
        {
            // Show description text when hovering, without reducing stamina
            NarrativeTextSingleton.Instance.SetHighlightText(narrativeSO.GetObjectInfo());
        }
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        Debug.Log($"{gameObject.name} highlight done");
        NarrativeTextSingleton.Instance.ClearHighlightText();
    }
}