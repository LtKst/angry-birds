using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class FadeOut : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float fadeOutSpeed = 0.4f;
    [SerializeField]
    private bool fadeOutOnEnable = true;
    [SerializeField]
    private bool resetOnDisable = true;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        if (fadeOutOnEnable) {
            StartCoroutine(FadeOutTrail());
        }
    }

    private void OnDisable() {
        if (resetOnDisable) {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.g, 1);
        }
    }

    private IEnumerator FadeOutTrail() {
        while (spriteRenderer.color.a > 0) {
            Color color = new Color(spriteRenderer.color.r, spriteRenderer.color.b, spriteRenderer.color.g, spriteRenderer.color.a - fadeOutSpeed * Time.deltaTime);
            spriteRenderer.color = color;

            yield return null;
        }

        spriteRenderer.gameObject.SetActive(false);
    }
}
