using UnityEngine;

public class Door : MonoBehaviour
{
    public FadeToColor fadeToColor;
        
    public void TriggerDoor()
    {
        fadeToColor.gameObject.SetActive(true);
        fadeToColor.FadeImage(true);
    }
    
    
}
