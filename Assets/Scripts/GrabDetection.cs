using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabDetection : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    public NarrativeSO narrativeSO;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void Start()
    {
        if (narrativeSO == null)
        {
            Debug.LogWarning("NarrativeSO is null");
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name} grabbed by {args.interactorObject.transform.name}");
        if (narrativeSO != null)
        {
            NarrativeTextSingleton.Instance.SetText(narrativeSO.description);
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log($"{gameObject.name} released");
        NarrativeTextSingleton.Instance.ClearText();
    }
}