using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class ImageFade : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 2;
    [SerializeField]
    private float maxAlpha = 0.5f;
    [SerializeField]
    public bool visible;

    private Image image;

    private void Start() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.color = Color.Lerp(image.color, new Color(image.color.r, image.color.g, image.color.b, visible ? maxAlpha : 0), fadeSpeed * Time.unscaledDeltaTime);
    }
}
