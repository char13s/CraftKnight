using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneRelocation : MonoBehaviour
{
    private int currentScene;

    private GameObject currentSpawn;
    public static event UnityAction<GameObject> sendSpawn;
    // Start is called before the first frame update
    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void Start()
    {
        SceneTransitioner.sendNextScene += SwitchTheScene;
    }
    private void SwitchTheScene(int nextScene,GameObject newSpawn) {
        if (currentScene != 0) { 
        SceneManager.UnloadSceneAsync(currentScene);
        }
        SceneManager.LoadSceneAsync(nextScene,LoadSceneMode.Additive);
        currentScene = nextScene;
        currentSpawn = newSpawn;
    }
    private void OnLevelFinishedLoading(Scene scene,LoadSceneMode mode) {
        if (sendSpawn!=null) {
            sendSpawn(currentSpawn);
        }
    }
}
