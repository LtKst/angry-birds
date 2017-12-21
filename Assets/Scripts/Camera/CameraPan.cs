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
    private float xOffset = 5;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    [SerializeField]
    private Transform birdToFollow;

    public bool inAction;

    private void Awake() {
        _camera = GetComponent<Camera>();

        initialPosition = _camera.transform.position;
        initialSize = _camera.orthographicSize;
    }

    private void Update() {
        if (inAction && birdToFollow != null && transform.position.x > minX && transform.position.x < maxX) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(birdToFollow.position.x + xOffset, transform.position.y, -10), panSpeed * Time.deltaTime);
        }
    }
}
