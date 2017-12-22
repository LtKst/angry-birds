using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CameraPan : MonoBehaviour {

    private Camera _camera;

    [SerializeField]
    private float panSpeed;
    
    private float initialSize;

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

    public bool followingBird;

    private void Awake() {
        _camera = GetComponent<Camera>();

        initialSize = _camera.orthographicSize;
    }

    private void Update() {
        if (followingBird && birdToFollow != null && transform.position.x > minX && transform.position.x < maxX) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(birdToFollow.position.x + xOffset, transform.position.y, -10), panSpeed * Time.deltaTime);
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, inActionSize, panSpeed/2 * Time.deltaTime);
        }
    }
}
