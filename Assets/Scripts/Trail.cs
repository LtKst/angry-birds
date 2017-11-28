using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Trail : MonoBehaviour {
    
    [SerializeField]
    private float trailSpacing = 1;

    private Vector3 positionSinceLastTrail;

    private void Start() {
        SpawnTrail();
    }

    private void Update() {
        if (Vector3.Distance(transform.position, positionSinceLastTrail) > trailSpacing) {
            SpawnTrail();
        }
    }

    private void SpawnTrail() {
        positionSinceLastTrail = transform.position;

        ObjectPoolManager.instance.SpawnPoolObject("Trail").transform.position = transform.position;
    }
}
