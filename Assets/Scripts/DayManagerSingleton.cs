using UnityEngine;
using UnityEngine.SceneManagement;

public class DayManagerSingleton: MonoBehaviour{

    public FadeToColor nextSceneTransition;

    [HideInInspector] public int day = 1; // using 0 indexing
    [HideInInspector] public int lastDay = 3;
    
    public static DayManagerSingleton Instance;

    public void Awake(){

        if (Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    public void StartNextDay(){

        if(day >= lastDay){
            nextSceneTransition.FadeImage(SceneManager.GetActiveScene().buildIndex+1); // set the second scene to be the same as the default room but nothing is interactable except the vault door
        }else{
            day++;
            nextSceneTransition.FadeImage(SceneManager.GetActiveScene().buildIndex);
        }

    }


}