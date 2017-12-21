using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class GameEnd : MonoBehaviour {

    public static GameEnd instance;

    [SerializeField]
    private float restartWaitTime = 10;

    [SerializeField]
    private AudioClip winAudioClip;
    [SerializeField]
    private AudioClip loseAudioClip;

    private AudioSource audioSource;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void EndGame(bool win) {
        if (instance != null) {
            if (win) {
                audioSource.PlayOneShot(winAudioClip);
            }
            else {
                audioSource.PlayOneShot(loseAudioClip);
            }

            StartCoroutine(WaitForRestart());
        }
    }

    private IEnumerator WaitForRestart() {
        yield return new WaitForSeconds(restartWaitTime);

        SceneTransition.instance.StartTransition(0);
    }
}
