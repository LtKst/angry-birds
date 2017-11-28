using System.Collections;
using UnityEngine;

public class Trail : MonoBehaviour {
    
    [SerializeField]
    private float trailSpacing = 1;
    [SerializeField]
    private float trailFadeOutSpeed = 0.4f;

    private Vector3 lastPositionSinceTrail;

    private void Start() {
        SpawnTrail();
    }

    private void Update() {
        if (Vector3.Distance(transform.position, lastPositionSinceTrail) > trailSpacing) {
            SpawnTrail();
        }
    }

    private void SpawnTrail() {
        lastPositionSinceTrail = transform.position;

        GameObject trail = ObjectPoolManager.instance.SpawnPoolObject("Trail");
        trail.transform.position = transform.position;

        StartCoroutine(FadeOutTrail(trail.GetComponent<SpriteRenderer>()));
    }

    private IEnumerator FadeOutTrail(SpriteRenderer spriteRenderer) {
        while (spriteRenderer.color.a > 0) {
            Color color = new Color(1, 1, 1, spriteRenderer.color.a - trailFadeOutSpeed * Time.deltaTime);
            spriteRenderer.color = color;

            yield return null;
        }

        spriteRenderer.gameObject.SetActive(false);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
