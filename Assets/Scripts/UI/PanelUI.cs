using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class PanelUI : MonoBehaviour {
    RectTransform rect;

    public float slideSpeed = 5;

    [SerializeField]
    Vector3 visiblePosition = new Vector3(-200, 0, 0);
    [SerializeField]
    Vector3 hiddenPosition = new Vector3(200, 0, 0);

    [SerializeField]
    bool visible;

    private void Start() {
        rect = GetComponent<RectTransform>();

        if (visible) {
            rect.anchoredPosition = visiblePosition;
        }
        else {
            rect.anchoredPosition = hiddenPosition;
        }
    }

    private void Update() {
        if (visible) {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, visiblePosition, Time.unscaledDeltaTime * slideSpeed);
        }
        else {
            rect.anchoredPosition = Vector3.Lerp(rect.anchoredPosition, hiddenPosition, Time.unscaledDeltaTime * slideSpeed);
        }
    }

    public void ToggleVisible() {
        visible = !visible;
    }

    public void SetVisible(bool value) {
        visible = value;
    }

    public void SetVisibilityForSeconds(float seconds) {
        StartCoroutine(VisibleForSeconds(seconds));
    }

    IEnumerator VisibleForSeconds(float seconds) {
        visible = true;

        yield return new WaitForSeconds(seconds);

        visible = false;
    }

    public bool IsVisible {
        get {
            return visible;
        }
        set {
            visible = value;
        }
    }

    public void SetVisibilityPositions(Vector3 visible, Vector3 hidden) {
        visiblePosition = visible;
        hiddenPosition = hidden;
    }

    public Vector3 VisiblePosition {
        get {
            return visiblePosition;
        }
    }

    public Vector3 HiddenPosition {
        get {
            return hiddenPosition;
        }
    }
}