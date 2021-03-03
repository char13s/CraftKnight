using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour {
    private bool pause;
    public static event UnityAction<bool> pauseGame;
    [SerializeField] private UnityEvent onPause;
    [SerializeField] private UnityEvent onUnPause;
    // Start is called before the first frame update
    void Start() {
        CanvasManager.pause += StopTime;
        PlayerBase.pause += PauseGame;
    }

    private void PauseGame() {
        if (pause) {
            Time.timeScale = 1;
            pause = false;
            onUnPause.Invoke();
        }
        else {
            StopTime();
            onPause.Invoke();
        }
        if (pauseGame != null) {
            pauseGame(pause);
        }
    }
    private void StopTime() {
        Time.timeScale = 0;
        pause = true;
    }
    public void Save() {

    }
}
