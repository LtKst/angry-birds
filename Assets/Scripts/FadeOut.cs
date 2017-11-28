using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class FadeOut : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float fadeOutSpeed = 0.4f;
    [SerializeField]
    private bool fadeOutOnStart = true;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        if (fadeOutOnStart) {
            StartCoroutine(FadeOutTrail());
        }
    }

    private IEnumerator FadeOutTrail() {
        while (spriteRenderer.color.a > 0) {
            Color color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.g, spriteRenderer.color.a - fadeOutSpeed * Time.deltaTime);
            spriteRenderer.color = color;

            yield return null;
        }

        spriteRenderer.gameObject.SetActive(false);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.g, 1);
    }
}
