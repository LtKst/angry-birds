using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CameraPan : MonoBehaviour {

    private Camera _camera;

    [SerializeField]
    private float panSpeed;

    private Vector3 initialPosition;
    private float initialSize;

    [SerializeField]
    private Vector3 inActionPosition;
    [SerializeField]
    private float inActionSize;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    public bool inAction;

    private void Awake() {
        _camera = GetComponent<Camera>();

        initialPosition = _camera.transform.position;
        initialSize = _camera.orthographicSize;
    }

    private void Update() {
        float speed = panSpeed * Time.deltaTime;

        _camera.transform.position = inAction ? Vector3.Lerp(_camera.transform.position, inActionPosition, speed) : Vector3.Lerp(_camera.transform.position, initialPosition, speed);
        _camera.orthographicSize = inAction ? Mathf.Lerp(_camera.orthographicSize, inActionSize, speed) : Mathf.Lerp(_camera.orthographicSize, initialSize, speed);
    }
}
