using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    private bool paused;

    [SerializeField]
    private PanelUI pausePanel;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;

            if (paused) {
                PauseGame();
            }
            else {
                UnPauseGame();
            }
        }
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        UnPauseGame();
    }

    public void PauseGame() {
        pausePanel.SetVisible(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame() {
        pausePanel.SetVisible(false);
        Time.timeScale = 1;
    }
}
