using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToColor : MonoBehaviour
{
    [SerializeField] private Image imageToFade;
    [SerializeField] private Color startColor = Color.black;
    [SerializeField] private Color endColor = new Color(0f, 0f, 0f, 0f);
    [SerializeField] private float fadeDuration = 1.0f; // Time in seconds

    [SerializeField] private bool fadeOnStart = false;
    
    private void Start()
    {
        if(imageToFade == null){
            imageToFade = gameObject.GetComponent<Image>();
            if(imageToFade == null)
            {
                imageToFade = gameObject.AddComponent<Image>();
                Debug.LogWarning("No image component found to fade on " + gameObject.name + " FadeToColor script");
            }
        }
        if (fadeOnStart)
        {
            FadeImage();
        }
    }

    public void FadeImage()
    {
        StartCoroutine(Fade());
    }
    public void FadeImage(int index)
    {
        StartCoroutine(Fade(index));
    }

    private IEnumerator Fade()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageToFade.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        imageToFade.color = endColor;
    }
    private IEnumerator Fade(int index)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            imageToFade.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        imageToFade.color = endColor;
        SceneManager.LoadScene(index);
    }
}