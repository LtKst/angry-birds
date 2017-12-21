using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class SceneTransition : MonoBehaviour {

    public static SceneTransition instance;

    private static float transitionSpeed = 2;

    private static float overlayAlpha = 0;
    private GUIStyle currentStyle = null;

    private bool fading;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnGUI() {
        if (currentStyle == null) {
            currentStyle = new GUIStyle(GUI.skin.box);
        }

        currentStyle.normal.background = MakeTexture.MakeTex(2, 2, new Color(0f, 0f, 0f, overlayAlpha));

        if (fading) {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", currentStyle);
        }
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        fading = true;
        StartCoroutine(FadeOut());
    }

    public void StartTransition(int sceneIndex) {
        StartCoroutine(TransitionToScene(sceneIndex));
    }

    private IEnumerator TransitionToScene(int sceneIndex) {
        fading = true;

        while (overlayAlpha < 1) {
            overlayAlpha += Time.unscaledDeltaTime * transitionSpeed;

            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    private IEnumerator FadeOut() {
        while (overlayAlpha > 0) {
            overlayAlpha -= Time.unscaledDeltaTime * transitionSpeed;

            yield return null;
        }

        fading = false;
    }
}