using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StaminaMeter : MonoBehaviour{
    public Slider slider;
    public TextMeshProUGUI staminaText;
    public int stamina = 10;
    public FadeToColor nextSceneTransition;

    void Start(){
        slider.maxValue = stamina;
    }

    public void ReduceStamina(int amount){
        stamina -= amount;
    }

    public void Update(){
        slider.value = stamina;
        staminaText.text = "Stamina: " + stamina;
        if(slider.value <= 0){
            StartNextDay();
        }
    }

    public void StartNextDay(){
        nextSceneTransition.FadeImage(SceneManager.GetActiveScene().buildIndex);
    }
}




