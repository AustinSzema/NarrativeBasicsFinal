using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToColor : MonoBehaviour
{
    [SerializeField] private OVRScreenFade screenFade;

    private void Start()
    {
        // Auto-find OVRScreenFade if not assigned in Inspector
        if (screenFade == null)
        {
            screenFade = FindFirstObjectByType<OVRScreenFade>(FindObjectsInactive.Include);
            if (screenFade == null)
            {
                Debug.LogError("OVRScreenFade not found in the scene! Make sure it's attached to the XR Camera.");
            }
        }
    }

    // Simple Fade to Black
    public void FadeImage()
    {
        if (screenFade != null)
        {
            screenFade.FadeOut();
        }
    }

    // Fade Out and Load Scene
    public void FadeImage(int index)
    {
        if (screenFade != null)
        {
            StartCoroutine(FadeAndLoadScene(index));
        }
    }
    
    public void FadeImage(bool quit)
    {
        if (screenFade != null)
        {
            screenFade.FadeOut();
        }
    }

    private IEnumerator FadeAndLoadScene(int index)
    {
        screenFade.FadeOut();
        
        // Wait for fade to finish before changing scene
        yield return new WaitForSeconds(screenFade.fadeTime + 0.2f);

        SceneManager.LoadScene(index);
    }
}