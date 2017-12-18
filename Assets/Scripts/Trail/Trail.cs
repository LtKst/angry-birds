using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Trail : MonoBehaviour {

    private Bird bird;

    [SerializeField]
    private float trailSpacing = 1;
    [SerializeField]
    private float scaleFactorMax = 3;

    private Vector3 positionSinceLastTrail;
    private float scaleFactor;
    private Vector2 initialScale;

    private List<GameObject> activeTrailList = new List<GameObject>();

    private void Start() {
        initialScale = transform.localScale;

        positionSinceLastTrail = transform.position;

        bird = GetComponent<Bird>();

        TrailManager.instance.trailList.Add(this);

        scaleFactor = scaleFactorMax;
    }

    private void Update() {
        Vector3 position = transform.position;
        float distance = Vector3.Distance(position, positionSinceLastTrail);

        if (distance >= trailSpacing && bird.shot) {
            SpawnTrail(Vector3.MoveTowards(positionSinceLastTrail, position, trailSpacing));
        }
    }

    /// <summary>
    /// Place a trail object
    /// </summary>
    private void SpawnTrail(Vector3 position) {
        positionSinceLastTrail = position;

        Transform trail = ObjectPoolManager.instance.SpawnPoolObject("Trail", position).transform;

        trail.localScale = new Vector2(initialScale.x / scaleFactor, initialScale.y / scaleFactor);

        activeTrailList.Add(trail.gameObject);

        scaleFactor -= 0.5f;

        if (scaleFactor == 0.5f) {
            scaleFactor = 2;
        }
    }

    /// <summary>
    /// Disable all active trail objects
    /// </summary>
    public void DisableTrail() {
        foreach (GameObject go in activeTrailList) {
            go.SetActive(false);
        }
    }
}
