using TMPro;
using UnityEngine;


public class NarrativeTextSingleton : MonoBehaviour{
    public TextMeshProUGUI narrativeText;

    public static NarrativeTextSingleton Instance;

    public AudioSource audioSource;
    public AudioClip pickupItemClip;

    public void Awake(){
        Instance = this;
    }

    public void SetText(string txt){
        narrativeText.text = txt;
        audioSource.PlayOneShot(pickupItemClip);
    }

    public void ClearText(){
        narrativeText.text = "";
    }
}