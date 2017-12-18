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

    private List<GameObject> activeTrailList = new List<GameObject>();

    private void Start() {
        bird = GetComponent<Bird>();

        TrailManager.instance.trailList.Add(this);

        scaleFactor = scaleFactorMax;

        SpawnTrail();
    }

    private void Update() {
        float distance = Vector3.Distance(transform.position, positionSinceLastTrail);

        if (distance > trailSpacing) {
            distance = trailSpacing;
        }

        if (distance >= trailSpacing && bird.shot) {
            print(distance);
            SpawnTrail();
        }
    }

    /// <summary>
    /// Place a trail object
    /// </summary>
    private void SpawnTrail() {
        Transform trail = ObjectPoolManager.instance.SpawnPoolObject("Trail", transform.position).transform;

        positionSinceLastTrail = trail.position;

        trail.localScale = new Vector2(1 / scaleFactor, 1 / scaleFactor);

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
