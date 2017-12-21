using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class UIButtons : MonoBehaviour {

    [SerializeField]
    private Pause pause;

    public void RestartButton() {
        SceneTransition.instance.StartTransition(0);
    }

    public void PauseButton() {
        pause.PauseGame();
    }
}
