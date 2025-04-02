using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NarrativeTextSingleton : MonoBehaviour{
    public TextMeshProUGUI narrativeText;

    public static NarrativeTextSingleton Instance;

    public AudioSource audioSource;
    public AudioClip pickupItemClip;

    public FadeToColor nextSceneTransition;
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
    
    public void StartNextDay()
    {
        
        if(DayManagerSingleton.Instance.day >= DayManagerSingleton.Instance.lastDay){
            nextSceneTransition.FadeImage(SceneManager.GetActiveScene().buildIndex+1); // set the second scene to be the same as the default room but nothing is interactable except the vault door
        }else{
            DayManagerSingleton.Instance.day++;
            nextSceneTransition.FadeImage(SceneManager.GetActiveScene().buildIndex);
        }

    }
}